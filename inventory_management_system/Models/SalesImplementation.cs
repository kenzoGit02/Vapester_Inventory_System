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
    public class SalesImplementation
    {
        public List<SalesProp> GetSales()
        {
            List<SalesProp> salelist = new List<SalesProp>();
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select year(date),month(date),sum(quantity) from tbl_order_history group by year(date),month(date) order by year(date),month(date)";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                salelist.Add(new SalesProp
                {
                    quantity = Convert.ToInt32(dr["sum(quantity)"]),
                    year = Convert.ToInt32(dr["year(date)"]),
                    month = Convert.ToInt32(dr["month(date)"])

                });
            }
            //DataTable table = new DataTable();
            //foreach (DataRow row in table.Rows)
            //{
            //    foreach (DataColumn col in table.Columns)
            //    {
            //        object value = row[col.ColumnName];
            //    }
            //}


            return salelist;

        }
    }
}