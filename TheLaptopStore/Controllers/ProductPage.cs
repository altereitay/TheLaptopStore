using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheLaptopStore.Data;

namespace TheLaptopStore.Controllers {
    public class ProductPage : Controller {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public ProductPage(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger, ApplicationDbContext db) {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public IActionResult AddToCart(string ? model) {

            string id = _userManager.GetUserId(User);
            var laptop = _db.Laptops.Find(model);
            
            if (laptop == null) {
                return NotFound();
            }

            ShoppingCart sc = _db.ShoppingCarts.Find(model, id);
            if (sc is not null) {
                sc.quantity += Convert.ToInt32(Request.Form["quantity"]);
                sc.totalPrice = sc.quantity * laptop.Price;
            } 
            else {
                int quantity = Convert.ToInt32(Request.Form["quantity"]);
                int totalPrice = quantity * laptop.Price;

                ShoppingCart cart = new ShoppingCart();
                cart.laptop = laptop;
                cart.laptopModel = model;
                cart.totalPrice = totalPrice;
                cart.quantity = quantity;
                cart.userId = id;

                _db.ShoppingCarts.Add(cart);
            }            
            _db.SaveChanges();

            return View("ProductCard", laptop);
        }
    }
}
