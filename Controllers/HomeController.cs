using EComMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EComMVC.Data;
using EComMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EComMVC.Controllers
{
    public class HomeController : Controller
    { 
        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context) {
            _context = context;
        }

        //Get: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _context.Products.ToList();
            return View(products);
        }

        //Get: /<controller>/Details/5
        [HttpGet]
        public IActionResult Details(int id)
        {
            Product product = _context.Products.Find(id);
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
