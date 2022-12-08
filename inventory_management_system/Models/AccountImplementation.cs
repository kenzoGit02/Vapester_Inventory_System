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
    public class AccountImplementation
    {
        public List<Account> GetEmp()
        {
            List<Account> emplist = new List<Account>();
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from tbl_login";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(new Account
                {
                    Name = Convert.ToString(dr["username"]),
                    Password = Convert.ToString(dr["password"]),

                });
            }


            return emplist;

        }

        //teller function
        public List<tellerProp> GetTeller()
        {
            List<tellerProp> emplist = new List<tellerProp>();
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "select * from tbl_teller";
            MySqlCommand sqlcomm = new MySqlCommand(sqlquery, mysqlconn);
            mysqlconn.Open();
            MySqlDataAdapter mda = new MySqlDataAdapter(sqlcomm);
            DataTable dt = new DataTable();
            mda.Fill(dt);
            mysqlconn.Close();

            foreach (DataRow dr in dt.Rows)
            {
                emplist.Add(new tellerProp
                {
                    id = Convert.ToInt32(dr["id"]),
                    email = Convert.ToString(dr["email"]),
                    password = Convert.ToString(dr["password"]),
                    last_name = Convert.ToString(dr["last_name"]),
                    first_name = Convert.ToString(dr["first_name"]),
                    middle_name = Convert.ToString(dr["middle_name"])

                });
            }


            return emplist;

        }

        public bool insertemp(tellerProp empinsert)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["phpMyAdminConnection"].ConnectionString;
            MySqlConnection mysqlconn = new MySqlConnection(mainconn);
            string sqlquery = "insert into tbl_teller (email, password, last_name, first_name, middle_name)  values ('" + empinsert.email + "','" + empinsert.password + "','" + empinsert.last_name + "','" + empinsert.first_name + "','" + empinsert.middle_name + "')";

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