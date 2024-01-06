using ElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class InstructorAnalysController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            ViewBag.sayfa = "Profilim";
            ViewBag.aciklama = "Profil İncele";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            return View();
        }
        public PartialViewResult PartialInstructorPanel()
        {
            int id = 1;
            var values = context.Instructors.Where(x => x.InstructorID == id).ToList();
            var v1 = context.Instructors.Where
                (x => x.Name == "Mesut" && x.Surname == "Yücedağ").Select(y => y.InstructorID).FirstOrDefault();
            ViewBag.coursecount = context.Courses.Where(x => x.InstructorId == id).Count();
            var v2 = context.Courses.Where
                (x => x.CourseId == v1).Select(y => y.CourseId).ToList();

            ViewBag.corusecomment = context.Comments.Where
                (x => v2.Contains(x.CourseID)).Count();
            return PartialView(values);
        }
        public PartialViewResult PartialComment()
        {
            var v1 = context.Instructors.Where
                (x => x.Name == "Mesut" && x.Surname == "Yücedağ").Select(y => y.InstructorID).FirstOrDefault();

            var v2 = context.Courses.Where
                (x => x.CourseId == v1).Select(y => y.CourseId).ToList();

            var v3 = context.Comments.Where
                (x => v2.Contains(x.CourseID)).ToList();

            return PartialView(v3);
        }
        public PartialViewResult CourseListByInstructor()
        {
            var v1 = context.Courses.Where(x => x.InstructorId == 1).ToList();

            return PartialView(v1);

        }


    }
}