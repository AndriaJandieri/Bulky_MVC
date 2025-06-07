using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{


	public class CategoryController : Controller
	{
		private readonly ApplicationDbContext _db;

		public CategoryController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<Category> objCategoryList = _db.Categories.ToList();
			return View(objCategoryList);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Category obj)
		{
			//if (obj.CategoryName == obj.DisplayOrder.ToString())
			//{
			//	ModelState.AddModelError("name", "Category_Name and Display_Name should not be same");
			//}

			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				return RedirectToAction("Index", "Category");
			}
			return View();

		}
	}
}
