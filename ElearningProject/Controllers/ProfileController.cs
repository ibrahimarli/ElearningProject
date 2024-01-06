using ElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class ProfileController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            ViewBag.sayfa = "Öğrenci Paneli";
            ViewBag.aciklama = "Dashboard";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            string value = Session["CurrentMail"].ToString();
            ViewBag.mail = Session["CurrentMail"];
            ViewBag.name = context.Students.Where(x => x.Email == value)
                .Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            return View();
        }
        [HttpGet]
        public ActionResult MyCourseList()
        {
            ViewBag.sayfa = "Öğrenci Paneli";
            ViewBag.aciklama = "Kurslarım";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            string value = Session["CurrentMail"].ToString();
            var id = context.Students.Where(x => x.Email == value).Select(y => y.StudentId).FirstOrDefault();
            var courseList = context.Processes.Where(x => x.StudentID == id).ToList();
            return View(courseList);
        }
    }
}