using ElearningProject.DAL.Context;
using ElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class InstructorController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            ViewBag.sayfa = "Eğitmenler";
            ViewBag.aciklama = "Eğitmen Listesi";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            var values = context.Instructors.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddInstructors() 
        {
            ViewBag.sayfa = "Eğitmenler";
            ViewBag.aciklama = "Eğitmen Ekleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            return View();
        }
        [HttpPost]
        public ActionResult AddInstructors(Instructor ınstructor) 
        {
            context.Instructors.Add(ınstructor);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteInstructor(int id) 
        {
            var values = context.Instructors.Find(id);
            context.Instructors.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateInstructor(int id) 
        {
            ViewBag.sayfa = "Eğitmenler";
            ViewBag.aciklama = "Eğitmen Güncelleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            var value = context.Instructors.Find(id);
            return View(value);
        }
        [HttpPost]
        
        public ActionResult UpdateInstructor(Instructor instructor)
        {
            var value = context.Instructors.Find(instructor.InstructorID);
            value.Name = instructor.Name;
            value.Surname = instructor.Surname;
            value.ImageUrl = instructor.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}