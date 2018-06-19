using CORE.JGC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CORE.JGC.Controllers
{
    [SessionTimeoutAttribute]

    public class UtilizationController : Controller
    {
        List<UtilMenu> utilMenuList;

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
            if (TempData.ContainsKey("MenuCode"))
                Session["MenuCodeS"] = TempData["MenuCode"].ToString();

            dc = new BFASTDataContext();
            List<UtilMenu> utilmenu = new List<UtilMenu>();
            try
            {
                var query = dc.UtilMenu_View( Session["MenuCode"].ToString(), "G");
                foreach (var res in query)
                {
                    UtilMenu menu = new UtilMenu();

                    ViewData["MenuCode"] =  res.MenuCode.ToString().Trim();
                    ViewData["MenuName"] = res.MenuName.ToString().Trim();
                    ViewData["MenuPath"] = res.MenuPath.ToString();
                    ViewData["LevelMenu"] = res.LevelMenu.ToString().Trim();
                    ViewData["ParentMenu"] = res.ParentMenu.ToString();

                    utilmenu.Add(menu);
                }
            }
            catch
            {
                utilmenu = null;
            }
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
        public ActionResult GetUpdateMenu(string MenuCode)
        {
            TempData["MenuCode"] = MenuCode;
            return View("Update");
        }

        public UtilMenu[] GridPopupParentMenu(string LevelMenu)
        {
            dc = new BFASTDataContext();
            List<UtilMenu> utilMenu = new List<UtilMenu>();
            try
            {
                var query = dc.Pop_MenuParent(LevelMenu);
                foreach (var res in query)
                {
                    UtilMenu menu = new UtilMenu();

                    menu.MenuCode = res.MenuCode;
                    menu.MenuName = res.MenuName;

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
        public ActionResult SaveMenu(string MenuCode, string MenuName, string MenuPath, int LevelMenu, string ParentMenu)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    
                    string UserID = Session["UserName"].ToString().Trim();
                    //CompleteDateC = null;

                    var query = dc.UtilMenu_IUD(MenuCode, MenuName, MenuPath, LevelMenu, ParentMenu, UserID, 1);
                    string status = "";
                    foreach (var res in query)
                    {
                        status = res.Status;
                    }

                    if (status.Trim().Substring(0, 4) == "Err ")
                    {
                        return Json(new { success = false, responseText = status.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = true, responseText = status.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { success = false, responseText = ex.ToString().Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, responseText = ex.Message.ToString().Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
            }
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
        [HttpPost]
        public JsonResult GetPopupParentMenu(string LevelMenu)
        {
            UtilMenu[] um = null;
            um = GridPopupParentMenu(LevelMenu);

            return Json(new
            {
                data = um.Select(x => new[] { x.MenuCode, x.MenuName })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
