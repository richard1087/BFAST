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
                        }

                        if (Hasil.Jumlah > 0)
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
                            ViewBag.Error = "1";
                        }
                        
                        return View();
                    }
                }
                
            }
        }
    }    


