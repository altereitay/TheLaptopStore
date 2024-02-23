using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using TheLaptopStore.Models;

namespace TheLaptopStore.Controllers
{
    public class LoginController : Controller
    {
        private bool IsValidUser(string email, string password)
        {
            if (!IsValidEmail(email))
            {
                ModelState.AddModelError("Email", "Invalid email format");
                return false;
            }

            // Check if the password has at least 8 characters
            if (password.Length < 8)
            {
                ModelState.AddModelError("Password", "Password must be at least 8 characters long");
                return false;
            }
            return true;
        }
        private bool IsValidEmail(string email)
        {
            // Simple email format validation using a regular expression
            string emailRegexPattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return System.Text.RegularExpressions.Regex.IsMatch(email, emailRegexPattern);
        }


        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View("Login");
        }

        public ActionResult Submit(string Email, string password, string submitButton)
        {
            if (submitButton == "connect us")
            {
                if (IsValidUser(Email, password))
                {
                    ViewData["UserEmail"] = Email.Split('@')[0];
                    ViewData["pass"] = password;
                    return RedirectToAction("ShowHomePage", "HomePage");
                }

                else return View("Login");
            }
            else
            {
                return RedirectToAction("View_Register", "Register");
            }
        }



    }
}