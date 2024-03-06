using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public async Task<IActionResult> AddToCart(string ? model, int quantity) {

            string id = _userManager.GetUserId(User);
            var laptop = _db.Laptops.Find(model);
            
            if (laptop == null) {
                return NotFound();
            }
          
            int totalPrice = quantity * laptop.Price;

            ShoppingCart cart = new ShoppingCart();
            cart.laptop = laptop; 
            cart.totalPrice = totalPrice;   
            cart.quantity = quantity;
            cart.userId = id;

            _db.ShoppingCarts.Add(cart);
            _db.SaveChanges();

            return View("ProductCard", laptop);
        }
    }
}
