using Microsoft.AspNetCore.Mvc;
using EComMVC.Data;
using EComMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace EComMVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Product product = new Product();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



    }
}
