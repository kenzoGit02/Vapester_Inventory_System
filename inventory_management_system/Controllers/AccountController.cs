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
    
    public class AccountController : Controller
    {
        AccountImplementation ai = new AccountImplementation();
        public ActionResult Add()
        {
            ModelState.Clear();
            return View(ai.GetEmp());
        }

        public ActionResult Teller()
        {
            ModelState.Clear();
            return View(ai.GetTeller());
        }

        string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
        MySqlConnection mysqlconn = new MySqlConnection();
        MySqlCommand sqlcomm = new MySqlCommand();
        MySqlDataAdapter mda = new MySqlDataAdapter();
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["username"] != null)
            {   
                return RedirectToAction("OrderedHistory", "Default", new { username = Session["username"].ToString() });
            }
            else
            {
                return View();
            }
            
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            mysqlconn.Open();
            string sqlquery = "select * from tbl_login where username='" + acc.Name + "' and password='" + acc.Password + "'";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            MySqlDataReader dr = sqlcomm.ExecuteReader();

            if (dr.Read())
            {
                mysqlconn.Close();
                Session["username"] = acc.Name;
                return RedirectToAction("OrderedHistory", "Default", new { username = acc.Name });
            }



            else
            {
                mysqlconn.Close();
                return View("Error");
            }

        }
        // GET: Emp/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp/Create
        [HttpPost]
        public ActionResult Create(tellerProp empinsert)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ai.insertemp(empinsert))
                    {
                        ViewBag.message = "Record is successfully saved!";
                        ModelState.Clear();
                    }

                }

                return RedirectToAction("Teller");
            }
            catch
            {
                return View();
            }
        }




        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateAdmin(CreateAdminProp insertadmin)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    if (ai.insertemp(insertadmin))
                    {
                        ViewBag.message = "Record is successfully saved!";
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

    }
}
