using Microsoft.AspNetCore.Mvc;
using TheLaptopStore.Data;

namespace TheLaptopStore.Controllers {
    public class ProductPage : Controller {

        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public ProductPage(ILogger<HomeController> logger, ApplicationDbContext db) {
            _logger = logger;
            _db = db;
        }
        public IActionResult showProductCard(string ? model) {
            var obj = _db.Laptops.Find(model);

            if (obj == null) {
                return NotFound();
            }
            return View("ProductCard", obj);
        }
    }
}
