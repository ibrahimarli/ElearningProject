using ElearningProject.DAL.Context;
using ElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class TestimonialController : Controller
    {
        ElearningContext context = new ElearningContext();
        public ActionResult Index()
        {
            ViewBag.sayfa = "Referanslar";
            ViewBag.description = "Referans Listesi";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.description;
            var values = context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            ViewBag.sayfa = "Referanslar";
            ViewBag.description = "Referans Ekleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.description;
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            ViewBag.sayfa = "Referanslar";
            ViewBag.description = "Referans Güncelleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.description;
            var value = context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var values = context.Testimonials.Find(testimonial.TestimonialId);
            values.NameSurname = testimonial.NameSurname;
            values.Title = testimonial.Title;
            values.ImageUrl = testimonial.ImageUrl;
            values.Comment = testimonial.Comment;
            values.Status = testimonial.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}