using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CORE.JGC.Controllers
{
    [SessionTimeoutAttribute]
    public class ToolsController : Controller
    {
        // GET: Tools
        public ActionResult Import()
        {
            return View();
        }

        public ActionResult Export()
        {
            return View();
        }

        public ActionResult Documentsgallery()
        {
            return View();
        }

        public ActionResult Imagegallery()
        {
            return View();
        }

        public ActionResult Audit()
        {
            return View();
        }
    }
}