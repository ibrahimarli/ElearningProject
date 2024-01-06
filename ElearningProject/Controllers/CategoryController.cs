using ElearningProject.DAL.Context;
using ElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class CategoryController : Controller
    {
        ElearningContext context = new ElearningContext();  
        public ActionResult Index()
        {
            ViewBag.sayfa = "Kategoriler";
            ViewBag.aciklama = "Kategori Listesi";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            var values = context.Categories.ToList();
            return View(values);
        }
        // ADD CATEGORY //
        [HttpGet]
        public ActionResult AddCategory() 
        {
            ViewBag.sayfa = "Kategoriler";
            ViewBag.aciklama = "Kategori Ekleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id) 
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
            ViewBag.sayfa = "Kategoriler";
            ViewBag.aciklama = "Kategori Güncelleme";
            TempData["PageTitle"] = ViewBag.sayfa;
            TempData["PageDescription"] = ViewBag.aciklama;
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category) 
        {
            var value = context.Categories.Find(category.CategoryID);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("Index");
            
        }
        
    }
}