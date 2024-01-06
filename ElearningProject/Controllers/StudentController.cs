using ElearningProject.DAL.Context;
using ElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class StudentController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            if (context.Students.Count() == 0)
            {
                ViewBag.UyariMesaji = "Listede Ogrenci Yok";
            }
            ViewBag.sayfa = "Öğrenciler";
            ViewBag.aciklama = "Öğrenci Listesi";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            var values = context.Students.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddStudent()
        {
            ViewBag.sayfa = "Öğrenciler";
            ViewBag.aciklama = "Öğrenci Ekleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            context.Students.Add(student);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteStudent(int id)
        {
            var value = context.Students.Find(id);
            context.Students.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            ViewBag.sayfa = "Öğrenciler";
            ViewBag.aciklama = "Öğrenci Güncele";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            var value = context.Students.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateStudent(Student student)
        {
            var values = context.Students.Find(student.StudentId);
            values.Name = student.Name;
            values.Surname = student.Surname;
            values.Email = student.Email;
            values.Password = student.Password;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}