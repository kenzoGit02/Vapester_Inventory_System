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
    public class CrudImplementation
    {

        public List<CrudProp> GetEmp()
        {
            List<CrudProp> emplist = new List<CrudProp>();
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from tbl_product";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(new CrudProp
                {
                    prod_Id = Convert.ToInt32(dr["prod_Id"]),
                    prod_Name = Convert.ToString(dr["prod_Name"]),
                    prod_Stock = Convert.ToInt32(dr["prod_Stock"]),
                    prod_Type = Convert.ToString(dr["prod_Type"]),
                    prod_Variant = Convert.ToString(dr["prod_Variant"])
                });
            }


            return emplist;

        }

        public bool insertemp(CrudProp empinsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into tbl_product (prod_Name, prod_Stock, prod_Type, prod_Variant)  values ('" + empinsert.prod_Name + "','" + empinsert.prod_Stock + "','" + empinsert.prod_Type + "','" + empinsert.prod_Variant + "')";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool editemp(CrudProp empedit)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "update tbl_product set prod_Name='" + empedit.prod_Name + "' where prod_Id='" + empedit.prod_Id + "' ";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteemp(int id)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "Delete from tbl_product where prod_Id=" + id;
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            int i = sqlcomm.ExecuteNonQuery();
            mysqlconn.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}