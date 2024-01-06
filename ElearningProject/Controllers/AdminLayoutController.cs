using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElearningProject.Controllers
{
    public class AdminLayoutController : Controller
    {
        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialHead()
        {
            return View();
        } 
        public ActionResult PartialSidebar()
        {
            return View();
        }  
        public ActionResult PartialScript()
        {
            return View();
        }
        public ActionResult PartialNavbar()
        {
            return View();
        }
        public ActionResult PartialRowPageTitle() 
        {
            return View();
        }
        public ActionResult PartialPreloader() 
        {
            return View();
        }
        public ActionResult PartialFooter() 
        {
            return View();
        }
    }
}