using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using inventory_management_system.Models;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace inventory_management_system.Controllers
{
    public class Login1Controller : Controller
    {
        // GET: Login1
        public ActionResult Index()
        {
            List<Login> list1 = new List<Login>();
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysql = new MySqlConnection(mainconn);
            string query = "select * from tbl_admin ";
            MySqlCommand comm = new MySqlCommand(query);
            comm.Connection = mysql;
            mysql.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                list1.Add(new Login
                {
                   Email = dr["Email"].ToString(),
                   Password = dr["Password"].ToString(),

                });
            }
            mysql.Close();
            return View(list1);
        }
    }
}