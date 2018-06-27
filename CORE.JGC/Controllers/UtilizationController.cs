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

        //Buat Update
        [HttpPost]
        public ActionResult UpdateDataMenu(string MenuCode)
        {
            Session["MenuCode"] = MenuCode;

            dc = new BFASTDataContext();
            List<UtilMenu> utilMenu = new List<UtilMenu>();
            try
            {
                var query = dc.UtilMenu_View(Session["MenuCode"].ToString(), "U");
                foreach (var res in query)
                {

                    ViewData["MenuCode"] = res.MenuCode.ToString().Trim();
                    ViewData["MenuName"] = res.MenuName.ToString().Trim();
                    ViewData["MenuPath"] = res.MenuPath.ToString();
                    ViewData["LevelMenu"] = res.LevelMenu.ToString();
                    ViewData["ParentMenu"] = res.ParentMenu.ToString();

                }
            }
            catch (Exception ex)
            {
                utilMenu = null;
            }
            return View("Updatemenu");
        }
        [HttpPost]
        public ActionResult UpdateDataRole(string GroupMenuCode)
        {
            Session["GroupMenuCode"] = GroupMenuCode;

            dc = new BFASTDataContext();
            List<UtilGroupMenu> utilMenu = new List<UtilGroupMenu>();
            try
            {
                var query = dc.UtilGroupMenu_View(Session["GroupMenuCode"].ToString(), "U");
                foreach (var res in query)
                {

                    ViewData["GroupMenuCode"] = res.GroupMenuCode.ToString().Trim();
                    ViewData["GroupMenuName"] = res.GroupMenuName.ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                utilMenu = null;
            }
            return View("Updaterole");
        }
        [HttpPost]
        public ActionResult UpdateDataUser(string UserName)
        {
            Session["UserName"] = UserName;

            dc = new BFASTDataContext();
            List<MsUsers> msUser = new List<MsUsers>();
            try
            {
                var query = dc.UtilUser_View(Session["UserName"].ToString(), "U");
                foreach (var res in query)
                {
                    ViewData["GroupMenuCode"] = res.GroupMenuCode.ToString().Trim();
                    ViewData["GroupMenuName"] = res.GroupMenuName.ToString().Trim();
                    ViewData["UserName"] = res.UserName.ToString().Trim();
                    ViewData["Email"] = res.Email.ToString().Trim();
                    ViewData["Name"] = res.Name.ToString();
                    ViewData["Address"] = res.Address.ToString();
                    ViewData["Phone"] = res.Phone.ToString();
                    ViewData["CompanyID"] = res.CompanyID.ToString().Trim();
                    ViewData["CompanyName"] = res.CompanyName.ToString();
                    ViewData["DeptCode"] = res.DeptCode.ToString().Trim();
                    ViewData["DeptName"] = res.DeptName.ToString().Trim();
                    ViewData["SiteCode"] = res.SiteCode.ToString().Trim();
                    ViewData["SiteName"] = res.SiteName.ToString().Trim();
                    ViewData["LocationCode"] = res.LocationCode.ToString().Trim();
                    ViewData["LocationName"] = res.LocationName.ToString().Trim();
                    ViewData["Floor"] = res.Floor.ToString();

                }
            }
            catch (Exception ex)
            {
                msUser = null;
            }
            return View("Updateuser");
        }

        [HttpPost]
        public ActionResult UpdateDataUser(string UserName)
        {
            Session["UserName"] = UserName;

            dc = new BFASTDataContext();
            List<MsUsers> users = new List<MsUsers>();
            try
            {
                var query = dc.UtilUser_View(Session["UserName"].ToString(), "U");
                foreach (var res in query)
                {

                    ViewData["UserName"] = res.UserName.ToString().Trim();
                    ViewData["Email"] = res.Email.ToString().Trim();
                    ViewData["Name"] = res.Email.ToString().Trim();
                    ViewData["Address"] = res.Address.ToString().Trim();
                    ViewData["Phone"] = res.Phone.ToString().Trim();
                    ViewData["CompanyID"] = res.CompanyID.ToString().Trim();
                    ViewData["CompanyName"] = res.CompanyName.ToString().Trim();
                    ViewData["DeptCode"] = res.DeptCode.ToString().Trim();
                    ViewData["DeptName"] = res.DeptName.ToString().Trim();
                    ViewData["LocationCode"] = res.LocationCode.ToString().Trim();
                    ViewData["LocationName"] = res.LocationName.ToString().Trim();
                    ViewData["bManager"] = res.bManager.ToString().Trim();
                    ViewData["bLogin"] = res.bLogin.ToString().Trim();
                    ViewData["bActive"] = res.bActive.ToString().Trim();
                    ViewData["GroupAccessCode"] = res.GroupAccessCode.ToString().Trim();
                    ViewData["LoginDate"] = res.LoginDate.ToString().Trim();
                    ViewData["LogOutDate"] = res.LogOutDate.ToString().Trim();
                    ViewData["Iby"] = res.Iby.ToString().Trim();
                    ViewData["Ion"] = res.Ion.ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                users = null;
            }
            return View("Updateuser");
        }

        public ActionResult Updatemenu()
        {
            dc = new BFASTDataContext();
            List<UtilMenu> utilMenu = new List<UtilMenu>();
            try
            {
                var query = dc.UtilMenu_View(Session["MenuCode"].ToString(), "U");
                foreach (var res in query)
                {

                    ViewData["MenuCode"] = res.MenuCode.ToString().Trim();
                    ViewData["MenuName"] = res.MenuName.ToString().Trim();
                    ViewData["MenuPath"] = res.MenuPath.ToString();
                    ViewData["LevelMenu"] = res.LevelMenu.ToString();
                    ViewData["ParentMenu"] = res.ParentMenu.ToString();
                }
            }
            catch (Exception ex)
            {
                utilMenu = null;
            }

            return View();
        }
        public ActionResult Updaterole()
        {
            dc = new BFASTDataContext();
            List<UtilGroupMenu> utilMenu = new List<UtilGroupMenu>();
            try
            {
                var query = dc.UtilGroupMenu_View(Session["GroupMenuCode"].ToString(), "U");
                foreach (var res in query)
                {

                    ViewData["GroupMenuCode"] = res.GroupMenuCode.ToString().Trim();
                    ViewData["GroupMenuName"] = res.GroupMenuName.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                utilMenu = null;
            }

            return View();
        }
        public ActionResult UpdateUser()
        {
            dc = new BFASTDataContext();
            List<MsUsers> msUser = new List<MsUsers>();
            try
            {
                var query = dc.UtilUser_View(Session["UserName"].ToString(), "U");
                foreach (var res in query)
                {

                    ViewData["GroupMenuCode"] = res.GroupMenuCode.ToString().Trim();
                    ViewData["GroupMenuName"] = res.GroupMenuName.ToString().Trim();
                    ViewData["UserName"] = res.UserName.ToString().Trim();
                    ViewData["Email"] = res.Email.ToString().Trim();
                    ViewData["Name"] = res.Name.ToString();
                    ViewData["Address"] = res.Address.ToString();
                    ViewData["Phone"] = res.Phone.ToString();
                    ViewData["CompanyID"] = res.CompanyID.ToString().Trim();
                    ViewData["CompanyName"] = res.CompanyName.ToString();
                    ViewData["DeptCode"] = res.DeptCode.ToString().Trim();
                    ViewData["DeptName"] = res.DeptName.ToString().Trim();
                    ViewData["SiteCode"] = res.SiteCode.ToString().Trim();
                    ViewData["SiteName"] = res.SiteName.ToString().Trim();
                    ViewData["LocationCode"] = res.LocationCode.ToString().Trim();
                    ViewData["LocationName"] = res.LocationName.ToString().Trim();
                    ViewData["Floor"] = res.Floor.ToString();
                }
            }
            catch (Exception ex)
            {
                msUser = null;
            }

            return View();
        }

        public ActionResult Updateuser()
        {
            dc = new BFASTDataContext();
            List<MsUsers> user = new List<MsUsers>();
            try
            {
                var query = dc.UtilUser_View(Session["UserName"].ToString(), "U");
                foreach (var res in query)
                {

                    ViewData["UserName"] = res.UserName.ToString().Trim();
                    ViewData["Email"] = res.Email.ToString().Trim();
                    ViewData["Name"] = res.Name.ToString().Trim();
                    ViewData["Address"] = res.Address.ToString().Trim();
                    ViewData["Phone"] = res.Phone.ToString().Trim();
                    ViewData["CompanyID"] = res.CompanyID.ToString().Trim();
                    ViewData["CompanyName"] = res.CompanyName.ToString().Trim();
                    ViewData["DeptCode"] = res.DeptCode.ToString().Trim();
                    ViewData["DeptName"] = res.DeptName.ToString().Trim();
                    ViewData["LocationCode"] = res.LocationCode.ToString().Trim();
                    ViewData["LocationName"] = res.LocationName.ToString().Trim();
                    ViewData["bManager"] = res.bManager.ToString().Trim();
                    ViewData["bLogin"] = res.bLogin.ToString().Trim();
                    ViewData["bActive"] = res.bActive.ToString().Trim();
                    ViewData["GroupAccessCode"] = res.GroupAccessCode.ToString().Trim();
                    ViewData["LoginDate"] = res.LoginDate.ToString().Trim();
                    ViewData["LogOutDate"] = res.LogOutDate.ToString().Trim();
                    ViewData["Iby"] = res.Iby.ToString().Trim();
                    ViewData["Ion"] = res.Ion.ToString().Trim();
                }
            }
            catch (Exception ex)
            {
                user = null;
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
        public ActionResult Createusers()
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

        public UtilGroupMenu[] GridPopupGroupMenu()
        {
            dc = new BFASTDataContext();
            List<UtilGroupMenu> utilGMenu = new List<UtilGroupMenu>();
            try
            {
                var query = dc.UtilGroupMenu_View("", "G");
                foreach (var res in query)
                {
                    UtilGroupMenu gMenu = new UtilGroupMenu();

                    gMenu.GroupMenuCode = res.GroupMenuCode;
                    gMenu.GroupMenuName = res.GroupMenuName;

                    utilGMenu.Add(gMenu);
                }
            }
            catch
            {
                utilGMenu = null;
            }
            return utilGMenu.ToArray();
        }
        public MsCompany[] GridPopupCompany()
        {
            dc = new BFASTDataContext();
            List<MsCompany> msCompany = new List<MsCompany>();
            try
            {
                var query = dc.MsCompany_View("", "G");
                foreach (var res in query)
                {
                    MsCompany company = new MsCompany();

                    company.CompanyID = res.CompanyID;
                    company.CompanyCode = res.CompanyCode;
                    company.CompanyName = res.CompanyName;

                    msCompany.Add(company);
                }
            }
            catch
            {
                msCompany = null;
            }
            return msCompany.ToArray();
        }
        public MsDepartment[] GridPopupDept()
        {
            dc = new BFASTDataContext();
            List<MsDepartment> msDept = new List<MsDepartment>();
            try
            {
                var query = dc.MsDepartment_View("", "G");
                foreach (var res in query)
                {
                    MsDepartment dept = new MsDepartment();

                    dept.DeptCode = res.DeptCode;
                    dept.DeptName = res.DeptName;

                    msDept.Add(dept);
                }
            }
            catch
            {
                msDept = null;
            }
            return msDept.ToArray();
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
        public ActionResult SaveRole(string GroupMenuCode, string GroupMenuName)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {

                    string UserID = Session["UserName"].ToString().Trim();
                    //CompleteDateC = null;

                    var query = dc.UtilGroupMenu_IUD(GroupMenuCode, GroupMenuName, UserID, 1);
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
        public ActionResult SaveUser(string GroupMenuCode, string UserNameS, string PasswordS, string Name, string Email, string Address, string Phone, string CompanyID, string DeptCode, string SiteCode, string LocationCode, int Floor)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {

                    string UserID = Session["UserName"].ToString().Trim();
                    //CompleteDateC = null;

                    var query = dc.UtilUser_IUD(UserNameS, PasswordS, Name, Email, Address, Phone, CompanyID, DeptCode, SiteCode, LocationCode, Floor, GroupMenuCode, 1, 0, UserID, 1);
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
        public ActionResult SaveUpdateMenu(string MenuCode, string MenuName, string MenuPath, int LevelMenu, string ParentMenu)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {

                    string UserID = Session["UserName"].ToString().Trim();
                    //CompleteDateC = null;

                    var query = dc.UtilMenu_IUD(MenuCode, MenuName, MenuPath, LevelMenu, ParentMenu, UserID, 2);
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
        public ActionResult SaveUpdateRole(string GroupMenuCode, string GroupMenuName)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {

                    string UserID = Session["UserName"].ToString().Trim();
                    //CompleteDateC = null;

                    var query = dc.UtilGroupMenu_IUD(GroupMenuCode, GroupMenuName, UserID, 2);
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
<<<<<<< HEAD
        public ActionResult SaveUpdateUser(string GroupMenuCode, string UserNameS, string PasswordS, string Name, string Email, string Address, string Phone, string CompanyID, string DeptCode, string SiteCode, string LocationCode, int Floor)
=======
        public ActionResult SaveUpdateUser(string UserName, string Password, string Name, string Email, string Address, string Phone, string CompanyID, string DeptCode, string SiteCode, string LocationCode, int Floor, string GroupAccessCode, int bActive, int bManager, string UserID)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {

                    string UserNameUpdate = Session["UserName"].ToString().Trim();
                    //CompleteDateC = null;

                    var query = dc.UtilUser_IUD(UserNameUpdate, Password, Name, Email, Address, Phone, CompanyID, DeptCode, SiteCode, LocationCode, Floor, GroupAccessCode, bActive, bManager, UserID, 2);
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
        public ActionResult SaveUpdateUser(string GroupMenuCode, string UserNameS, string PasswordS, string Name, string Email, string Address, string Phone, string CompanyID, string DeptCode, string SiteCode, string LocationCode, int Floor, int bActive)
>>>>>>> 9cdc076d7eb91d446d1f9a4e62ab4e78e65d2e5c
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {

                    string UserID = Session["UserName"].ToString().Trim();
                    //CompleteDateC = null;

                    var query = dc.UtilUser_IUD(UserNameS, PasswordS, Name, Email, Address, Phone, CompanyID, DeptCode, SiteCode, LocationCode, Floor, GroupMenuCode, 1, 0, UserID, 2);
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
                    user.GroupMenuCode = res.GroupAccessCode;

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
                    menu.LevelMenu = res.LevelMenu;
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
        [HttpPost]
        public JsonResult GetPopupGroupMenu()
        {
            UtilGroupMenu[] um = null;
            um = GridPopupGroupMenu();

            return Json(new
            {
                data = um.Select(x => new[] { x.GroupMenuCode, x.GroupMenuName })
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPopupCompany()
        {
            MsCompany[] um = null;
            um = GridPopupCompany();

            return Json(new
            {
                data = um.Select(x => new[] { x.CompanyID, x.CompanyCode, x.CompanyName })
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPopupDept()
        {
            MsDepartment[] um = null;
            um = GridPopupDept();

            return Json(new
            {
                data = um.Select(x => new[] { x.DeptCode, x.DeptName })
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
