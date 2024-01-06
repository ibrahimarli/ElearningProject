using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class CoursePageController : Controller
    {
        // GET: CoursePage
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialNavbar() 
        {
            return PartialView();
        }
        public PartialViewResult PartialHeaderStart() 
        {
            return PartialView();
        }
    }
}