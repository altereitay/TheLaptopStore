using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheLaptopStore.Data;

namespace TheLaptopStore.Controllers
{
    public class PaymentController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public PaymentController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
        }
        public IActionResult showPaymentPage()
        {
            string userId = _userManager.GetUserId(User);
            ApplicationUser user = _db.Users.Find(userId);

            // Check if the shopping cart for the user exists
            ShoppingCart userCart = _db.ShoppingCarts.FirstOrDefault(cart => cart.userId == userId);

            if (userCart == null)
            {
                TempData["ModelError"] = "Add products to your cart";
                return Redirect("~/ShoppingCart");
            } 
                return View("PaymentPage", user);
            
        }

        public IActionResult payNow(string? cardnumber, string? expmonth, string? expyear, string? cvv)
        {
            string id = _userManager.GetUserId(User);
            ApplicationUser user = _db.Users.Find(id);

            user.CreditCardNumber = long.Parse(cardnumber);
            user.ExpDateMonth = Convert.ToInt32(expmonth);
            user.ExpDateYear = Convert.ToInt32(expyear);
            user.CVV = Convert.ToInt32(cvv);

            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}