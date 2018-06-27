using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CORE.JGC.Controllers
{
    [SessionTimeoutAttribute]
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Customreports()
        {
            return View();
        }

        public ActionResult Assetmaintenancedue()
        {
            return View();
        }


        // ASSET REPORT
        public ActionResult Assettag()
        {
            return View();
        }

        public ActionResult Assettagpict()
        {
            return View();
        }

        public ActionResult Assetcategory()
        {
            return View();
        }

        public ActionResult Assetsite()
        {
            return View();
        }

        public ActionResult Assetdepartment()
        {
            return View();
        }

        public ActionResult Assetwarranty()
        {
            return View();
        }

        public ActionResult Assetlinked()
        {
            return View();
        }

        // AUDIT REPORTS
        public ActionResult Auditasset()
        {
            return View();
        }

        public ActionResult Auditdate()
        {
            return View();
        }

        public ActionResult Auditsite()
        {
            return View();
        }

        public ActionResult Nonauditasset()
        {
            return View();
        }

        public ActionResult Locationdiscrepancy()
        {
            return View();
        }

        public ActionResult Auditfunding()
        {
            return View();
        }

        public ActionResult Nonauditfunding()
        {
            return View();
        }

        // CHECKOUT REPORTS
        public ActionResult Checkoutperson()
        {
            return View();
        }

        public ActionResult Checkouttag()
        {
            return View();
        }

        public ActionResult Checkoutduedate()
        {
            return View();
        }

        public ActionResult Checkoutpastdue()
        {
            return View();
        }

        public ActionResult Checkoutsite()
        {
            return View();
        }

        public ActionResult Checkoutintime()
        {
            return View();
        }

        // LEASED REPORTS
        public ActionResult Leasedcustomer()
        {
            return View();
        }

        public ActionResult Leasedtag()
        {
            return View();
        }

        public ActionResult Leasedduedate()
        {
            return View();
        }

        public ActionResult Leasedpastdue()
        {
            return View();
        }

        public ActionResult Leasedintime()
        {
            return View();
        }


        // MAINTENANCE REPORTS
        public ActionResult Maintenancereports()
        {
            return View();
        }

        public ActionResult Statusreports()
        {
            return View();
        }

        public ActionResult Otherreports()
        {
            return View();
        }
    }
}