using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public ActionResult OrderedHistory()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }
    }
}