using ASPNET_databases.Data.Entities;
using ASPNET_databases.DataBase;
using ASPNET_databases.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ASPNET_databases.Controllers
{
	[Authorize(Roles = Roles.ADMIN)]
	public class TankController : Controller
    {
        private ShopDbContext context;
        private readonly IMapper mapper;


        public TankController(ShopDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(TankController));
        }

        public IActionResult Index()
        {
            // get products from db
            // .Include() - LEFT JOIN
            var products = context.Tanks.Include(x => x.Class).ToList();

            LoadCategories();

            return View(products);
        }

        public IActionResult Filter(int? categoryId)
        {
            if (categoryId == null)
                return RedirectToAction("Index");

            var tanks = context.Tanks
                            .Include(x => x.Class)
                            .Where(x => x.ClassId == categoryId)
                            .ToList();

            LoadCategories();
            return View("Index", tanks);
        }

        [HttpGet] // by default
        public IActionResult Create()
        {
            // ViewBag - transfer data from action to view
            ViewBag.Creation = true;
            LoadCategories();

            return View("Upsert");
        }

        [HttpPost]
        public IActionResult Create(TankFormModel model)
        {
            if (!ModelState.IsValid)
            {
                LoadCategories();
                ViewBag.Creation = true;
                return View("Upsert", model);
            }

            //var entity = new Product()
            //{
            //    Name = model.Name,
            //    CategoryId = model.CategoryId,
            //    Description = model.Description,
            //    Discount = model.Discount,
            //    ImageUrl = model.ImageUrl,
            //    InStock = model.InStock,
            //    Price = model.Price
            //};
            var entity = mapper.Map<Tank>(model);

            context.Tanks.Add(entity);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var item = context.Tanks.Find(id);
            if (item == null) return NotFound();

            ViewBag.Creation = false;
            LoadCategories();

            var model = mapper.Map<TankFormModel>(item);

            return View("Upsert", model);
        }

        [HttpPost]
        public IActionResult Edit(TankFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Creation = false;
                LoadCategories();
                return View("Upsert", model);
            }

            var entity = mapper.Map<Tank>(model);

            context.Tanks.Update(entity);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var item = context.Tanks.Find(id);

            if (item == null) return NotFound();

            context.Tanks.Remove(item);
            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private void LoadCategories()
        {
            var categories = new SelectList(context.Classes.ToList(), nameof(Tank.Id), nameof(Tank.Name));
            ViewBag.Categories = categories;
        }
    }
}
