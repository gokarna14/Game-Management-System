using System.Text.RegularExpressions;
using GameManagementSystem.Data;
using GameManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
// using toaster

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

            var data = _db.Admin.Select(r => r.Username).ToList();

            if (data.Contains(obj.Username))
            {
                ModelState.AddModelError("CustomError", "The username is already taken. Please use a different one.");
            }
            
            
            if (ModelState.IsValid)
            {    
                _db.Admin.Add(obj);
                _db.SaveChanges();
                TempData["successAdmin"] = "New Admin account created successfully";
                return RedirectToAction("Index");
            }
            return View( );
        }

        // GET
        public IActionResult Edit(int? id)
        {
            
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
            // System.Console.WriteLine(obj.AdminId + "pppp\n\n");
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
                TempData["successAdmin"] = "Admin account updated successfully";

                return RedirectToAction("Index");
            }
            return View( );
        }

         // GET
        public IActionResult Delete(int? id)
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
        public IActionResult DeletePOST(int? AdminId)
        {
            var obj = _db.Admin.Find(AdminId);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Admin.Remove(obj);
            _db.SaveChanges();
            TempData["successAdmin"] = "Admin account with Id = " + AdminId + " deleted successfully";

            return RedirectToAction("Index");
        }
    }
}