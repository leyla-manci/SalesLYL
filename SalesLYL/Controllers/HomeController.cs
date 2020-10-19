using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SalesLYL.Models;
using System.Data.SqlClient;
using System.Configuration;

namespace SalesLYL.Controllers
{
    public class HomeController : Controller
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        SqlDataReader dr;
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        void connectionString()
        {

            conn.ConnectionString = ConfigurationManager.ConnectionStrings["dbConnectString"].ConnectionString;
            //conn.ConnectionString = "data source =DESKTOP-8QOL5AE; database=lyl_db_Sales; integrated security=SSPI";

        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            connectionString();
            conn.Open();
            comm.Connection = conn;
            comm.CommandText = " select * from tbl_User where  Name ='" + user.Name + "'   and Password ='" + user.Password + "'";
            dr = comm.ExecuteReader();
            if (dr.Read())
            {
                conn.Close();
                return RedirectToAction("InvoiceList", "Invoice");
            }
            else
            {
                conn.Close();
                return RedirectToAction("Login","Home");
            }

        }
        public ActionResult Invoice()
        {
            return View();
        }

     
    }
}