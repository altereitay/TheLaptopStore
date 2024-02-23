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
        public ActionResult Submit(User user)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ShowHomePage", "HomePage");
            } 
            else
            {
                return View("Register");
            }
            
        }

        public ActionResult View_Register(User user)
        {
            return View("Register");
        }


        public ActionResult Good()
        {
            return View();
        }
    }
}