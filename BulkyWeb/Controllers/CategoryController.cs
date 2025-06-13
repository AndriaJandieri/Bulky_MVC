using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using Humanizer;
using System;

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
			if (obj.CategoryName == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("categoryname", "Category_Name and Display_Name should not be same");
			}

			if (ModelState.IsValid)
			{
				_db.Categories.Add(obj);
				_db.SaveChanges();
				TempData["success"] = "Category Created Successfully";
				return RedirectToAction("Index", "Category");
			}
			return View();

		}
		public IActionResult Edit(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
			// Alternatives but Find works only on PrimaryKey
			// Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
			// Category? categoryFromDb2 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		[HttpPost]
		public IActionResult Edit(Category obj)
		{
			//if we use name "CategoryId" and not just "Id"
			//we need to add extra line in Edit.cshtml file 
			//to prevent keeping old version data while editing
			// parameter "CategoryId" becomes 0, and it thinks we need to create new entry

			if (ModelState.IsValid)
			{
				_db.Categories.Update(obj);
				_db.SaveChanges();
				TempData["success"] = "Category Updated Successfully";
				return RedirectToAction("Index", "Category");
			}
			return View();
		}
		public IActionResult Delete(int? id)
		{
			if (id == null || id == 0)
			{
				return NotFound();
			}
			Category? categoryFromDb = _db.Categories.Find(id);
			// Alternatives but Find works only on PrimaryKey
			// Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u => u.CategoryId == id);
			// Category? categoryFromDb2 = _db.Categories.Where(u => u.CategoryId == id).FirstOrDefault();
			if (categoryFromDb == null)
			{
				return NotFound();
			}
			return View(categoryFromDb);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeletePOST(int? id)
		{

			Category? obj = _db.Categories.Find(id);
			if (obj == null)
			{
				return NotFound();
			}

			_db.Categories.Remove(obj);
			_db.SaveChanges();
			TempData["success"] = "Category Deleted Successfully";
			return RedirectToAction("Index", "Category");
		}
	}

}

