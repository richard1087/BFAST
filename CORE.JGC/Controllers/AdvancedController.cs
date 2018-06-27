using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CORE.JGC.Controllers
{
    [SessionTimeoutAttribute]
    public class AdvancedController : Controller
    {
        // GET: Advanced
        public ActionResult Persons()
        {
            return View();
        }

        public ActionResult Customers()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        public ActionResult Createusers()
        {
            return View();
        }

        public ActionResult Securitygroups()
        {
            return View();
        }
    }
}