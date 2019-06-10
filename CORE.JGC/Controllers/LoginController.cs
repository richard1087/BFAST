using CORE.JGC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CORE.JGC.Controllers
{
    public class LoginController : Controller
    {
        BFASTDataContext dc = null;
        // GET: Login
        public ActionResult Index()
        {

            UserLogin avm = new UserLogin();
            Session.RemoveAll();
            return View("Index", avm);
        }
        [HttpPost]
        public ActionResult Index(string UserName, string Password)
        {
            
            dc = new BFASTDataContext();
            {
                    try
                    {
                        UserLogin Hasil;
                        var query = dc.Get_Login(UserName, Password);
                        Hasil = new UserLogin();
                        foreach (var res in query)
                        {
                            Hasil.Jumlah = res.Jumlah;
                            Hasil.UserName = res.UserName;
                            Hasil.Password = res.Password;
                            Hasil.Name = res.Name;
                            Hasil.Email = res.Email;
                            Hasil.DeptName = res.DeptName;
                            Hasil.LocationName = res.LocationName;
                            Hasil.CompanyName = res.CompanyName;
                            Hasil.GroupAccessCode = res.GroupAccessCode;
                    }

                        if (Hasil.Jumlah > 0 || Hasil.Jumlah == null)
                        {
                            if (Hasil.UserName.Trim() != UserName.Trim() || Hasil.Password.Trim() != Password.Trim())
                            {
                                ViewBag.Error = "0";
                                return View();
                                //user & password tidak sama
                            }

                        else
                            {
                                //berhasil login
                                Session["username"] = Hasil.UserName;
                                Session["name"] = Hasil.Name;
                                Session["dept"] = Hasil.DeptName;
                                Session["location"] = Hasil.LocationName;
                                Session["company"] = Hasil.CompanyName;
                                Session["groupaccescode"] = Hasil.GroupAccessCode;
                                Session["namedept"] = Hasil.Name.ToString() + " - " + Hasil.DeptName.ToString();

                            //TempData["coba"] = "1234";
                            return RedirectToAction("Index", "Dashboard");
                            }
                        
                        }
                        return View();

                    }
                    catch (Exception ex)
                    {
                        if (ex.ToString().ToUpper().Trim().Contains("NULL"))
                        {
                            ViewBag.Error = "0";
                        }
                        
                        return View();
                    }
                }
                
            }
        [HttpPost]
        public ActionResult UpdateDataResetMaster(string oldPassword, string NewPassword, string ConfirmNewPassword)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserName = Session["username"].ToString().Trim();
                    var query = dc.UtilUser_ChangePass(UserName, oldPassword, NewPassword,ConfirmNewPassword, Session["username"].ToString().Trim(), 1);
                    string status = "";
                    foreach (var res in query)
                    {
                        status = res.Status;
                    }

                    if (status.Trim().Substring(0, 4) == "Err ")
                    {
                        return Json(new { success = false, Exception = status.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = true, Exception = status.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                    }

                }
                catch (Exception ex)
                {
                    return Json(new { success = false, Exception = ex.ToString().Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, Exception = ex.Message.ToString().Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
            }
        }
    }

    }    


