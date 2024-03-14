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

        public IActionResult AddToCart(string ? model, string addToCart, string buyNow) {

            string id = _userManager.GetUserId(User);
            var laptop = _db.Laptops.Find(model);

            if (id == null) {
                id = HttpContext.Session.GetString("id");
            }

            if (laptop == null) {
                return NotFound();
            }
            string quan = Request.Form["quantity"];

            if (!string.IsNullOrEmpty(quan) && laptop.Quantity< Convert.ToInt32(Request.Form["quantity"]))
            {
                TempData["TooMuchProducts"] = "Only " + laptop.Quantity + " laptops left";
                return View("ProductCard",laptop);
            }
            if(string.IsNullOrEmpty(quan))
            {
                TempData["EmptyQuantity"] = "Add products";
                return View("ProductCard", laptop);
            }


            ShoppingCart sc = _db.ShoppingCarts.Find(model, id);
            if (sc is not null) {
                int checkQuantity = sc.quantity + Convert.ToInt32(Request.Form["quantity"]);
                if (checkQuantity > laptop.Quantity) {
                    TempData["cartPlusQuantity"]="You have in your cart "+ sc.quantity + "\nThere is left: "+(laptop.Quantity- sc.quantity);
                    return View("ProductCard", laptop);
                }
                sc.quantity += Convert.ToInt32(Request.Form["quantity"]);
                sc.totalPrice = sc.quantity * laptop.Price;
            } 
            else {
                int totalPrice = 0;
                int quantity = Convert.ToInt32(Request.Form["quantity"]);
                if (laptop.SalePrecentage > 0)
                {
                    totalPrice = Convert.ToInt32(quantity * (laptop.Price - laptop.Price * (laptop.SalePrecentage * 0.01)));
                }
                else
                {
                    totalPrice = quantity * laptop.Price;
                }
                ShoppingCart cart = new ShoppingCart();
                cart.laptop = laptop;
                cart.laptopModel = model;
                cart.totalPrice = totalPrice;
                cart.quantity = quantity;
                cart.userId = id;

                _db.ShoppingCarts.Add(cart);
            }            
            _db.SaveChanges();
            if (!string.IsNullOrEmpty(addToCart))
            {
                return RedirectToAction("Index", "Home");
            }
            else 
            {

                return Redirect("~/ShoppingCart"); // Redirect to the checkout page or any other appropriate action
            }

        }
        


    }
}
