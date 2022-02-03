using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductDb.DataAccessLayer;
using ProductDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDb.Controllers
{

    public class HomeController : Controller
    {
        private readonly AppDbContext _dbContext;

        public HomeController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {

            //var Phones = new Category { Id = 1, Name = "samsung" };
            //var Accessories = new Category { Id = 2, Name = "Toshiba" };

            //var products = new List<Product>
            //{
            //    new Product{Id=1,Name="A52",Category=Phones},
            //    new Product{Id=2,Name="Note10",Category=Phones},
            //    new Product{Id=3,Name="XR",Category=Accessories},
            //};

            var products = _dbContext.Products.Include(x => x.Category).ToList();
            return View(products);
        }
    }
}
