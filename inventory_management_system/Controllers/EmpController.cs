using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inventory_management_system.Models;




namespace inventory_management_system.Controllers
{
    public class EmpController : Controller
    {
        CrudImplementation ci = new CrudImplementation();
        public ActionResult Add()
        {
            ModelState.Clear();
            return View(ci.GetEmp());
        }

        // GET: Emp/Details/5
        public ActionResult Details(int id)
        {
            return View(ci.GetEmp().Find(itemodel => itemodel.prod_Id == id));
        }

        // GET: Emp/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(CrudProp empinsert)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ci.insertemp(empinsert))
                    {
                        ViewBag.message = "The Product you record is successfully saved!";
                        ModelState.Clear();
                    }

                }

                return RedirectToAction("Add");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(ci.GetEmp().Find(itemodel => itemodel.prod_Id == id));
        }

        // POST: Emp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CrudProp updateemp)
        {
            try
            {
                // TODO: Add update logic here
                ci.editemp(updateemp);
                return RedirectToAction("Add");
            }
            catch
            {
                return View();
            }
        }

        // GET: Emp/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ci.deleteemp(id);
            return RedirectToAction("Add");
        }

        // POST: Emp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Add");
            }
            catch
            {
                return View();
            }
        }
    }
}