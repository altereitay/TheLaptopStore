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
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 100,
                Maker = "Nir",
                Color = "Kaki",
                Quantity = 10,
                Description = "The best computer ever gfghghfhgdfgdfgdfndfgbbgf ",
                Picture = "..\\images\\laptop1.jpg",
                IsOnSale = false,
                PopularityIndex = 5,
                Category = "Gaming",
                ReleaseDate = "23/07/1999",
                Model = "12345"
            };
            Laptop l2 = new Laptop()
            {
                Ram = 32,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 200,
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
                Ram = 64,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 300,
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
            Laptop l4 = new Laptop()
            {
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 400,
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
            Laptop l5 = new Laptop()
            {
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 150,
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
            Laptop l6 = new Laptop()
            {
                Ram = 8,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 255,
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
            Laptop l7 = new Laptop()
            {
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 300,
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
            Laptop l8 = new Laptop()
            {
                Ram = 32,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 400,
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
            Laptop l9= new Laptop()
            {
                Ram = 8,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 200,
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

            laptops.Add(l1);
            laptops.Add(l2);
            laptops.Add(l3);
            laptops.Add(l4);
            laptops.Add(l5);
            laptops.Add(l6);
            laptops.Add(l7);
            laptops.Add(l8);
            laptops.Add(l9);
            
            return View("HomePage", laptops);
        }

        public ActionResult Product(Laptop l1)
        {
            return View("ProductPage", l1);
        }




        public ActionResult FilterByPrice(string priceFilter,string RamFilter)
        {
            List<Laptop> laptops = new List<Laptop>();
            Laptop l1 = new Laptop()
            {
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 100,
                Maker = "Nir",
                Color = "Kaki",
                Quantity = 10,
                Description = "The best computer ever gfghghfhgdfgdfgdfndfgbbgf ",
                Picture = "..\\images\\laptop1.jpg",
                IsOnSale = false,
                PopularityIndex = 5,
                Category = "Gaming",
                ReleaseDate = "23/07/1999",
                Model = "12345"
            };
            Laptop l2 = new Laptop()
            {
                Ram = 32,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 200,
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
                Ram = 64,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 300,
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
            Laptop l4 = new Laptop()
            {
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 400,
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
            Laptop l5 = new Laptop()
            {
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 150,
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
            Laptop l6 = new Laptop()
            {
                Ram = 8,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 255,
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
            Laptop l7 = new Laptop()
            {
                Ram = 16,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 300,
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
            Laptop l8 = new Laptop()
            {
                Ram = 32,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 400,
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
            Laptop l9 = new Laptop()
            {
                Ram = 8,
                SSD = 5678,
                CPU = "i100",
                ScreenSize = 15.6,
                GPU = "katlan",
                Price = 200,
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

            laptops.Add(l1);
            laptops.Add(l2);
            laptops.Add(l3);
            laptops.Add(l4);
            laptops.Add(l5);
            laptops.Add(l6);
            laptops.Add(l7);
            laptops.Add(l8);
            laptops.Add(l9);

            List<TheLaptopStore.Models.Laptop> filteredLaptops= new List<Laptop>();

            if (priceFilter == "all" && RamFilter=="all")
            {
                filteredLaptops = laptops;
            }
            else if (priceFilter == "all" && RamFilter != "all")
            {
                int RamValue = int.Parse(RamFilter);
                for (int i = 0; i < laptops.Count; i++)
                {
                    if (RamValue == laptops[i].Ram)
                    {
                        filteredLaptops.Add(laptops[i]);

                    }
                }
            }
            else if (priceFilter != "all" && RamFilter == "all")
            {
                int filterValue = int.Parse(priceFilter);
                
                for (int i = 0; i < laptops.Count; i++)
                {
                    if (laptops[i].Price > filterValue)
                    {
                        filteredLaptops.Add(laptops[i]);

                    }
                }
            }

            else
            {
                // Parse the selected price filter (assuming it's an integer)
                int filterValue = int.Parse(priceFilter);
                int RamValue = int.Parse(RamFilter);
                for (int i = 0; i < laptops.Count; i++)
                {
                    if (laptops[i].Price> filterValue && RamValue == laptops[i].Ram)
                    {
                        filteredLaptops.Add(laptops[i]);

                    }
                }
                
    }

            return View("HomePage", filteredLaptops);
        }



    }
}