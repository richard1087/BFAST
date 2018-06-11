using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CORE.JGC.Models;
using iTextSharp.text.pdf.qrcode;
using System.IO;
using System.Drawing;
using iTextSharp.text.pdf;
using System.Web.Helpers;
using System.Globalization;

namespace CORE.JGC.Controllers
{
    [SessionTimeoutAttribute]
    public class AssetController : Controller
    {   
        BFASTDataContext dc = null;
        // GET: Asset
        private MsAsset[] GridAsset()
        {
            dc = new BFASTDataContext();
            List<MsAsset> msasset = new List<MsAsset>();
            //string url = "http://" + Request.Url.Authority;
            try
            {
                var query = dc.MsAsset_View("", "G");
                foreach (var res in query)
                {
                    MsAsset asset = new MsAsset();
                    asset.Photo = res.AssetPhoto;
                    asset.AssetCode = res.AssetTagID;
                    asset.AssetName = res.AssetName;
                    asset.AssetBrandCode = res.AssetBrand;
                    asset.PurchaseDate = res.PurchaseDate;
                    double price = Convert.ToDouble(res.PurchasePrice);
                    asset.PurchasePrice = res.CurrencyCode + " " + price.ToString("N0");
                    asset.bStatus = res.NamaStatus;
                    msasset.Add(asset);
                }
            }
            catch
            {
                msasset = null;
            }
            return msasset.ToArray();
        }
        public MsSite[] GetSite()
        {
            List<MsSite> msite = new List<MsSite>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsSite_View("", "G");
                foreach (var res in query)
                {
                    MsSite site = new MsSite();
                    site.SiteCode = res.SiteCode;
                    site.SiteName = res.SiteName;
                    msite.Add(site);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return msite.ToArray();
        }
        public MsLocation[] GetLocation()
        {
            List<MsLocation> mLocation = new List<MsLocation>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsLocation_View("", "", "G");
                foreach (var res in query)
                {
                    MsLocation location = new MsLocation();
                    location.LocationCode = res.LocationCode;
                    location.LocationName = res.LocationName;
                    mLocation.Add(location);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mLocation.ToArray();
        }
        public MsAssetCategory[] GetCategory()
        {
            List<MsAssetCategory> mCategory = new List<MsAssetCategory>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsAssetCategory_View("", "G");
                foreach (var res in query)
                {
                    MsAssetCategory category = new MsAssetCategory();
                    category.AssetCategoryCode = res.AssetCategoryCode;
                    category.AssetCategoryName = res.AssetCategoryName;
                    mCategory.Add(category);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mCategory.ToArray();
        }
        public MsDepartment[] GetDept()
        {
            List<MsDepartment> mDept = new List<MsDepartment>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsDepartment_View("", "G");
                foreach (var res in query)
                {
                    MsDepartment dept = new MsDepartment();
                    dept.DeptCode = res.DeptCode;
                    dept.DeptName = res.DeptName;
                    mDept.Add(dept);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mDept.ToArray();
        }
        public MsAssetType[] GetAssetType()
        {
            List<MsAssetType> mAssetType = new List<MsAssetType>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsAssetType_View("", "G");
                foreach (var res in query)
                {
                    MsAssetType assettype = new MsAssetType();
                    assettype.AssetTypeCode = res.AssetTypeCode;
                    assettype.AssetTypeName = res.AssetTypeName;
                    mAssetType.Add(assettype);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mAssetType.ToArray();
        }
        public MsSupplier[] GetSupplier()
        {
            List<MsSupplier> mSupplier = new List<MsSupplier>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsSupplier_View("", "G");
                foreach (var res in query)
                {
                    MsSupplier supplier = new MsSupplier();
                    supplier.SupplierCode = res.SupplierCode;
                    supplier.SupplierName = res.SupplierName;
                    mSupplier.Add(supplier);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mSupplier.ToArray();
        }
        public MsAssetBrand[] GetAssetBrand()
        {
            List<MsAssetBrand> mAssetBrand = new List<MsAssetBrand>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsAssetBrand_View("", "G");
                foreach (var res in query)
                {
                    MsAssetBrand assetbrand = new MsAssetBrand();
                    assetbrand.BrandCode = res.BrandCode;
                    assetbrand.BrandName = res.BrandName;
                    mAssetBrand.Add(assetbrand);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mAssetBrand.ToArray();
        }
        public MsAssetModel[] GetAssetModel()
        {
            List<MsAssetModel> mAssetModel = new List<MsAssetModel>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsAssetModel_View("", "G");
                foreach (var res in query)
                {
                    MsAssetModel assetmodel = new MsAssetModel();
                    assetmodel.ModelCode = res.ModelCode;
                    assetmodel.ModelName = res.ModelName;
                    mAssetModel.Add(assetmodel);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mAssetModel.ToArray();
        }
        public MsCurrency[] GetCurrency()
        {
            List<MsCurrency> mCurrency = new List<MsCurrency>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsCurrency_View("", "G");
                foreach (var res in query)
                {
                    MsCurrency currency = new MsCurrency();
                    currency.CurrencyCode = res.CurrencyCode;
                    currency.CurrencyName = res.CurrencyName;
                    mCurrency.Add(currency);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mCurrency.ToArray();
        }
        public MsCompany[] GetCompany()
        {
            List<MsCompany> mCompany = new List<MsCompany>();
            dc = new BFASTDataContext();
            try
            {
                var query = dc.MsCompany_View("", "G");
                foreach (var res in query)
                {
                    MsCompany company = new MsCompany();
                    company.CompanyCode = res.CompanyCode;
                    company.CompanyName = res.CompanyName;
                    mCompany.Add(company);
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }
            return mCompany.ToArray();
        }
        private string GenerateQrCode(string assettagid)
        {



            string pathdb = "/Content/res/build/images/Qrcode/" + assettagid + ".jpg";
            string filepathimg = Server.MapPath(pathdb);
            //string filepathimg = Path.Combine(Server.MapPath("~/Content/res/build/images/Qrcode/"), assettagid + ".jpg");
            string base64 = string.Empty;


            ByteMatrix btm;
            Bitmap bmp = null;
            MemoryStream ms = null;
            try
            {
                BarcodeQRCode qrcode = new BarcodeQRCode(assettagid, 200, 200, null);
                QRCodeWriter qrwriter = new QRCodeWriter();
                btm = qrwriter.Encode(assettagid, 200, 200, null);
                qrcode.GetImage();
                sbyte[][] imgQr = btm.GetArray();
                bmp = new Bitmap(200, 200);
                Graphics gpr = Graphics.FromImage(bmp);
                gpr.Clear(Color.White);
                for (int i = 0; i < imgQr.Length; i++)
                {
                    for (int j = 0; j <= imgQr[i].Length - 1; j++)
                    {
                        if (imgQr[j][i] == 0)
                        {
                            gpr.FillRectangle(Brushes.Black, i, j, 1, 1);
                        }
                        else
                        {
                            gpr.FillRectangle(Brushes.White, i, j, 1, 1);
                        }
                    }
                }
                using (ms = new MemoryStream())
                {
                    Response.ContentType = "image/jpeg";
                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] byteImg = ms.ToArray();
                    base64 = Convert.ToBase64String(byteImg);
                }
            }
            catch (Exception ex)
            {
                base64 = "";
                string msg = ex.Message;
            }
            bmp.Dispose();

            //fs.Close();
            return pathdb;
        }
        private void UploadPhoto()
        {
            string path = string.Empty;
            if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
            {
                var pic = System.Web.HttpContext.Current.Request.Files["Assetpic"];
                if (pic.ContentLength > 0)
                {
                    string filename = Path.GetFileName(pic.FileName);
                    var ext = Path.GetExtension(pic.FileName);
                    //imgName = Guid.NewGuid().ToString();
                    filename = filename + DateTime.Now.ToString("HHmmss") + ext;
                    path = "/Content/res/build/images/Assets/" + filename + ext;
                    //var filepath = path;
                    pic.SaveAs(path);
                    MemoryStream stream = new MemoryStream();
                    WebImage webimg = new WebImage(path);
                    if (webimg.Width > 200)
                    {
                        webimg.Resize(200, 200);
                        webimg.Save(path);
                    }
                }
            }
            //ms.Close();
            ////return pathdb;
            //return base64;

        }
        public ActionResult Index()
        {
            MsAsset[] msasset = null;
            msasset = GridAsset();
            return View(msasset);
        }
        private void UploadImage(HttpPostedFileBase file)
        {

        }
        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.Sitecode = GetSite();
            ViewBag.Location = GetLocation();
            ViewBag.Category = GetCategory();
            ViewBag.Dept = GetDept();
            ViewBag.AssetType = GetAssetType();
            ViewBag.Suppliername = GetSupplier();
            ViewBag.BrandName = GetAssetBrand();
            ViewBag.ModelName = GetAssetModel();
            ViewBag.Currencyname = GetCurrency();
            ViewBag.Companyname = GetCompany();
            return View();
        }
        //[HttpPost]
        //public ActionResult InputData(MsAsset asset)
        //{
        //    string UserID = Session["UserName"].ToString().Trim();
        //    //string Photo = GeneratePhoto(path);


        //    string hasil = string.Empty;
        //    string path = string.Empty;
        //    string pathdb = string.Empty;
        //    dc = new BFASTDataContext();
        //    MemoryStream ms = null;
        //    Bitmap bmp   = null;
        //    string base64 = string.Empty;
        //    try
        //    {
                
        //        if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
        //        {
        //            var pic = System.Web.HttpContext.Current.Request.Files["fileupload"];
        //            HttpPostedFileBase filebase = new HttpPostedFileWrapper(pic);
                    
        //            if (pic.ContentLength > 0)
        //            {
        //                string filename = Path.GetFileNameWithoutExtension(pic.FileName);
        //                string ext = Path.GetExtension(pic.FileName);
        //                filename = filename + DateTime.Now.ToString("HHmmss");
        //                pathdb = "/Content/res/build/images/Assets/" + filename + ext;
        //                path = Server.MapPath(pathdb);
        //                pic.SaveAs(path);
        //                WebImage webimg = new WebImage(path);

        //                if (webimg.Width > 150)
        //                {
        //                    webimg.Resize(150, 150);

        //                if (webimg.Width > 100)
        //                {
        //                    webimg.Resize(100, 100);

        //                    webimg.Save(path);
        //                }
        //                bmp = new Bitmap(path);
                        
        //                using (ms = new MemoryStream())
        //                {
        //                    Response.ContentType = "image/jpeg";
        //                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //                    byte[] byteImg = ms.ToArray();
        //                    base64 = Convert.ToBase64String(byteImg);
        //                }
        //                bmp.Dispose();
        //                ms.Close();
        //            }
        //        }
        //        var query = dc.MsAsset_IUD(asset.AssetName, asset.AssetBrandCode, asset.AssetModelCode, asset.AssetCategoryCode, asset.AssetSerialNo, asset.AssetTypeCode, 

        //            Convert.ToInt32(asset.bActive), Convert.ToInt32(asset.bCap), pathdb, asset.SiteCode, asset.LocationCode, Convert.ToInt32(asset.Floor), asset.PurchaseNo, asset.CurrencyCode,

        //            Convert.ToInt32(asset.bActive), Convert.ToInt32(asset.bCap), base64, asset.SiteCode, asset.LocationCode, Convert.ToInt32(asset.Floor), asset.PurchaseNo, asset.CurrencyCode,

        //            Convert.ToDecimal(asset.PurchasePrice), Convert.ToDateTime(asset.PurchaseDate), asset.SupplierCode, asset.CompanyID, asset.DeptCode, Convert.ToInt32(asset.Warranty),
        //            UserID, 1);
        //        foreach (var res in query)
        //        {
        //            if (res.Status == "Err This Data Already Exists")
        //            {
        //                hasil = "Data Already Exists";
        //            }
        //            else
        //            {

        //                //string qrcode = GenerateQrCode(res.AssetTag);
        //                //var qr = dc.MsBarcode_IUD(res.AssetTag, qrcode, "", "", UserID, 1);
        //                //hasil = res.AssetTag;

        //                //string qrcode = GenerateQrCode(res.Status);
        //                //var qr = dc.MsBarcode_IUD(res.Status, qrcode, "", "", UserID, 1);
        //                //hasil = res.Status;

        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        bmp.Dispose();
        //        ms.Close();
        //        return Json(new { error = true, responseText = ex.Message.ToString().Trim() }, JsonRequestBehavior.AllowGet);
        //    }
        //    return Json(new { success = true, responseText = hasil }, JsonRequestBehavior.AllowGet);
        //}
        public ActionResult Maintenancedue()
        {
            TrMaintenanceAsset[] trMaintenance = null;
            trMaintenance = GridMaintenance();
            return View(trMaintenance);
        }

        public ActionResult Checkout()
        {
            TrCheckOutLine[] trCheckOutLine = null;
            trCheckOutLine = GridCheckOutLine();
            return View(trCheckOutLine);
        }

        public ActionResult Checkin()
        {
            TrCheckInLine[] trCheckInLine = null;
            trCheckInLine = GridCheckInLine();
            return View(trCheckInLine);
        }

        public ActionResult Dispose()
        {
            TrDisposeAssetLine[] trDisposeAssetLine = null;
            trDisposeAssetLine = GridDisposeAssetLine();
            return View(trDisposeAssetLine);
        }
        public ActionResult Createmaintenance()
        {
            TrMaintenanceAssetLine[] trMaintenanceLine = null;
            trMaintenanceLine = GridMaintenanceAssetLine();
            return View(trMaintenanceLine);
        }
        public ActionResult Transfer()
        {
            TrTransferAsset[] trTransfer = null;
            trTransfer = GridTransfer();
            return View(trTransfer);
        }

        public ActionResult CreateTransfer()
        {
            TrTransferAssetLine[] trTransferLine = null;
            trTransferLine = GridTransferLine();
            return View(trTransferLine);
        }

        public ActionResult Assetpastdue()
        {
            return View();
        }

        public ActionResult Warrantiesexpiring()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAssetCheckOut(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxCheckOutLine_IUD(AssetCode, UserID, 1);

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
        public ActionResult DeleteAssetCheckOut(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxCheckOutLine_IUD(AssetCode, UserID, 3);

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
        public ActionResult DeleteAssetDispose(string AssetCode)
        {
            try
            {
                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxDisposeAssetLine_IUD(AssetCode, UserID, 3);

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
        public ActionResult DeleteAssetCheckIn(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxCheckInLine_IUD(AssetCode, UserID, 3);

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
        public ActionResult DeleteAssetMaintenance(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxMaintenanceAssetLine_IUD(AssetCode, UserID, 3);

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
        public ActionResult DeleteAssetTransfer(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxTransferAssetLine_IUD(AssetCode, UserID, 3);

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
        public ActionResult AddAssetCheckIn(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxCheckInLine_IUD(AssetCode, UserID, 1);

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
        public ActionResult AddAssetDispose(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxDisposeAssetLine_IUD(AssetCode, UserID, 1);

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
        public ActionResult AddAssetMaintenance(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxMaintenanceAssetLine_IUD(AssetCode, UserID, 1);

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
        public ActionResult AddAssetTransfer(string AssetCode)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string UserID = Session["UserName"].ToString().Trim();
                    var query = dc.TrxTransferAssetLine_IUD(AssetCode, UserID, 1);

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
        public ActionResult SaveCheckOut(string CheckOutDate, string CheckOutDueDate, string EmployeeId, string Email, string SiteCode, string LocationCode, int Floor, string Notes)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string CheckOutNo = "";
                    string UserID = Session["UserName"].ToString().Trim();
                    DateTime CheckOutDateC = DateTime.ParseExact(CheckOutDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    DateTime? CheckOutDueDateC;
                    if (CheckOutDueDate == "")
                    {
                        CheckOutDueDateC = null;
                    }
                    else
                    {
                        CheckOutDueDateC = DateTime.ParseExact(CheckOutDueDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    }
                    var query = dc.TrxCheckOut_IUD(CheckOutNo, CheckOutDateC, CheckOutDueDateC, EmployeeId, Email, SiteCode, LocationCode, Floor, Notes, UserID, 1);

                    string status = "";
                    foreach (var res in query)
                    {
                        status = res.Exception;
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
        public ActionResult SaveCheckIn(string ReturnDate, string Notes)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string CheckInNo = "";
                    string UserID = Session["UserName"].ToString().Trim();
                    DateTime ReturnDateC = DateTime.ParseExact(ReturnDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    var query = dc.TrxCheckIn_IUD(CheckInNo, ReturnDateC, Notes, UserID, 1);
                    string status = "";
                    foreach (var res in query)
                    {
                        status = res.Exception;
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
        public ActionResult SaveDispose(string DisposeDate, string DisposeTo, string DisposeReason)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string DisposeNo = "";
                    string UserID = Session["UserName"].ToString().Trim();
                    DateTime DisposeDateC = DateTime.ParseExact(DisposeDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    var query = dc.TrxDisposeAsset_IUD(DisposeNo, DisposeDateC, DisposeTo, DisposeReason, UserID, 1);
                    string status = "";
                    foreach (var res in query)
                    {
                        status = res.Exception;
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
        public ActionResult SaveMaintenance(string ScheduleDate, string CompleteDate, string Type, string AssignTo, string Damage, string Notes, decimal Cost)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string MaintenanceTo = "";
                    string UserID = Session["UserName"].ToString().Trim();
                    DateTime ScheduleDateC = DateTime.ParseExact(ScheduleDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    DateTime CompleteDateC = DateTime.ParseExact(CompleteDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    var query = dc.TrxMaintenanceAsset_IUD(MaintenanceTo, Type, ScheduleDateC, CompleteDateC, AssignTo, Damage, Notes, Cost, UserID, 1);
                    string status = "";
                    foreach (var res in query)
                    {
                        status = res.Exception;
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
        public ActionResult SaveTransfer(string Type, string TransferDate, string TransferAssetNoRef, string SiteCode, string LocationCode, int Floor, string Notes)
        {
            try
            {

                dc = new BFASTDataContext();
                try
                {
                    string TransferNo = "";
                    string UserID = Session["UserName"].ToString().Trim();
                    DateTime TransferDateC = DateTime.ParseExact(TransferDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    var query = dc.TrxTransferAsset_IUD(TransferNo, Type, TransferDateC, TransferAssetNoRef, SiteCode, LocationCode, Floor, Notes, UserID, 1);
                    string status = "";
                    foreach (var res in query)
                    {
                        status = res.Exception;
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

        public MsAsset[] GridPopupAssetCheckOut()
        {
            dc = new BFASTDataContext();
            List<MsAsset> msAsset = new List<MsAsset>();
            try
            {
                var query = dc.Pop_AssetCheckOut();
                foreach (var res in query)
                {
                    MsAsset asset = new MsAsset();

                    asset.AssetCode = res.AssetCode;
                    asset.AssetName = res.AssetName;
                    asset.AssetSerialNo = res.AssetSerialNo;

                    msAsset.Add(asset);
                }
            }
            catch
            {
                msAsset = null;
            }
            return msAsset.ToArray();
        }
        public MsAsset[] GridPopupAssetCheckIn()
        {
            dc = new BFASTDataContext();
            List<MsAsset> msAsset = new List<MsAsset>();
            try
            {
                var query = dc.Pop_AssetCheckIn();
                foreach (var res in query)
                {
                    MsAsset asset = new MsAsset();

                    asset.AssetCode = res.AssetCode;
                    asset.AssetName = res.AssetName;
                    asset.AssetSerialNo = res.AssetSerialNo;

                    msAsset.Add(asset);
                }
            }
            catch
            {
                msAsset = null;
            }
            return msAsset.ToArray();
        }
        public MsAsset[] GridPopupAssetDispose()
        {
            dc = new BFASTDataContext();
            List<MsAsset> msAsset = new List<MsAsset>();
            try
            {
                var query = dc.Pop_AssetDisposeAsset();
                foreach (var res in query)
                {
                    MsAsset asset = new MsAsset();

                    asset.AssetCode = res.AssetCode;
                    asset.AssetName = res.AssetName;
                    asset.AssetSerialNo = res.AssetSerialNo;

                    msAsset.Add(asset);
                }
            }
            catch
            {
                msAsset = null;
            }
            return msAsset.ToArray();
        }
        public MsAsset[] GridPopupAssetMaintenance()
        {
            dc = new BFASTDataContext();
            List<MsAsset> msAsset = new List<MsAsset>();
            try
            {
                var query = dc.Pop_AssetMaintenance();
                foreach (var res in query)
                {
                    MsAsset asset = new MsAsset();

                    asset.AssetCode = res.AssetCode;
                    asset.AssetName = res.AssetName;
                    asset.AssetSerialNo = res.AssetSerialNo;

                    msAsset.Add(asset);
                }
            }
            catch
            {
                msAsset = null;
            }
            return msAsset.ToArray();
        }
        public MsAsset[] GridPopupAssetTransfer()
        {
            dc = new BFASTDataContext();
            List<MsAsset> msAsset = new List<MsAsset>();
            try
            {
                var query = dc.Pop_AssetTransfer();
                foreach (var res in query)
                {
                    MsAsset asset = new MsAsset();

                    asset.AssetCode = res.AssetCode;
                    asset.AssetName = res.AssetName;
                    asset.AssetSerialNo = res.AssetSerialNo;

                    msAsset.Add(asset);
                }
            }
            catch
            {
                msAsset = null;
            }
            return msAsset.ToArray();
        }
        public MsEmployee[] GridPopupEmployee()
        {
            dc = new BFASTDataContext();
            List<MsEmployee> msEmployee = new List<MsEmployee>();
            try
            {
                var query = dc.MsEmployee_View("", "P");
                foreach (var res in query)
                {
                    MsEmployee employee = new MsEmployee();

                    employee.EmployeeId = res.EmployeeId;
                    employee.FullName = res.FullName;
                    employee.Email = res.Email;
                    employee.DeptName = res.DeptName;


                    msEmployee.Add(employee);
                }
            }
            catch
            {
                msEmployee = null;
            }
            return msEmployee.ToArray();
        }
        public MsSite[] GridPopupSite()
        {
            dc = new BFASTDataContext();
            List<MsSite> msSite = new List<MsSite>();
            try
            {
                var query = dc.MsSite_View("", "P");
                foreach (var res in query)
                {
                    MsSite site = new MsSite();

                    site.SiteCode = res.SiteCode;
                    site.SiteName = res.SiteName;
                    site.Address = res.Address;
                    site.City = res.City;
                    site.PostalCode = res.PostalCode;


                    msSite.Add(site);
                }
            }
            catch
            {
                msSite = null;
            }
            return msSite.ToArray();
        }

        public MsDepartment[] GridPopupDepartment()
        {
            dc = new BFASTDataContext();
            List<MsDepartment> msDepartment = new List<MsDepartment>();
            try
            {
                var query = dc.MsDepartment_View("", "P");
                foreach (var res in query)
                {
                    MsDepartment department = new MsDepartment();

                    department.DeptCode = res.DeptCode;
                    department.DeptName = res.DeptName;

                    msDepartment.Add(department);
                }
            }
            catch
            {
                msDepartment = null;
            }
            return msDepartment.ToArray();
        }

        public MsSupplier[] GridPopupSupplier()
        {
            dc = new BFASTDataContext();
            List<MsSupplier> msSupplier = new List<MsSupplier>();
            try
            {
                var query = dc.MsSupplier_View("", "P");
                foreach (var res in query)
                {
                    MsSupplier supplier = new MsSupplier();

                    supplier.SupplierCode = res.SupplierCode;
                    supplier.SupplierName = res.SupplierName;

                    msSupplier.Add(supplier);
                }
            }
            catch
            {
                msSupplier = null;
            }
            return msSupplier.ToArray();
        }

        public MsAssetBrand[] GridPopupBrand()
        {
            dc = new BFASTDataContext();
            List<MsAssetBrand> msBrand = new List<MsAssetBrand>();
            try
            {
                var query = dc.MsAssetBrand_View("", "P");
                foreach (var res in query)
                {
                    MsAssetBrand brand = new MsAssetBrand();

                    brand.BrandCode = res.BrandCode;
                    brand.BrandName = res.BrandName;

                    msBrand.Add(brand);
                }
            }
            catch
            {
                msBrand = null;
            }
            return msBrand.ToArray();
        }

        public MsAssetModel[] GridPopupModel()
        {
            dc = new BFASTDataContext();
            List<MsAssetModel> msModel = new List<MsAssetModel>();
            try
            {
                var query = dc.MsAssetModel_View("", "P");
                foreach (var res in query)
                {
                    MsAssetModel model = new MsAssetModel();

                    model.ModelCode = res.ModelCode;
                    model.ModelName = res.ModelName;

                    msModel.Add(model);
                }
            }
            catch
            {
                msModel = null;
            }
            return msModel.ToArray();
        }

        public MsAssetType[] GridPopupType()
        {
            dc = new BFASTDataContext();
            List<MsAssetType> msType= new List<MsAssetType>();
            try
            {
                var query = dc.MsAssetType_View("", "P");
                foreach (var res in query)
                {
                    MsAssetType type = new MsAssetType();

                    type.AssetTypeCode = res.AssetTypeCode;
                    type.AssetTypeName = res.AssetTypeName;

                    msType.Add(type);
                }
            }
            catch
            {
                msType = null;
            }
            return msType.ToArray();
        }

        public MsCurrency[] GridPopupCurrency()
        {
            dc = new BFASTDataContext();
            List<MsCurrency> msCurrency = new List<MsCurrency>();
            try
            {
                var query = dc.MsCurrency_View("", "P");
                foreach (var res in query)
                {
                    MsCurrency currency = new MsCurrency();

                    currency.CurrencyCode = res.CurrencyCode;
                    currency.CurrencyName = res.CurrencyName;

                    msCurrency.Add(currency);
                }
            }
            catch
            {
                msCurrency = null;
            }
            return msCurrency.ToArray();
        }

        public MsCompany[] GridPopupCompany()
        {
            dc = new BFASTDataContext();
            List<MsCompany> msCompany = new List<MsCompany>();
            try
            {
                var query = dc.MsCompany_View("", "P");
                foreach (var res in query)
                {
                    MsCompany company = new MsCompany();

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

        public MsAssetCategory[] GridPopupCategory()
        {
            dc = new BFASTDataContext();
            List<MsAssetCategory> msCategory = new List<MsAssetCategory>();
            try
            {
                var query = dc.MsAssetCategory_View("", "P");
                foreach (var res in query)
                {
                    MsAssetCategory category = new MsAssetCategory();

                    category.AssetCategoryCode = res.AssetCategoryCode;
                    category.AssetCategoryName = res.AssetCategoryName;

                    msCategory.Add(category);
                }
            }
            catch
            {
                msCategory = null;
            }
            return msCategory.ToArray();
        }
        public MsType[] GridPopupTypeTransfer()
        {
            dc = new BFASTDataContext();
            List<MsType> msType = new List<MsType>();
            try
            {
                var query = dc.Pop_AssetTransferType();
                foreach (var res in query)
                {
                    MsType type = new MsType();

                    type.TypeCode = res.Type ;
                    type.TypeName = res.NamaType;

                    msType.Add(type);
                }
            }
            catch
            {
                msType = null;
            }
            return msType.ToArray();
        }

        public MsLocation[] GridPopupLocation(string SiteCode)
        {
            dc = new BFASTDataContext();
            List<MsLocation> msLocation = new List<MsLocation>();
            try
            {
                var query = dc.MsLocation_View("", SiteCode, "P");
                foreach (var res in query)
                {
                    MsLocation location = new MsLocation();

                    location.LocationCode = res.LocationCode;
                    location.LocationName = res.LocationName;
                    location.SiteName = res.SiteName;
                    location.Floor = res.Floor;

                    msLocation.Add(location);
                }
            }
            catch
            {
                msLocation = null;
            }
            return msLocation.ToArray();
        }
        public TrTransferAsset[] GridPopupTransferNoRef()
        {
            dc = new BFASTDataContext();
            List<TrTransferAsset> trx = new List<TrTransferAsset>();
            try
            {
                var query = dc.TrxTransferAsset_View("", "S");
                foreach (var res in query)
                {
                    TrTransferAsset transfer = new TrTransferAsset();

                    transfer.TransferAssetNo = res.TransferAssetNo;
                    transfer.NamaStatus = res.NamaStatus;
                    transfer.NamaType = res.NamaType;
                    transfer.SiteCode = res.SiteCode;
                    transfer.SiteName = res.SiteName;
                    transfer.LocationCode = res.LocationCode;
                    transfer.LocationName = res.LocationName;
                    transfer.Floor = res.Floor;

                    trx.Add(transfer);
                }
            }
            catch
            {
                trx = null;
            }
            return trx.ToArray();
        }

        public TrCheckOut[] GridCheckOut()
        {
            dc = new BFASTDataContext();
            List<TrCheckOut> trCheckOut = new List<TrCheckOut>();
            try
            {
                var query = dc.TrxCheckOut_View("", "G");
                foreach (var res in query)
                {
                    TrCheckOut checkout = new TrCheckOut();

                    checkout.CheckOutNo = res.CheckOutNo;
                    checkout.NamaStatus = res.NamaStatus;
                    checkout.Type = res.Type;
                    checkout.CheckOutDate = res.CheckOutDate;
                    checkout.CheckOutDueDate = res.CheckOutDueDate;
                    checkout.SiteName = res.SiteName;
                    checkout.LocationName = res.LocationName;
                    checkout.Notes = res.Notes;

                    trCheckOut.Add(checkout);
                }
            }
            catch
            {
                trCheckOut = null;
            }
            return trCheckOut.ToArray();
        }

        public TrCheckOutLine[] GridCheckOutLine()
        {
            dc = new BFASTDataContext();
            List<TrCheckOutLine> trCheckOutLine = new List<TrCheckOutLine>();
            try
            {
                var query = dc.TrxCheckOutLine_View("", "", "K");
                foreach (var res in query)
                {
                    TrCheckOutLine checkoutLine = new TrCheckOutLine();


                    checkoutLine.AssetCode = res.AssetCode;
                    checkoutLine.AssetName = res.AssetName;
                    checkoutLine.AssetSerialNo = res.AssetSerialNo;

                    trCheckOutLine.Add(checkoutLine);
                }
            }
            catch
            {
                trCheckOutLine = null;
            }
            return trCheckOutLine.ToArray();
        }

        public TrCheckInLine[] GridCheckInLine()
        {
            dc = new BFASTDataContext();
            List<TrCheckInLine> trCheckInLine = new List<TrCheckInLine>();
            try
            {
                var query = dc.TrxCheckInLine_View("", "", "K");
                foreach (var res in query)
                {
                    TrCheckInLine checkoutLine = new TrCheckInLine();


                    checkoutLine.AssetCode = res.AssetCode;
                    checkoutLine.AssetName = res.AssetName;
                    checkoutLine.AssetSerialNo = res.AssetSerialNo;

                    trCheckInLine.Add(checkoutLine);
                }
            }
            catch
            {
                trCheckInLine = null;
            }
            return trCheckInLine.ToArray();
        }

        public TrDisposeAssetLine[] GridDisposeAssetLine()
        {
            dc = new BFASTDataContext();
            List<TrDisposeAssetLine> trDisposeLine = new List<TrDisposeAssetLine>();
            try
            {
                var query = dc.TrxDisposeAssetLine_View("", "", "K");
                foreach (var res in query)
                {
                    TrDisposeAssetLine disposeLine = new TrDisposeAssetLine();


                    disposeLine.AssetCode = res.AssetCode;
                    disposeLine.AssetName = res.AssetName;
                    disposeLine.AssetSerialNo = res.AssetSerialNo;

                    trDisposeLine.Add(disposeLine);
                }
            }
            catch
            {
                trDisposeLine = null;
            }
            return trDisposeLine.ToArray();
        }

        public TrMaintenanceAsset[] GridMaintenance()
        {
            dc = new BFASTDataContext();
            List<TrMaintenanceAsset> trMaintenance = new List<TrMaintenanceAsset>();
            try
            {
                var query = dc.TrxMaintenanceAsset_View("", "G");
                foreach (var res in query)
                {
                    TrMaintenanceAsset maintenance = new TrMaintenanceAsset();

                    maintenance.MaintenanceNo = res.MaintenanceAssetNo;
                    maintenance.AssetCode = res.AssetCode;
                    maintenance.AssetName = res.AssetName;
                    maintenance.Type = res.NamaType;
                    maintenance.Status = res.NamaStatus;
                    maintenance.ScheduleDate = res.ScheduleDate;
                    maintenance.CompleteDate = res.CompleteDate;
                    maintenance.Cost = res.Cost;
                    maintenance.Notes = res.Notes;

                    trMaintenance.Add(maintenance);
                }
            }
            catch
            {
                trMaintenance = null;
            }
            return trMaintenance.ToArray();
        }
        public TrMaintenanceAssetLine[] GridMaintenanceAssetLine()
        {
            dc = new BFASTDataContext();
            List<TrMaintenanceAssetLine> trMaintenanceLine = new List<TrMaintenanceAssetLine>();
            try
            {
                var query = dc.TrxMaintenanceAssetLine_View("", "", "K");
                foreach (var res in query)
                {
                    TrMaintenanceAssetLine mainLine = new TrMaintenanceAssetLine();


                    mainLine.AssetCode = res.AssetCode;
                    mainLine.AssetName = res.AssetName;
                    mainLine.AssetSerialNo = res.AssetSerialNo;

                    trMaintenanceLine.Add(mainLine);
                }
            }
            catch
            {
                trMaintenanceLine = null;
            }
            return trMaintenanceLine.ToArray();
        }
        public TrTransferAsset[] GridTransfer()
        {
            dc = new BFASTDataContext();
            List<TrTransferAsset> trTransfer = new List<TrTransferAsset>();
            try
            {
                var query = dc.TrxTransferAsset_View("", "G");
                foreach (var res in query)
                {
                    TrTransferAsset transfer = new TrTransferAsset();

                    transfer.TransferAssetNo = res.TransferAssetNo;
                    transfer.Status = res.Status;
                    transfer.NamaStatus = res.NamaStatus;
                    transfer.Type = res.Type;
                    transfer.NamaType = res.NamaType;
                    transfer.TransferDate = res.TransferDate;
                    transfer.TransferAssetNoRef = res.TransferAssetNoRef;
                    transfer.SiteCode = res.SiteCode;
                    transfer.SiteName = res.SiteName;
                    transfer.LocationCode = res.LocationCode;
                    transfer.LocationName = res.LocationName;
                    transfer.Floor = res.Floor;
                    transfer.Notes = res.Notes;

                    trTransfer.Add(transfer);
                }
            }
            catch
            {
                trTransfer = null;
            }
            return trTransfer.ToArray();
        }
        public TrTransferAssetLine[] GridTransferLine()
        {
            dc = new BFASTDataContext();
            List<TrTransferAssetLine> trTransfer = new List<TrTransferAssetLine>();
            try
            {
                var query = dc.TrxTransferAssetLine_View("","", "K");
                foreach (var res in query)
                {
                    TrTransferAssetLine transfer = new TrTransferAssetLine();

                    transfer.TransferAssetNo = res.TransferAssetNo;
                    transfer.AssetCode = res.AssetCode;
                    transfer.AssetName = res.AssetName;
                    transfer.AssetSerialNo = res.AssetSerialNo;
                   
                    trTransfer.Add(transfer);
                }
            }
            catch
            {
                trTransfer = null;
            }
            return trTransfer.ToArray();
        }

        [HttpPost]
        public JsonResult GetPopupAssetCheckOut()
        {
            MsAsset[] msAsset = null;
            msAsset = GridPopupAssetCheckOut();

            return Json(new
            {
                data = msAsset.Select(x => new[] { x.AssetCode, x.AssetName, x.AssetSerialNo })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPopupAssetCheckIn()
        {
            MsAsset[] msAsset = null;
            msAsset = GridPopupAssetCheckIn();

            return Json(new
            {
                data = msAsset.Select(x => new[] { x.AssetCode, x.AssetName, x.AssetSerialNo })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPopupAssetDispose()
        {
            MsAsset[] msAsset = null;
            msAsset = GridPopupAssetDispose();

            return Json(new
            {
                data = msAsset.Select(x => new[] { x.AssetCode, x.AssetName, x.AssetSerialNo })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPopupAssetMaintenance()
        {
            MsAsset[] msAsset = null;
            msAsset = GridPopupAssetMaintenance();

            return Json(new
            {
                data = msAsset.Select(x => new[] { x.AssetCode, x.AssetName, x.AssetSerialNo })
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPopupAssetTransfer()
        {
            MsAsset[] msAsset = null;
            msAsset = GridPopupAssetTransfer();

            return Json(new
            {
                data = msAsset.Select(x => new[] { x.AssetCode, x.AssetName, x.AssetSerialNo })
            }, JsonRequestBehavior.AllowGet);
        }
        //PopUp Person
        [HttpPost]
        public JsonResult GetPopupEmployee()
        {
            MsEmployee[] msEmployee = null;
            msEmployee = GridPopupEmployee();

            return Json(new
            {
                data = msEmployee
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Site
        [HttpPost]
        public JsonResult GetPopupSite()
        {
            MsSite[] msSite = null;
            msSite = GridPopupSite();

            return Json(new
            {
                data = msSite.Select(x => new[] { x.SiteCode, x.SiteName, x.Address, x.City, x.PostalCode })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Category
        [HttpPost]
        public JsonResult GetPopupCategory()
        {
            MsAssetCategory[] msCategory = null;
            msCategory = GridPopupCategory();

            return Json(new
            {
                data = msCategory.Select(x => new[] { x.AssetCategoryCode, x.AssetCategoryName })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Location
        [HttpPost]
        public JsonResult GetPopupLocation(string SiteCode)
        {
            MsLocation[] msLocation = null;
            msLocation = GridPopupLocation(SiteCode);

            return Json(new
            {
                data = msLocation
            }, JsonRequestBehavior.AllowGet);
        }
        
        //PopUp Department
        [HttpPost]
        public JsonResult GetPopupDepartment()
        {
            MsDepartment[] msDepartment = null;
            msDepartment = GridPopupDepartment();

            return Json(new
            {
                data = msDepartment.Select(x => new[] { x.DeptCode, x.DeptName })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Supplier
        [HttpPost]
        public JsonResult GetPopupSupplier()
        {
            MsSupplier[] msSupplier = null;
            msSupplier = GridPopupSupplier();

            return Json(new
            {
                data = msSupplier.Select(x => new[] { x.SupplierCode, x.SupplierName})
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Brand
        [HttpPost]
        public JsonResult GetPopupBrand()
        {
            MsAssetBrand[] msBrand = null;
            msBrand = GridPopupBrand();

            return Json(new
            {
                data = msBrand.Select(x => new[] { x.BrandCode, x.BrandName})
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Model
        [HttpPost]
        public JsonResult GetPopupModel()
        {
            MsAssetModel[] msModel = null;
            msModel = GridPopupModel();

            return Json(new
            {
                data = msModel.Select(x => new[] { x.ModelCode, x.ModelName })
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Type
        [HttpPost]
        public JsonResult GetPopupType()
        {
            MsAssetType[] msType = null;
            msType = GridPopupType();

            return Json(new
            {
                data = msType.Select(x => new[] { x.AssetTypeCode, x.AssetTypeName})
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Currency
        [HttpPost]
        public JsonResult GetPopupCurrency()
        {
            MsCurrency[] msCurrency = null;
            msCurrency = GridPopupCurrency();

            return Json(new
            {
                data = msCurrency.Select(x => new[] { x.CurrencyCode, x.CurrencyName})
            }, JsonRequestBehavior.AllowGet);
        }

        //PopUp Company
        [HttpPost]
        public JsonResult GetPopupCompany()
        {
            MsCompany[] msCompany = null;
            msCompany = GridPopupCompany();

            return Json(new
            {
                data = msCompany.Select(x => new[] { x.CompanyCode, x.CompanyName})
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPopupTypeTransfer()
        {
            MsType[] msType = null;
            msType = GridPopupTypeTransfer();

            return Json(new
            {
                data = msType.Select(x => new[] { x.TypeCode, x.TypeName })
            }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetPopupTransferNoRef()
        {
            TrTransferAsset[] trTransferAsset = null;
            trTransferAsset = GridPopupTransferNoRef();

            return Json(new
            {
                data = trTransferAsset
            }, JsonRequestBehavior.AllowGet);
        }

    }
}