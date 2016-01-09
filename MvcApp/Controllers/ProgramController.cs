﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApp.Components;
using MvcApp.Helpers;
using MvcApp.Models;

namespace MvcApp.Controllers
{
    public class ProgramController : Controller
    {
        //
        // GET: /Program/

        public ActionResult Index()
        {
            return View("Programs",YearProgramHelper.GetProgramsByUserID(UserData.GetInstance.AdminID));
        }

        //
        // GET: /Program/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Program/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Program/Create

	    [HttpPost]
	    public ActionResult Create(Program program)
	    {
		    try
		    {
			    if (ModelState.IsValid)
			    {
					if(program.ID!=null)
						YearProgramHelper.UpdateProgram(program);
				    program.ID = CommonHelper.NewGuid;
				    YearProgramHelper.AddProgram(program);
			    }
			    else
				    return View("Index", program);
			    return View("Index");
		    }
		    catch
		    {
			    return View();
		    }
	    }

	    //
        // GET: /Program/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Program/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Program/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Program/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}