using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using inventory_management_system.Models;


namespace inventory_management_system.Models
{
    public class orderhistoryimpelement
    {
        public List<orderhistory> GetOrder()
        {
            List<orderhistory> historylist = new List<orderhistory>();
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from tbl_order_history";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                historylist.Add(new orderhistory
                {
                    Order_ID = Convert.ToInt32(dr["Order_ID"]),
                   quantity = Convert.ToInt32(dr["quantity"]),
                    price = Convert.ToInt32(dr["price"]),
                    prod_ID = Convert.ToInt32(dr["prod_ID"]),
                    date = Convert.ToDateTime(dr["date"])
                 
                });
            }


            return historylist;

        }

        
    }
}