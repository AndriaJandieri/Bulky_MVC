using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
	public class UserController : Controller
	{

		private readonly ApplicationDbContext _db;

		public UserController(ApplicationDbContext db)
		{
			_db = db;
		}
		public IActionResult Index()
		{
			List<User> objUserList = _db.Users.ToList();
			return View(objUserList);
		}
	}
}
