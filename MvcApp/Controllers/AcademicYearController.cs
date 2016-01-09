using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Components;
using MvcApp.Helpers;
using MvcApp.Models;

namespace MvcApp.Controllers
{
	[Authorize]
    public class AcademicYearController : Controller
    {
        //
        // GET: /AcademicYear/
		
        public ActionResult Index()
        {
	        return View();
        }

		// POST: /AcademicYear/Details/5
		//[HttpPost]
		//public ActionResult Details(Guid id)
		//{
		//	var year=YearProgramHelper.GetYears().FirstOrDefault(i => i.ID == id);
		//	return Json(year);
		//}

        //
        // GET: /AcademicYear/All

        public ActionResult ShowYears()
        {
			var years=YearProgramHelper.GetYears();
			return PartialView(years);
        }
		//GET:  /AcademicYear/Create
		//public ActionResult Create()
		//{
		//	return RedirectToAction("Index");
		//}
        //
        // POST: /AcademicYear/Create
        [HttpPost]
        public ActionResult Create(AcademicYear year)
        {
            try
            {
	            if (ModelState.IsValid)
	            {
		            if (year.FromDate < year.ToDate)
		            {
			            if (year.ID != null)
				            YearProgramHelper.UpdateYear(year);
			            else
				            YearProgramHelper.AddYear(year);
						return RedirectToAction("Index");
		            }
		           ModelState.AddModelError("","FromDate should be less than ToDate");
		           return View("Index",year);
	            }
	            return View("Index",year);
            }
            catch
            {
				ModelState.AddModelError("","Technical Error occured");
                return View("Index",year);
            }
        }

        //
        // GET: /AcademicYear/Edit/5

		//public ActionResult Edit(Guid id)
		//{
		//	var years = YearProgramHelper.GetYears();
		//	return View("Index", years.FirstOrDefault(i => i.ID == id));
		//}

        //
        // POST: /AcademicYear/Edit/5

		//[HttpPost]
		//public ActionResult Edit(Guid id, FormCollection collection)
		//{
		//	var years = YearProgramHelper.GetYears();
		//	return View("Index", years.FirstOrDefault(i => i.ID == id));
		//}

		// POST: /AcademicYear/Delete/5

        [HttpPost]
        public JsonResult Delete(Guid id, FormCollection collection)
        {
	        YearProgramHelper.DeleteYear(id);
			return Json(new {message = "success",ID=id}, JsonRequestBehavior.AllowGet);
        }
    }
}
