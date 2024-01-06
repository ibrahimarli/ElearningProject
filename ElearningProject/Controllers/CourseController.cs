using ElearningProject.DAL.Context;
using ElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class CourseController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            ViewBag.sayfa = "Kurslar";
            ViewBag.aciklama = "Kurs Listesi";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            var values = context.Courses.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCourse()
        {
            ViewBag.sayfa = "Kurslar";
            ViewBag.aciklama = "Kurs Ekleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;

            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.v = categories;
            List<SelectListItem> instructors = (from x in context.Instructors.ToList().OrderBy(z => z.Name)
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.InstructorID.ToString()
                                                }).ToList();
            ViewBag.c = instructors;
            return View();
        }
        [HttpGet]
        public ActionResult UpdateCourse(int id)
        {
            ViewBag.sayfa = "Kurslar";
            ViewBag.aciklama = "Kurs Güncelleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;

            List<SelectListItem> categories = (from x in context.Categories.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryID.ToString()
                                               }).ToList();
            ViewBag.j = categories;
            List<SelectListItem> instructors = (from x in context.Instructors.ToList().OrderBy(z => z.Name)
                                                select new SelectListItem
                                                {
                                                    Text = x.Name + " " + x.Surname,
                                                    Value = x.InstructorID.ToString()
                                                }).ToList();
            ViewBag.z = instructors;
            var value = context.Courses.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCourse(Course course)
        {
            var values = context.Courses.Find(course.CourseId);
            values.Title = course.Title;
            values.Price = course.Price;
            values.Duration = course.Duration;
            values.ImageUrl = course.ImageUrl;
            values.CategoryID = course.CategoryID;
            values.InstructorId = course.InstructorId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult CreateCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCourse(int id)
        {
            var value = context.Courses.Find(id);
            context.Courses.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        
    }
}