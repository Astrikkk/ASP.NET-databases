using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using ASPNET_databases.Extensions;
using ASPNET_databases.Data;
using ASPNET_databases.Data.Entities;
using AutoMapper;
using ASPNET_databases.Models;
using Microsoft.EntityFrameworkCore;
using ASPNET_databases.DataBase;
namespace ASPNET_databases.Controllers
{
    public class CartController : Controller
    {
        private readonly ShopDbContext context;
        private readonly IMapper mapper;

        public CartController(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            var items = HttpContext.Session.Get<Dictionary<int, int>>(WebConstants.CART_KEY);
            if (items == null) items = new Dictionary<int, int>();

            var entities = context.Tanks
                                    .Include(x => x.Class)
                                    .Where(x => items.Keys.Contains(x.Id))
                                    .ToList();

            var list = mapper.Map<List<TankCartModel>>(entities);

            foreach (var i in list)
            {
                i.CountToBuy = items[i.Id];
            }

            return View(list);
        }
        public IActionResult Append(int id, int count = 1)
        {
            var items = HttpContext.Session.Get<Dictionary<int, int>>(WebConstants.CART_KEY);

            if (items == null) items = new Dictionary<int, int>();

            if (items.ContainsKey(id)) items[id] += count;
            else items.Add(id, count);

            HttpContext.Session.Set(WebConstants.CART_KEY, items);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Remove(int id)
        {
            var items = HttpContext.Session.Get<Dictionary<int, int>>(WebConstants.CART_KEY);
            if (items == null) return NotFound();

            items.Remove(id);

            HttpContext.Session.Set(WebConstants.CART_KEY, items);

            return RedirectToAction("Index");
        }

        public IActionResult Clear()
        {
            HttpContext.Session.Remove(WebConstants.CART_KEY);

            return RedirectToAction("Index");
        }
    }
}
