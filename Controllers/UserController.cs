using MVC_CODEFIRST.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CODEFIRST.Controllers
{
    public class UserController : Controller
    {
        DbStudents db = new DbStudents();
        // GET: User
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create( string test)
        {
            string Name = Request.Form["Name"];
            string Email = Request.Form["Email"];
            string Mobile = Request.Form["Mobile"];
            string Adress = Request.Form["Adress"];
            string Course = Request.Form["Course"];

            var e = new Students();
            { 
            e.Name = Name;
                e.Email = Email;
                e.Mobile = Mobile;
                e.Adress = Adress;
                e.Course = Course;
            
            };
            db.students.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int ?id)
        {
            var row = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Students e)
        {
            db.Entry(e).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("index");
        }
        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
                var d = db.students.Where(e => e.Id == id).SingleOrDefault();
                db.students.Remove(d);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View();
        }
    }
}