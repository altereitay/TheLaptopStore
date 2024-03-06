using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheLaptopStore.Data;

namespace TheLaptopStore.Controllers {
    public class ShoppingCartController : Controller {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public ShoppingCartController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger, ApplicationDbContext db) {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
        }
        public IActionResult Index() {

            string id = _userManager.GetUserId(User);
            var cartList = _db.ShoppingCarts.Include(c => c.laptop).Where(c => c.userId == id).ToList();
            return View("ShoppingCartPage", cartList);
        }
    }
}
