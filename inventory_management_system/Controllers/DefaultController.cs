using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace inventory_management_system.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult OrderedHistory(string username)
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
            
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Login", "Account");
        }
    }
}