using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inventory_management_system.Models;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace inventory_management_system.Controllers
{
    public class SalesController : Controller
    {
        SalesImplementation si = new SalesImplementation();
        public ActionResult Index()
        {
            ModelState.Clear();
            return View(si.GetSales());
        }
        string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
        MySqlConnection mysqlconn = new MySqlConnection();
        MySqlCommand sqlcomm = new MySqlCommand();
        MySqlDataAdapter mda = new MySqlDataAdapter();

        // GET: Sales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sales/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Sales/Edit/5
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

        // GET: Sales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sales/Delete/5
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
