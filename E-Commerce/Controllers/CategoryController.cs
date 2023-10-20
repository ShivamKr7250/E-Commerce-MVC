using E_Commerce.DataAccess.Data;
using E_Commerce.DataAccess.Repository.IRepository;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository db)
        {
            _categoryRepo = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder.ToString())
            {
              ModelState.AddModelError("name", "The Display Order cannot exactly match the Name.");
            }
          //  if (obj.Name.ToLower() == "test")
            //{
              //  ModelState.AddModelError("", "Test is an Invalid Value");
            //}
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();
            
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            //Multiple Ways to Retrieve Data and Edit 

            Category? categoryFromDb = _categoryRepo.Get(u=>u.Id==id); //Find work only on primary key
           // Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
            // Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryFromDb == null){
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Update(obj);
                _categoryRepo.Save();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            //Multiple Ways to Retrieve Data and Edit 

            Category? categoryFromDb = _categoryRepo.Get(u => u.Id == id); //Find work only on primary key
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
            Category obj = _categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _categoryRepo.Remove(obj);
            _categoryRepo.Save();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index", "Category");
        }
    }
}
