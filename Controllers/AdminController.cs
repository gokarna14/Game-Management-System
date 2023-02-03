using GameManagementSystem.Data;
using GameManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminController(ApplicationDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {

            // var objAdminList = _db.Admin.ToList();

            IEnumerable<Admin> objAdminList = _db.Admin;

            return View(objAdminList);
        }

        // GET
        public IActionResult Create()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin obj)
        {
            _db.Admin.Add(obj);

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}