using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheLaptopStore.Models;

namespace TheLaptopStore.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult ShowHomePage()
        {
            List<Laptop> laptops = new List<Laptop>();
            Laptop l1 = new Laptop()
            {
                Ram = 1234,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 1500,
                Maker = "Nir",
                Color = "Kaki",
                Quantity = 10,
                Description = "The best computer ever",
                Picture = "..\\images\\laptop1.jpg",
                IsOnSale = false,
                PopularityIndex = 5,
                Category = "Gaming",
                ReleaseDate = "23/07/1999",
                Model = "12345"
            };
            Laptop l2 = new Laptop()
            {
                Ram = 1234,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 1500,
                Maker = "Nir",
                Color = "Kaki",
                Quantity = 10,
                Description = "The best computer ever",
                Picture = "..\\images\\laptop2.jpg",
                IsOnSale = false,
                PopularityIndex = 5,
                Category = "Gaming",
                ReleaseDate = "23/07/1999",
                Model = "12346"
            };
            Laptop l3 = new Laptop()
            {
                Ram = 1234,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 1500,
                Maker = "Nir",
                Color = "Kaki",
                Quantity = 10,
                Description = "The best computer ever",
                Picture = "..\\images\\laptop3.jpg",
                IsOnSale = false,
                PopularityIndex = 5,
                Category = "Gaming",
                ReleaseDate = "23/07/1999",
                Model = "12347"
            };
            laptops.Add(l1);
            laptops.Add(l2);
            laptops.Add(l3);
            return View("HomePage", laptops);
        }

        public ActionResult Product(Laptop l1)
        {
            return View("ProductPage", l1);
        }
    }
}