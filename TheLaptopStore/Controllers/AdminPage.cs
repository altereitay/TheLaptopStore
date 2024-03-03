using Microsoft.AspNetCore.Mvc;
using TheLaptopStore.Data;

namespace TheLaptopStore.Controllers
{
    public class AdminPage : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public AdminPage(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

     
        public IActionResult Managment()
        {
            List<Laptop> laptops = _db.Laptops.ToList();
            return View("AdminPage",laptops);
        }


        
        public IActionResult Delete(string? model)
        {
            var obj = _db.Laptops.Find(model);

            if (obj == null)
            {
                return NotFound();
            }

            _db.Laptops.Remove(obj);
            _db.SaveChanges();
            List<Laptop> laptops = _db.Laptops.ToList();
            return View("AdminPage", laptops);
        }

        public IActionResult deleteProduct()
        {
            List<Laptop> laptops = _db.Laptops.ToList();
            return View("deleteProduct", laptops);
        }


        public IActionResult Add()
        {
            return View("addProduct");
        }

    }
}
