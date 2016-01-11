using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Helpers;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class BranchController : Controller
    {
        //
        // GET: /Branch/

        public ActionResult Index()
        {
            return View("Branches",BranchHelper.GetAllBranches);
        }

        //
        // GET: /Branch/Details/5

		//public ActionResult Details(int id)
		//{
		//	return View();
		//}

        //
        // GET: /Branch/Create

	    public ActionResult Add(Guid? id)
	    {
		    if (!id.HasValue)
			    return PartialView("Branch");

		    var branch = BranchHelper.GetAllBranches.Where(b => b.ID == id).Select(i => i).FirstOrDefault();
		    return PartialView("Branch", branch);
	    }

	    //
        // POST: /Branch/Create

        [HttpPost]
        public ActionResult Add(Branch branch)
        {
            try
            {
	            if (ModelState.IsValid)
	            {
		            if (!branch.ID.HasValue)
			            branch.ID = CommonHelper.NewGuid;
					BranchHelper.AddBranch(branch);
	            }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
				ModelState.AddModelError("",ex.Message);
                return View("Branches");
            }
        }

	    public ActionResult Branch(Guid id)
	    {
			return PartialView("Branch");
	    }
        //
        // GET: /Branch/Edit/5

		//public ActionResult Edit(int id)
		//{
		//	return View();
		//}

        //
        // POST: /Branch/Edit/5

		//[HttpPost]
		//public ActionResult Edit(int id, FormCollection collection)
		//{
		//	try
		//	{
		//		// TODO: Add update logic here

		//		return RedirectToAction("Index");
		//	}
		//	catch
		//	{
		//		return View();
		//	}
		//}

        //
        // GET: /Branch/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Branch/Delete/5

        [HttpPost]
        public ActionResult Delete(Guid id,string name)
        {
            try
            {
                BranchHelper.DeleteBranch(id);
                //return RedirectToAction("Index");
				return Json(new { message = "success", ID = id,Name=name }, JsonRequestBehavior.AllowGet);
            }
            catch
            {
				ModelState.AddModelError("","Technical Error Occured");
	            return RedirectToAction("Index");
            }
        }
    }
}
