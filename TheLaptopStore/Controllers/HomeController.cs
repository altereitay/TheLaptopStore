using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheLaptopStore.Data;
using TheLaptopStore.Models;
using System.IO;

namespace TheLaptopStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Laptop> laptops = _db.Laptops.ToList();

            return View(laptops);
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
        public IActionResult FilterProducts(List<int> ramFilter, List<string> cpuFilter, List<string> gpuFilter)
        {
            IQueryable<Laptop> filteredProducts = _db.Laptops.AsQueryable();

         
            // Apply RAM filter
            if (ramFilter != null && ramFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => ramFilter.Contains(laptop.Ram));
            }

            // Apply CPU filter
            if (cpuFilter != null && cpuFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => cpuFilter.Contains(laptop.CPU));
            }

            // Apply GPU filter
            if (gpuFilter != null && gpuFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => gpuFilter.Contains(laptop.GPU));
            }

            // Execute the query and retrieve the filtered products
            List<Laptop> result = filteredProducts.ToList();

            // Pass the filtered products to the view
            return View("Index",result);
        }


    }
}