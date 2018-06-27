using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CORE.JGC.Controllers
{
    [SessionTimeoutAttribute]
    public class AlertsController : Controller
    {
        // GET: Alerts
        public ActionResult Assetpastdue()
        {
            return View();
        }

        public ActionResult Leasesexpiring()
        {
            return View();
        }

        public ActionResult Maintenancedue()
        {
            return View();
        }

        public ActionResult Warrantiesexpiring()
        {
            return View();
        }
    }
}