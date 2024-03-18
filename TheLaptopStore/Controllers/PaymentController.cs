﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text;
using TheLaptopStore.Data;
using System;
using System.Security.Cryptography;
using System.Text;

namespace TheLaptopStore.Controllers {
    public class PaymentController : Controller {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public PaymentController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ILogger<HomeController> logger, ApplicationDbContext db) {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _db = db;
        }

        public IActionResult RemoveProductCart(string? laptopModel) {
            string userId = _userManager.GetUserId(User);

            if (userId == null) {
                userId = HttpContext.Session.GetString("id");
            }

            ApplicationUser user = _db.Users.Find(userId);
            List<ShoppingCart> userCarts = _db.ShoppingCarts.Include(c => c.laptop).Where(cart => cart.userId == userId).ToList();
            foreach (ShoppingCart cart in userCarts) {
                if (cart.laptopModel == laptopModel) {
                    _db.ShoppingCarts.Remove(cart);
                    _db.SaveChanges();
                    return Redirect("~/ShoppingCart");
                }
            }
            return Redirect("~/ShoppingCart");


        }
        public IActionResult AddProductCart(string? laptopModel) {
            string userId = _userManager.GetUserId(User);

            if (userId == null) {
                userId = HttpContext.Session.GetString("id");
            }

            ApplicationUser user = _db.Users.Find(userId);
            List<ShoppingCart> userCarts = _db.ShoppingCarts.Include(c => c.laptop).Where(cart => cart.userId == userId).ToList();
            foreach (ShoppingCart cart in userCarts) {
                if (cart.laptopModel == laptopModel) {

                    if (_db.Laptops.Find(laptopModel).Quantity > cart.quantity) {
                        cart.quantity++;
                        cart.totalPrice = Convert.ToInt32(cart.quantity * (cart.laptop.Price - cart.laptop.Price * cart.laptop.SalePrecentage * 0.01));
                        _db.SaveChanges();
                        int price = 0;
                        var cartList = _db.ShoppingCarts.Include(c => c.laptop).Where(c => c.userId == userId).ToList();
                        foreach (var Cart in cartList) {

                            price += Cart.totalPrice;

                        }
                        TempData["Price"] = price;

                        return Redirect("~/ShoppingCart");

                    } else {
                        TempData["CantAdd"] = "Cant add another product";
                        TempData["idModel"] = _db.Laptops.Find(laptopModel).Model;
                        
                        return Redirect("~/ShoppingCart");
                    }
                }

            }
            return Redirect("~/ShoppingCart");

        }

        public IActionResult DecreaseProductCart(string? laptopModel) {
            string userId = _userManager.GetUserId(User);

            if (userId == null) {
                userId = HttpContext.Session.GetString("id");
            }

            ApplicationUser user = _db.Users.Find(userId);
            List<ShoppingCart> userCarts = _db.ShoppingCarts.Include(c => c.laptop).Where(cart => cart.userId == userId).ToList();
            foreach (ShoppingCart cart in userCarts) {
                if (cart.laptopModel == laptopModel) {

                    if (cart.quantity > 1) {
                        cart.quantity--;
                        cart.totalPrice = Convert.ToInt32(cart.quantity * (cart.laptop.Price - cart.laptop.Price * cart.laptop.SalePrecentage * 0.01));
                        _db.SaveChanges();
                        int price = 0;
                        var cartList = _db.ShoppingCarts.Include(c => c.laptop).Where(c => c.userId == userId).ToList();
                        foreach (var Cart in cartList) {
                            price += Cart.totalPrice;
                        }
                        TempData["Price"] = price;

                        return Redirect("~/ShoppingCart");

                    } else {
                        _db.ShoppingCarts.Remove(cart);
                        _db.SaveChanges();
                        int price = 0;
                        var cartList = _db.ShoppingCarts.Include(c => c.laptop).Where(c => c.userId == userId).ToList();
                        foreach (var Cart in cartList) {
                            price += Cart.totalPrice;
                        }
                        TempData["Price"] = price;
                        return Redirect("~/ShoppingCart");
                    }
                }
            }
            return Redirect("~/ShoppingCart");
        }

        public IActionResult showPaymentPage() {
            string userId = _userManager.GetUserId(User);
            ApplicationUser user = _db.Users.Find(userId);

            if (userId == null) {
                userId = HttpContext.Session.GetString("id");
            }

            // Check if the shopping cart for the user exists
            ShoppingCart userCart = _db.ShoppingCarts.FirstOrDefault(cart => cart.userId == userId);

            if (userCart == null) {
                TempData["ModelError"] = "Add products to your cart";
                return Redirect("~/ShoppingCart");
            } else {
                List<ShoppingCart> userCarts = _db.ShoppingCarts.Include(c => c.laptop).Where(cart => cart.userId == userId).ToList();
                foreach (ShoppingCart cart in userCarts) {
                    if (_db.Laptops.Find(cart.laptop.Model).Quantity - cart.quantity < 0) {
                        TempData["UnavailableLaptop"] = "The product model : " + cart.laptop.Model + " is Unavailable";
                        _db.ShoppingCarts.Remove(cart);
                        _db.SaveChanges();
                        return Redirect("~/ShoppingCart");
                    }
                }
            }
            if (user == null) {
                return View("GuestPayment");
            }
            return View("PaymentPage", user);

        }

        public IActionResult payNow(string? cardNumber, string? expDate, string? CVV) {
            string userId = _userManager.GetUserId(User);

            string cardWithoutSpaces = cardNumber.Replace(" ", "");

            string[] parts = expDate.Split('/');
            int expMonth = int.Parse(parts[0]);
            int expYear = int.Parse("20" + parts[1]);

            if (userId == null) {
                userId = HttpContext.Session.GetString("id");
            }

            ApplicationUser user = _db.Users.Find(userId);

            if (user == null) {
                List<ShoppingCart> guestCarts = _db.ShoppingCarts.Include(c => c.laptop).Where(cart => cart.userId == userId).ToList();

                foreach (ShoppingCart cart in guestCarts) {
                    var product = _db.Laptops.Find(cart.laptop.Model);
                    product.Quantity -= cart.quantity;
                    product.PopularityIndex += cart.quantity;
                    _db.ShoppingCarts.Remove(cart);
                }

                _db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            List<ShoppingCart> userCarts = _db.ShoppingCarts.Include(c => c.laptop).Where(cart => cart.userId == userId).ToList();

            foreach (ShoppingCart cart in userCarts) {
                var product = _db.Laptops.Find(cart.laptop.Model);
                product.Quantity -= cart.quantity;
                product.PopularityIndex += cart.quantity;
                _db.ShoppingCarts.Remove(cart);
            }
            user.CreditCardNumber = long.Parse(cardWithoutSpaces);
            user.ExpDateMonth = expMonth;
            user.ExpDateYear = expYear;
            user.CVV = Convert.ToInt32(CVV);

            _db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

     





    }
}