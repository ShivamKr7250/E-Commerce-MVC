using E_Commerce.DataAccess.Repository.IRepository;
using E_Commerce.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_Commerce.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork db, ILogger<HomeController> logger)
        {
            _unitOfWork = db;
            _logger = logger;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            Product product = _unitOfWork.Product.Get(u=>u.Id== productId, includeProperties: "Category");
            return View(product);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
