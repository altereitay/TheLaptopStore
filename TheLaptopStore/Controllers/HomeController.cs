﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TheLaptopStore.Data;
using TheLaptopStore.Models;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace TheLaptopStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index() {
            List<Laptop> laptops = _db.Laptops.ToList();

            if (HttpContext.Session.GetString("id") == null) {
                HttpContext.Session.SetString("id", HttpContext.Session.Id);
            }

            return View(laptops);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult FilterProducts(List<int> ramFilter, List<string> cpuFilter, List<string> gpuFilter,List<int> PriceFilter, List<int> ssdFilter,List<string> MakerFilter, List<double> screenFilter,List<string> categoryFilter)
        {
            IQueryable<Laptop> filteredProducts = _db.Laptops.AsQueryable();

         
            // Apply RAM filter
            if (ramFilter != null && ramFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => ramFilter.Contains(laptop.Ram));
            }

            // Apply CPU filter
            if (cpuFilter != null && cpuFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => cpuFilter.Contains(laptop.CPU));
            }

            // Apply GPU filter
            if (gpuFilter != null && gpuFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => gpuFilter.Contains(laptop.GPU));
            }
            if (PriceFilter != null && PriceFilter.Any())
            {

                int lowest_price = PriceFilter.Min();
                filteredProducts = filteredProducts.Where(laptop => laptop.Price > lowest_price);
            }
            if (ssdFilter != null && ssdFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => ssdFilter.Contains(laptop.SSD));
            }
            if (MakerFilter != null && MakerFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => MakerFilter.Contains(laptop.Maker));
            }
            if (screenFilter != null && screenFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => screenFilter.Contains(laptop.ScreenSize));
            }
            if (categoryFilter != null && categoryFilter.Any())
            {
                filteredProducts = filteredProducts.Where(laptop => categoryFilter.Contains(laptop.Category));
            }

            // Execute the query and retrieve the filtered products
            List<Laptop> result = filteredProducts.ToList();

            // Pass the filtered products to the view
            return View("Index",result);
        }


    }
}