using ElearningProject.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class DefaultController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
        public PartialViewResult PartialSpinner()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }
        public PartialViewResult PartialCarousel()
        {
            return PartialView();
        }
        public PartialViewResult PartialService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAboutStart()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialCategories()
        {

            var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialCourse() 
        {
            var values = context.Courses.Take(3).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialInstructors() 
        {
            var values = context.Instructors.Take(4).ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial() 
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialFooter() 
        {
            var values = context.Contacts.ToList();
            return PartialView(values);
        }
    }
}