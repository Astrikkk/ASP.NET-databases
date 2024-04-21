using ASPNET_databases.Models;
using ASPNET_databases.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ASPNET_databases.DataBase;

namespace ASPNET_databases.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ShopDbContext context)
        {
            this.context = context;
        }

        private readonly ShopDbContext context;
        public IActionResult Index()
        {
            var items = context.Tanks.Include(x => x.Class).ToList();
            return View(items);
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
    }
}
