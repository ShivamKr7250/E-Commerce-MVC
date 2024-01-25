using MaaMobile.DataAccess.Data;
using MaaMobile.DataAccess.Repository.IRepository;
using MaaMobile.Models;
using MaaMobile.Models.ViewModels;
using MaaMobile.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MaaMobile.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(IWebHostEnvironment webHostEnvironment,IUnitOfWork db)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            CategoryVM categoryVM = new()
            {
                Category = new Category()
            };

            if (id == null || id == 0)
            {
                //Create
                return View(categoryVM);
            }
            else
            {
                //Update
                categoryVM.Category = _unitOfWork.Category.Get(u => u.Id == id);
                return View(categoryVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(CategoryVM categoryVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;

                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\category\");

                    if (!string.IsNullOrEmpty(categoryVM.Category.ImageUrl))
                    {
                        //delete th old Image
                        var oldImagePath = Path.Combine(wwwRootPath, categoryVM.Category.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    categoryVM.Category.ImageUrl = @"\images\category\" + fileName;
                }

                if (categoryVM.Category.Id == 0)
                {
                    _unitOfWork.Category.Add(categoryVM.Category);
                }
                else
                {
                    _unitOfWork.Category.Update(categoryVM.Category);
                }
                _unitOfWork.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return View(categoryVM);
            }
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Multiple Ways to Retrieve Data and Edit 

            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id); //Find work only on primary key
                                                                                  // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
                                                                                  // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category obj = _unitOfWork.Category.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
