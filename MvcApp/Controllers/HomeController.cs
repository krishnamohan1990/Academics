using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Win32;

namespace MvcApp.Controllers
{
	[Authorize]
    public class HomeController : Controller
    {
		public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult  Add(string txt1, string txt2)
        {
           ViewBag.Sum= Convert.ToInt16(txt1) +Convert.ToInt16( txt2);
           return View();
        }
    }
}
