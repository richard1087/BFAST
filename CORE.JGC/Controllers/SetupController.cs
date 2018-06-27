using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CORE.JGC.Models;
using CORE.JGC.Lib;
using CORE.JGC.POCO;
using System.Drawing;
using System.IO;

namespace CORE.JGC.Controllers
{
    [SessionTimeoutAttribute]
    public class SetupController : Controller
    {
        // Untuk ke data dbml
        //Lokasi
        BFASTDataContext dc = null;
        //string UserId = "ADMIN";

        private MsLocation[] GridLokasi()
        {
            dc = new BFASTDataContext();
            List<MsLocation> mslocation = new List<MsLocation>();
            try
            {
                var query = dc.MsLocation_View("", "", "G");
                foreach (var res in query)
                {
                    string Aktif = "";
                    MsLocation lokasi = new MsLocation();
                    if (res.bActive.ToString() == "True")
                    {
                        Aktif = "Y";
                    }
                    else
                    {
                        Aktif = "T";
                    }
                    lokasi.Id = res.Id;
                    lokasi.LocationCode = res.LocationCode;
                    lokasi.LocationName = res.LocationName;
                    lokasi.SiteCode = res.SiteCode;
                    lokasi.SiteName = res.SiteName;
                    lokasi.Floor = res.Floor;
                    lokasi.bActive = res.bActive;
                    lokasi.Aktif = Aktif;

                    mslocation.Add(lokasi);
                }
            }
            catch
            {
                mslocation = null;
            }
            return mslocation.ToArray();
        }

        //Site
        private MsSite[] GridSite()
        {
            dc = new BFASTDataContext();
            List<MsSite> mssite = new List<MsSite>();
            try
            {
                var query = dc.MsSite_View("", "G");
                foreach (var res in query)
                {
                    string Aktif = "";
                    MsSite site = new MsSite();
                    if (res.bActive.ToString() == "True")
                    {
                        Aktif = "Y";
                    }
                    else
                    {
                        Aktif = "T";
                    }

                    site.Id = res.Id;
                    site.SiteCode = res.SiteCode;
                    site.SiteName = res.SiteName;
                    site.Address = res.Address;
                    site.City = res.City;
                    site.PostalCode = res.PostalCode;
                    site.Telephone = res.Telephone;
                    site.bActive = res.bActive;
                    site.Aktif = Aktif;

                    mssite.Add(site);
                }
            }
            catch
            {
                mssite = null;
            }
            return mssite.ToArray();
        }

        //Barcode
        private MsBarcode[] GridBarcode()
        {
            dc = new BFASTDataContext();
            List<MsBarcode> msbarcode = new List<MsBarcode>();
            try
            {
                var query = dc.MsBarcode_View("", "G");
                foreach (var res in query)
                {
                    string Aktif = "";
                    MsBarcode barcode = new MsBarcode();


                    barcode.Id = res.Id;
                    barcode.BarcodeCode = res.Barcode;
                    barcode.SizeBarcode = res.Size;
                    barcode.TitleBarcode = res.Title;

                    msbarcode.Add(barcode);
                }
            }
            catch
            {
                msbarcode = null;
            }
            return msbarcode.ToArray();
        }

        //Departemen
        //Site
        private MsDepartment[] GridDepartment()
        {
            dc = new BFASTDataContext();
            List<MsDepartment> msdepartment = new List<MsDepartment>();
            try
            {
                var query = dc.MsDepartment_View("", "G");
                foreach (var res in query)
                {
                    MsDepartment department = new MsDepartment();

                    department.Id = res.Id;
                    department.DeptCode = res.DeptCode;
                    department.DeptName = res.DeptName;

                    msdepartment.Add(department);
                }
            }
            catch
            {
                msdepartment = null;
            }
            return msdepartment.ToArray();
        }

        //Departemen
        //Site
        private MsCurrency[] GridCurrency()
        {
            dc = new BFASTDataContext();
            List<MsCurrency> mscurrency = new List<MsCurrency>();
            try
            {
                var query = dc.MsCurrency_View("", "G");
                foreach (var res in query)
                {
                    MsCurrency currency = new MsCurrency();

                    currency.Id = res.Id;
                    currency.CurrencyCode = res.CurrencyCode;
                    currency.CurrencyName = res.CurrencyName;

                    mscurrency.Add(currency);
                }
            }
            catch
            {
                mscurrency = null;
            }
            return mscurrency.ToArray();
        }

        //Brand
        private MsAssetBrand[] GridAssetBrand()
        {
            dc = new BFASTDataContext();
            List<MsAssetBrand> msassetbrand = new List<MsAssetBrand>();
            try
            {
                var query = dc.MsAssetBrand_View("", "G");
                foreach (var res in query)
                {
                    MsAssetBrand assetbrand = new MsAssetBrand();

                    assetbrand.Id = res.Id;
                    assetbrand.BrandCode = res.BrandCode;
                    assetbrand.BrandName = res.BrandName;

                    msassetbrand.Add(assetbrand);
                }
            }
            catch
            {
                msassetbrand = null;
            }
            return msassetbrand.ToArray();
        }

        //Type
        private MsAssetType[] GridAssetType()
        {
            dc = new BFASTDataContext();
            List<MsAssetType> msassettype = new List<MsAssetType>();
            try
            {
                var query = dc.MsAssetType_View("", "G");
                foreach (var res in query)
                {
                    MsAssetType assettype = new MsAssetType();

                    assettype.Id = res.Id;
                    assettype.AssetTypeCode = res.AssetTypeCode;
                    assettype.AssetTypeName = res.AssetTypeName;

                    msassettype.Add(assettype);
                }
            }
            catch
            {
                msassettype = null;
            }
            return msassettype.ToArray();
        }

        //Asset Status
        private MsAssetModel[] GridAssetModel()
        {
            dc = new BFASTDataContext();
            List<MsAssetModel> msassetmodel = new List<MsAssetModel>();
            try
            {
                var query = dc.MsAssetModel_View("", "G");
                foreach (var res in query)
                {
                    MsAssetModel assetmodel = new MsAssetModel();

                    assetmodel.Id = res.Id;
                    assetmodel.ModelCode = res.ModelCode;
                    assetmodel.ModelName = res.ModelName;
                    assetmodel.BrandCode = res.BrandCode;
                    assetmodel.BrandName = res.BrandName;

                    msassetmodel.Add(assetmodel);
                }
            }
            catch
            {
                msassetmodel = null;
            }
            return msassetmodel.ToArray();
        }

        //Asset Status
        private MsAssetStatus[] GridAssetStatus()
        {
            dc = new BFASTDataContext();
            List<MsAssetStatus> msassetstatus = new List<MsAssetStatus>();
            try
            {
                var query = dc.MsAssetStatus_View("", "G");
                foreach (var res in query)
                {
                    MsAssetStatus assetstatus = new MsAssetStatus();

                    assetstatus.Id = res.Id;
                    assetstatus.Status = res.Status;
                    assetstatus.NameStatus = res.NamaStatus;

                    msassetstatus.Add(assetstatus);
                }
            }
            catch
            {
                msassetstatus = null;
            }
            return msassetstatus.ToArray();
        }

        //Category
        private MsAssetCategory[] GridAssetCategory()
        {
            dc = new BFASTDataContext();
            List<MsAssetCategory> msassetcategory = new List<MsAssetCategory>();
            try
            {
                var query = dc.MsAssetCategory_View("", "G");
                foreach (var res in query)
                {
                    MsAssetCategory assetcategory = new MsAssetCategory();

                    assetcategory.Id = res.Id;
                    assetcategory.AssetCategoryCode = res.AssetCategoryCode;
                    assetcategory.AssetCategoryName = res.AssetCategoryName;
                    assetcategory.Initial = res.Initial;
                    msassetcategory.Add(assetcategory);
                }
            }
            catch
            {
                msassetcategory = null;
            }
            return msassetcategory.ToArray();
        }

        //Supplier
        private MsSupplier[] GridSupplier()
        {
            dc = new BFASTDataContext();
            List<MsSupplier> mssupplier = new List<MsSupplier>();
            try
            {
                var query = dc.MsSupplier_View("", "G");
                foreach (var res in query)
                {
                    string Aktif = "";
                    MsSupplier supplier = new MsSupplier();
                    if (res.bActive.ToString() == "True")
                    {
                        Aktif = "Y";
                    }
                    else
                    {
                        Aktif = "T";
                    }

                    supplier.Id = res.Id;
                    supplier.SupplierCode = res.SupplierCode;
                    supplier.SupplierName = res.SupplierName;

                    supplier.PIC = res.PIC;
                    supplier.Address = res.Address;

                    supplier.City = res.City;
                    supplier.Province = res.Province;

                    supplier.PostalCode = res.PostalCode;
                    supplier.Telephone = res.Telephone;

                    supplier.Fax = res.Fax;
                    supplier.bActive = res.bActive;
                    supplier.Aktif = Aktif;


                    mssupplier.Add(supplier);
                }
            }
            catch
            {
                mssupplier = null;
            }
            return mssupplier.ToArray();
        }


        //Company
        private MsCompany[] GridCompany()
        {
            dc = new BFASTDataContext();
            List<MsCompany> mscompany = new List<MsCompany>();
            try
            {
                var query = dc.MsCompany_View("", "G");
                foreach (var res in query)
                {
                    MsCompany company = new MsCompany();

                    company.Id = res.Id;
                    company.CompanyID = res.CompanyID;
                    company.CompanyCode = res.CompanyCode;

                    company.CompanyName = res.CompanyName;
                    company.Address = res.Address;

                    company.City = res.City;
                    company.Province = res.Province;

                    company.PostalCode = res.PostalCode;
                    company.Telephone = res.Telephone;
                    company.PhotoLogo = res.PhotoLogo;

                    company.bActive = res.bActive;

                    mscompany.Add(company);
                }
            }
            catch
            {
                mscompany = null;
            }
            return mscompany.ToArray();
        }


        //ExchangeRate
        private MsExchangeRate[] GridExchangeRate()
        {
            dc = new BFASTDataContext();
            List<MsExchangeRate> msexchangerate = new List<MsExchangeRate>();
            try
            {
                var query = dc.MsExchangeRate_View("", "", "G");
                foreach (var res in query)
                {
                    MsExchangeRate exchangerate = new MsExchangeRate();

                    exchangerate.Id = res.Id;
                    exchangerate.CurrencyCode = res.CurrencyCode;
                    exchangerate.CurrencyName = res.CurrencyName;

                    exchangerate.CurrencyCodeConvert = res.CurrencyCodeConvert;
                    exchangerate.CurrencyNameConvert = res.CurrencyNameConvert;

                    exchangerate.ExchangeRate = res.ExchangeRate;

                    msexchangerate.Add(exchangerate);
                }
            }
            catch
            {
                msexchangerate = null;
            }
            return msexchangerate.ToArray();
        }

        //Employee
        private MsEmployee[] GridEmployee()
        {
            dc = new BFASTDataContext();
            List<MsEmployee> msemployee = new List<MsEmployee>();
            try
            {
                var query = dc.MsEmployee_View("", "G");
                foreach (var res in query)
                {
                    string Aktif = "";
                    MsEmployee employee = new MsEmployee();
                    if (res.bActive.ToString() == "True")
                    {
                        Aktif = "Y";
                    }
                    else
                    {
                        Aktif = "T";
                    }
                    employee.Id = res.Id;
                    employee.EmployeeId = res.EmployeeId;
                    employee.FullName = res.FullName;

                    employee.Title = res.Title;
                    employee.Phone = res.Phone;

                    employee.Email = res.Email;
                    employee.SiteCode = res.SiteCode;
                    employee.SiteName = res.SiteName;


                    employee.LocationCode = res.LocationCode;
                    employee.LocationName = res.LocationName;
                    employee.DeptCode = res.DeptCode;
                    employee.DeptName = res.DeptName;

                    employee.Notes = res.Notes;
                    //employee.bActive = res.bActive;
                    employee.Aktif = Aktif;


                    msemployee.Add(employee);
                }
            }
            catch
            {
                msemployee = null;
            }
            return msemployee.ToArray();
        }



        //sites
        public ActionResult Sites()
        {
            MsSite[] mssite = null;
            mssite = GridSite();
            return View(mssite);
        }

        [HttpPost]
        public ActionResult InsertSite(string SiteCodeId, string SiteNameId, string AddressId, string CityId, string PostalCodeId, string TelephoneId, int ActiveId)
        {

            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsSite_IUD(SiteCodeId, SiteNameId, AddressId, CityId, PostalCodeId, TelephoneId, ActiveId, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateSite(string EditSiteCodeId, string EditSiteNameId, string EditAddressId, string EditCityId, string EditPostalCodeId, string EditTelephoneId, int ActiveId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsSite_IUD(EditSiteCodeId, EditSiteNameId, EditAddressId, EditCityId, EditPostalCodeId, EditTelephoneId, ActiveId, Session["username"].ToString().Trim(), 2);
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

        //----------------------

        //Lokasi
        public ActionResult Locations()
        {
            MsLocation[] mslocation = null;
            mslocation = GridLokasi();
            return View(mslocation);
        }

        [HttpPost]
        public ActionResult InsertLocation(string LocationCodeId, string LocationNameId, string SiteCode, int FloorId, int ActiveId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsLocation_IUD(LocationCodeId, LocationNameId, SiteCode, FloorId, ActiveId, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateLocation(string NoID, string EditLocationCodeId, string EditLocationNameId, string EditSiteCode, int EditFloorId, int EditActiveId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsLocation_IUD(EditLocationCodeId, EditLocationNameId, EditSiteCode, EditFloorId, EditActiveId, Session["username"].ToString().Trim(), 2);
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

        //----------------------
        //Asset Category
        public ActionResult Categories()
        {
            MsAssetCategory[] msassetcategory = null;
            msassetcategory = GridAssetCategory();
            return View(msassetcategory);
        }

        [HttpPost]
        public ActionResult InsertAssetCategory(string AssetCategoryCodeId, string AssetCategoryNameId, string AssetInitialNameId)
        {
            try
            {
                string UserID = Session["UserName"].ToString().Trim();
                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetCategory_IUD(AssetCategoryCodeId, AssetCategoryNameId, AssetInitialNameId, UserID, 1);
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
        public ActionResult UpdateAssetCategory(string NoID, string EditAssetCategoryCodeId, string EditAssetCategoryNameId, string EditInitialNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetCategory_IUD(EditAssetCategoryCodeId, EditAssetCategoryNameId, EditInitialNameId, Session["username"].ToString().Trim(), 2);
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

        //----------------------
        //Asset Category
        public ActionResult Assetmodel()
        {
            MsAssetModel[] msassetmodel = null;
            msassetmodel = GridAssetModel();
            return View(msassetmodel);
        }


        [HttpPost]
        public ActionResult InsertAssetModel(string AssetModelCodeId, string AssetModelNameId, string AssetBrandCodeId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetModel_IUD(AssetModelCodeId, AssetModelNameId, AssetBrandCodeId, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateAssetModel(string NoID, string EditAssetModelCodeId, string EditAssetModelNameId, string EditAssetBrandCodeId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetModel_IUD(EditAssetModelCodeId, EditAssetModelNameId, EditAssetBrandCodeId, Session["username"].ToString().Trim(), 2);
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

        //----------------------
        //Asset Brand
        public ActionResult Assetbrand()
        {
            MsAssetBrand[] msassetbrand = null;
            msassetbrand = GridAssetBrand();
            return View(msassetbrand);
        }

        [HttpPost]
        public ActionResult InsertAssetBrand(string AssetBrandCodeId, string AssetBrandNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetBrand_IUD(AssetBrandCodeId, AssetBrandNameId, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateAssetBrand(string NoID, string EditAssetBrandCodeId, string EditAssetBrandNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetBrand_IUD(EditAssetBrandCodeId, EditAssetBrandNameId, Session["username"].ToString().Trim(), 2);
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
        //----------------------
        //Asset Status
        public ActionResult Assetstatus()
        {
            MsAssetStatus[] msassetstatus = null;
            msassetstatus = GridAssetStatus();
            return View(msassetstatus);
        }

        [HttpPost]
        public ActionResult InsertAssetStatus(string AssetStatusCodeId, string AssetStatusNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetStatus_IUD(AssetStatusCodeId, AssetStatusNameId, Session["username"].ToString().Trim(), 1);
                    string Exx = "";
                    foreach (var res in query)
                    {
                        Exx = res.Exx;
                    }

                    if (Exx.Trim().Substring(0, 4) == "Err ")
                    {
                        return Json(new { success = false, responseText = Exx.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = true, responseText = Exx.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
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
        public ActionResult UpdateAssetStatus(string NoID, string EditAssetStatusCodeId, string EditAssetStatusNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetStatus_IUD(EditAssetStatusCodeId, EditAssetStatusNameId, Session["username"].ToString().Trim(), 2);
                    string Exx = "";
                    foreach (var res in query)
                    {
                        Exx = res.Exx;
                    }

                    if (Exx.Trim().Substring(0, 4) == "Err ")
                    {
                        return Json(new { success = false, responseText = Exx.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = true, responseText = Exx.Trim().Replace("err ", "") }, JsonRequestBehavior.AllowGet);
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

        //----------------------
        //Asset Types
        public ActionResult Assettypes()
        {
            MsAssetType[] msassettype = null;
            msassettype = GridAssetType();
            return View(msassettype);
        }

        [HttpPost]
        public ActionResult InsertAssetType(string AssetTypeCodeId, string AssetTypeNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetType_IUD(AssetTypeCodeId, AssetTypeNameId, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateAssetType(string NoID, string EditAssetTypeCodeId, string EditAssetTypeNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsAssetType_IUD(EditAssetTypeCodeId, EditAssetTypeNameId, Session["username"].ToString().Trim(), 2);
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
        //-------------------------------------
        //Departemen
        public ActionResult Departments()
        {
            MsDepartment[] msdepartment = null;
            msdepartment = GridDepartment();
            return View(msdepartment);
        }

        [HttpPost]
        public ActionResult Insertdepartment(string DepartmentCodeId, string DepartmentNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsDepartment_IUD(DepartmentCodeId, DepartmentNameId, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateDepartment(string EditDepartmentCodeId, string EditDepartmentNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsDepartment_IUD(EditDepartmentCodeId, EditDepartmentNameId, Session["username"].ToString().Trim(), 2);
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

        //Currency

        //Asset Types
        public ActionResult Currencies()
        {
            MsCurrency[] mscurrency = null;
            mscurrency = GridCurrency();
            return View(mscurrency);
        }

        [HttpPost]
        public ActionResult InsertCurrency(string CurrencyCodeId, string CurrencyNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsCurrency_IUD(CurrencyCodeId, CurrencyNameId, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateCurrency(string NoID, string EditCurrencyCodeId, string EditCurrencyNameId)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsCurrency_IUD(EditCurrencyCodeId, EditCurrencyNameId, Session["username"].ToString().Trim(), 2);
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


        public ActionResult Suppliers()
        {
            MsSupplier[] mssupplier = null;
            mssupplier = GridSupplier();
            return View(mssupplier);
        }

        [HttpPost]
        public ActionResult InsertSupplier(string SupplierCode, string SupplierName, string PIC, string Address, string City, string Province, string PostalCode, string Telephone, string Fax, int Aktif)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsSupplier_IUD(SupplierCode, SupplierName, PIC, Address, City, Province, PostalCode, Telephone, Fax, Aktif, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateSupplier(string EditSupplierCode, string EditSupplierName, string EditPIC, string EditAddress, string EditCity, string EditProvince, string EditPostalCode, string EditTelephone, string EditFax, int EditAktif)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsSupplier_IUD(EditSupplierCode, EditSupplierName, EditPIC, EditAddress, EditCity, EditProvince, EditPostalCode, EditTelephone, EditFax, EditAktif, Session["username"].ToString().Trim(), 2);
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


        //company
        //Untuk action
        public ActionResult Companyinfo()
        {
            MsCompany[] mscompany = null;
            mscompany = GridCompany();
            return View(mscompany);
        }

        public ActionResult Createcompany()
        {
            //MsCompany[] mscompany = null;
            //mscompany = GridCompany();
            return View();
        }

        [HttpPost]
        public ActionResult InsertCompany(string CompanyCode, string CompanyName, string Address, string City, string Province, string PostalCode, string Telephone, int Aktif, string PhotoLogo)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsCompany_IUD(CompanyCode, CompanyName, Address, City, Province, PostalCode, Telephone, Aktif, PhotoLogo, Session["username"].ToString().Trim(), 1);
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
                        Session["identitas"] = CompanyCode;
                        Session["nama"] = CompanyName;

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


        public ActionResult Updatecompany()
        {
            dc = new BFASTDataContext();
            List<MsCompany> mscompany = new List<MsCompany>();
            try
            {
                var query = dc.MsCompany_View(Session["ID"].ToString(), "U");
                foreach (var res in query)
                {
                    string Aktif = "";
                    MsCompany company = new MsCompany();
                    if (res.bActive.ToString() == "True")
                    {
                        Aktif = "Y";
                    }
                    else
                    {
                        Aktif = "T";
                    }

                    ViewData["ID"] = res.Id.ToString().Trim();
                    ViewData["CompanyID"] = res.CompanyID.ToString().Trim();
                    ViewData["CompanyCode"] = res.CompanyCode.ToString().Trim();
                    ViewData["CompanyName"] = res.CompanyName.ToString().Trim();
                    ViewData["Address"] = res.Address.ToString().Trim();
                    ViewData["City"] = res.City.ToString().Trim();
                    ViewData["Province"] = res.Province.ToString().Trim();
                    ViewData["PostalCode"] = res.PostalCode.ToString().Trim();
                    ViewData["Telephone"] = res.Telephone.ToString().Trim();
                    ViewData["Aktif"] = Aktif.ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                mscompany = null;
            }

            return View();
        }

        //Buat Update
        [HttpPost]
        public ActionResult UpdateDataCompany(string CompanyID)
        {
            Session["ID"] = CompanyID;

            dc = new BFASTDataContext();
            List<MsCompany> mscompany = new List<MsCompany>();
            try
            {
                var query = dc.MsCompany_View(Session["ID"].ToString(), "U");
                foreach (var res in query)
                {
                    string Aktif = "";
                    MsCompany company = new MsCompany();
                    if (res.bActive.ToString() == "True")
                    {
                        Aktif = "Y";
                    }
                    else
                    {
                        Aktif = "T";
                    }

                    ViewData["ID"] = res.Id.ToString().Trim();
                    ViewData["CompanyID"] = res.CompanyID.ToString().Trim();
                    ViewData["CompanyCode"] = res.CompanyCode.ToString().Trim();
                    ViewData["CompanyName"] = res.CompanyName.ToString().Trim();
                    ViewData["Address"] = res.Address.ToString().Trim();
                    ViewData["City"] = res.City.ToString().Trim();
                    ViewData["Province"] = res.Province.ToString().Trim();
                    ViewData["PostalCode"] = res.PostalCode.ToString().Trim();
                    ViewData["Telephone"] = res.Telephone.ToString().Trim();
                    ViewData["Aktif"] = Aktif.ToString().Trim();
                    TempData["identitas"] = res.CompanyCode.ToString().Trim();
                    TempData["nama"] = res.CompanyName.ToString().Trim();

                }
            }
            catch (Exception ex)
            {
                mscompany = null;
            }
            return View("Updatecompany");
        }

        [HttpPost]
        public ActionResult SimpanGambarCompany(FormCollection formCollection)
        {
            try
            {

                foreach (string item in Request.Files)
                {
                    string identitas = "";
                    string nama = "";

                    if (TempData["identitas"] == null)
                    {
                        identitas = Session["identitas"].ToString().Trim();
                    }
                    else
                    {
                        identitas = TempData["identitas"].ToString().Trim();
                    }

                    if (TempData["nama"] == null)
                    {
                        nama = Session["nama"].ToString().Trim();
                    }
                    else
                    {
                        nama = TempData["nama"].ToString().Trim();
                    }

                    HttpPostedFileBase file = Request.Files[item] as HttpPostedFileBase;
                    if (file.ContentLength == 0)
                        continue;
                    if (file.ContentLength > 0)
                    {
                        ImageUpload imageUpload = new ImageUpload { Width = 60, Height = 60 };
                        ImageResult imageResult = imageUpload.RenameUploadFile(file, 0, identitas, nama);
                        if (imageResult.Success)
                        {
                            Console.WriteLine(imageResult.ImageName);
                            Session["nama"] = null;
                            Session["identitas"] = null;
                            Session["imageName"] = null;
                            Session["fileconnvert"] = null;
                            Session["imageName"] = imageResult.ImageName.ToString().Trim();
                            Session["fileconnvert"] = imageResult.FileConvert;
                        }
                        else
                        {
                            ViewBag.Error = imageResult.ErrorMessage;
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                string pesan = ex.Message.ToString();
            }
            return View();
        }

        [HttpPost]
        public ActionResult UbahCompany(string EditCompanyCode, string EditCompanyName, string EditAddress, string EditCity, string EditProvince, string EditPostalCode, string EditTelephone, int EditAktif, string EditPhotoLogo)
        {
            try
            {
                dc = new BFASTDataContext();
                try
                {
                    if (Session["fileconnvert"] == null)
                    {
                        EditPhotoLogo = "";
                    }
                    else
                    {
                        EditPhotoLogo = Session["fileconnvert"].ToString().Trim();
                    }

                    var query = dc.MsCompany_IUD(EditCompanyCode, EditCompanyName, EditAddress, EditCity, EditProvince, EditPostalCode, EditTelephone, EditAktif, EditPhotoLogo, Session["username"].ToString().Trim(), 2);
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
        //----------------------------------------------------------

        //Exchange Rate
        public ActionResult Exchangerate()
        {
            MsExchangeRate[] msexchangerate = null;
            msexchangerate = GridExchangeRate();
            return View(msexchangerate);
        }

        [HttpPost]
        public ActionResult InsertExchangeRate(string CurrencyCode, string CurrencyCodeConvert, decimal ExchangeRate)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsExchangeRate_IUD(CurrencyCode, CurrencyCodeConvert, ExchangeRate, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateExchangeRate(string EditCurrencyCode, string EditCurrencyCodeConvert, decimal EditExchangeRate)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsExchangeRate_IUD(EditCurrencyCode, EditCurrencyCodeConvert, EditExchangeRate, Session["username"].ToString().Trim(), 2);
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

        //----------------------------------------------------------
        public ActionResult Persons()
        {
            MsEmployee[] msemployee = null;
            msemployee = GridEmployee();
            return View(msemployee);
        }

        [HttpPost]
        public ActionResult InsertEmployee(string EmployeeId, string FullName, string Title, string Phone, string Email, string SiteCode, string LocationCode, string DeptCode, string Notes, int Aktif)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsEmployee_IUD(EmployeeId, FullName, Title, Phone, Email, SiteCode, LocationCode, DeptCode, Notes, Aktif, Session["username"].ToString().Trim(), 1);
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
        public ActionResult UpdateEmployee(string EditEmployeeId, string EditFullName, string EditTitle, string EditPhone, string EditEmail, string EditSiteCode, string EditLocationCode, string EditDeptCode, string EditNotes, int EditAktif)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    var query = dc.MsEmployee_IUD(EditEmployeeId, EditFullName, EditTitle, EditPhone, EditEmail, EditSiteCode, EditLocationCode, EditDeptCode, EditNotes, EditAktif, Session["username"].ToString().Trim(), 2);
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


        //----------------------------------------------------------
        //Barcode
        public ActionResult Barcode()
        {
            MsBarcode[] msbarcode = null;
            msbarcode = GridBarcode();
            return View(msbarcode);
        }

        //----------------------------------------------------------

        public ActionResult Types()
        {
            return View();
        }

        public ActionResult Status()
        {
            return View();
        }

        public ActionResult Autonumber()
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


        //POPUP
        //PopUp Site
        [HttpPost]
        public JsonResult GetPopupSite()
        {
            MsSite[] mssite = null;
            mssite = GridSite();

            return Json(new
            {
                data = mssite.Select(x => new[] { x.SiteCode, x.SiteName, x.Address, x.City, x.PostalCode, x.Telephone })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Departement
        [HttpPost]
        public JsonResult GetPopupDepartement()
        {
            MsDepartment[] msdepartment = null;
            msdepartment = GridDepartment();

            return Json(new
            {
                data = msdepartment.Select(x => new[] { x.DeptCode, x.DeptName })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Location
        [HttpPost]
        public JsonResult GetPopupLocation()
        {
            MsLocation[] mslocation = null;
            mslocation = GridLokasi();

            return Json(new
            {
                data = mslocation.Select(x => new[] { x.LocationCode, x.LocationName, x.SiteName, x.Floor.ToString(), x.SiteCode })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Site
        [HttpPost]
        public JsonResult GetPopupBrand()
        {
            MsAssetBrand[] msassetbrand = null;
            msassetbrand = GridAssetBrand();

            return Json(new
            {
                data = msassetbrand.Select(x => new[] { x.BrandCode, x.BrandName })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Site
        [HttpPost]
        public JsonResult GetPopupCurrency()
        {
            MsCurrency[] mscurrency = null;
            mscurrency = GridCurrency();

            return Json(new
            {
                data = mscurrency.Select(x => new[] { x.CurrencyCode, x.CurrencyName })
            }, JsonRequestBehavior.AllowGet);
        }

    }
}