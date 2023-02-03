using System.Text.RegularExpressions;
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
            if (obj.FirstName == obj.Username )
            {
                ModelState.AddModelError("FirstName", "The first name  and username cannot be same.");
            }
            if (!Regex.IsMatch(obj.FirstName + obj.MiddleName + obj.LastName, @"^[a-zA-Z]+$"))
            {
                ModelState.AddModelError("CustomError", "The name field cannot include numbers or special characters");
            } 

            if (ModelState.IsValid)
            {    
                _db.Admin.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View( );
        }

        // GET
        public IActionResult Edit(int? id)
        {
                System.Console.WriteLine(id + "\n\n\n");
            
            if(id == null || id <= 0)
            {
                return NotFound();
            }
            var adminFromDb = _db.Admin.Find(id);

            if (adminFromDb == null)        
            {
                return NotFound();
            }

            return View(adminFromDb);
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Admin obj)
        {

            System.Console.WriteLine(obj.LastName + "\n\n\n");
            if (obj.FirstName == obj.Username )
            {
                ModelState.AddModelError("FirstName", "The first name  and username cannot be same.");
            }
            if (!Regex.IsMatch(obj.FirstName + obj.MiddleName + obj.LastName,@"^[a-zA-Z]+$"))
            {
                ModelState.AddModelError("CustomError", "The name field cannot include numbers or special characters");
            } 

            if (ModelState.IsValid)
            {    
                // obj.Updated = DateTime.Now;
                _db.Admin.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View( );
        }
    }
}