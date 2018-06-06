using CORE.JGC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CORE.JGC.Controllers
{
    
    public class UtilizationController : Controller
    {
        BFASTDataContext dc = null;
        public ActionResult Menu()
        {

            UtilMenu[] utilMenu = null;
            utilMenu = GridMenu();
            return View(utilMenu);
        }

        public ActionResult Createmenu()
        {
            return View();
        }

        public ActionResult Updatemenu()
        {
            return View();
        }

        public ActionResult Role()
        {
            UtilGroupMenu[] utilGroupMenu = null;
            utilGroupMenu = GridGroupMenu();
            return View(utilGroupMenu);
        }

        public ActionResult Createrole()
        {
            return View();
        }

        public ActionResult Updaterole()
        {
            return View();
        }

        public ActionResult Access()
        {
            return View();
        }

        public ActionResult Users()
        {
           
            MsUsers[] msUsers = null;
            msUsers = GridUsers();
            return View(msUsers);
        }
    
        [HttpPost]
        public MsUsers[] GridUsers()
        {
            dc = new BFASTDataContext();
            List<MsUsers> msUsers = new List<MsUsers>();
            try
            {
                var query = dc.UtilUser_View("", "G");
                foreach (var res in query)
                {
                    MsUsers user = new MsUsers();

                    user.UserName = res.UserName;
                    user.Email = res.Email;
                    user.Name = res.Name;
                    user.Address = res.Address;
                    user.Phone = res.Phone;
                    user.CompanyName = res.CompanyName;
                    user.DeptName = res.DeptName;
                    user.LocationName = res.LocationName;
                    user.GroupAccessCode = res.GroupAccessCode;

                    msUsers.Add(user);
                }
            }
            catch
            {
                msUsers = null;
            }
            return msUsers.ToArray();
        }
        [HttpPost]
        public UtilMenu[] GridMenu()
        {
            dc = new BFASTDataContext();
            List<UtilMenu> utilMenu = new List<UtilMenu>();
            try
            {
                var query = dc.UtilMenu_View("", "G");
                foreach (var res in query)
                {
                    UtilMenu menu = new UtilMenu();

                    menu.MenuCode = res.MenuCode;
                    menu.MenuName = res.MenuName;
                    menu.MenuPath = res.MenuPath;
                    menu.LevelMenu   = res.LevelMenu;
                    menu.ParentMenu = res.ParentMenu;
                    utilMenu.Add(menu);
                }
            }
            catch
            {
                utilMenu = null;
            }
            return utilMenu.ToArray();
        }

        [HttpPost]
        public UtilGroupMenu[] GridGroupMenu()
        {
            dc = new BFASTDataContext();
            List<UtilGroupMenu> utilGroupMenu = new List<UtilGroupMenu>();
            try
            {
                var query = dc.UtilGroupMenu_View("", "G");
                foreach (var res in query)
                {
                    UtilGroupMenu groupmenu = new UtilGroupMenu();

                    groupmenu.GroupMenuCode = res.GroupMenuCode;
                    groupmenu.GroupMenuName = res.GroupMenuName;
                    utilGroupMenu.Add(groupmenu);
                }
            }
            catch
            {
                utilGroupMenu = null;
            }
            return utilGroupMenu.ToArray();
        }
    }
}
