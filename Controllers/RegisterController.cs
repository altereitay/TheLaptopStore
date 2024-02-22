using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheLaptopStore.Models;

namespace TheLaptopStore.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                return View("Good");
            } 
            else
            {
                return View("Register");
            }
            
        }

        public ActionResult Good()
        {
            return View();
        }
    }
}