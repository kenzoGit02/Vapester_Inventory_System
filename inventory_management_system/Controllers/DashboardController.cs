using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inventory_management_system.Models;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Web.Security;

namespace inventory_management_system.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        public ActionResult Index(string username)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                ViewBag.username = username;
                return View();
            }
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysql = new MySqlConnection(mainconn);

            //fetching count of teller
            List<TellerCountModel> TellerCount = new List<TellerCountModel>();
            string countTeller = "SELECT count(id) FROM tbl_teller";
            MySqlCommand comm = new MySqlCommand(countTeller, mysql);
            mysql.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                TellerCount.Add(new TellerCountModel
                {
                    tlrCount = Convert.ToInt32(dr["count(id)"])
                });
            }
            mysql.Close();

            //fetching count of product
            List<ProductCountModel> ProdCount = new List<ProductCountModel>();
            string countProduct = "SELECT COUNT(prod_Id) FROM tbl_product";
            MySqlCommand comm2 = new MySqlCommand(countProduct, mysql);
            mysql.Open();
            MySqlDataReader dr2 = comm2.ExecuteReader();
            while (dr2.Read())
            {
                ProdCount.Add(new ProductCountModel
                {
                    prodCount = Convert.ToInt32(dr2["count(prod_Id)"])
                });
            }
            mysql.Close();

            //combined TellerCountModel and ProductCountModel into DashboardModel as the preparedOutput
            DashboardModel preparedOutput = new DashboardModel();
            preparedOutput.DboardTeller = TellerCount;
            preparedOutput.DboardProduct = ProdCount;
            
            return View(preparedOutput);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return RedirectToAction("Login", "Account");
        }

    }
}