using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using CORE.JGC.POCO;

namespace CORE.JGC.Lib
{
    public class ImageUpload
    {
        public int Width { get; set; }

        public int Height { get; set; }
        
        private readonly string UploadPath = "~/Images";

        public ImageResult RenameUploadFile(HttpPostedFileBase file, Int32 counter = 0, string identitas = "", string nama="")
        {
            var fileName = Path.GetFileName(file.FileName);

            string prepend = "logocompany "+nama+"(";
            string finalFileName = prepend + identitas + ").jpg";
            if (System.IO.File.Exists
                (HttpContext.Current.Request.MapPath(UploadPath + finalFileName)))
            {
                return RenameUploadFile(file, ++counter, identitas, nama);
            }
            return UploadFile(file, finalFileName);
        }

        private ImageResult UploadFile(HttpPostedFileBase file, string fileName)
        {
            ImageResult imageResult = new ImageResult { Success = true, ErrorMessage = null };

            var path =
          Path.Combine(HttpContext.Current.Request.MapPath(UploadPath), fileName);
            string extension = Path.GetExtension(file.FileName);
            
            if (!ValidateExtension(extension))
            {
                imageResult.Success = false;
                imageResult.ErrorMessage = "Invalid Extension";
                return imageResult;
            }

            try
            {
                file.SaveAs(path);

                Image imgOriginal = Image.FromFile(path);
                
                Image imgActual = Scale(imgOriginal);
                imgOriginal.Dispose();
                imgActual.Save(path);
                imgActual.Dispose();

                imageResult.ImageName = fileName;

                return imageResult;
            }
            catch (Exception ex)
            {
                imageResult.Success = false;
                imageResult.ErrorMessage = ex.Message;
                return imageResult;
            }
        }

        private bool ValidateExtension(string extension)
        {
            extension = extension.ToLower();
            switch (extension)
            {
                case ".jpg":
                    return true;
                case ".png":
                    return true;
                case ".gif":
                    return true;
                case ".jpeg":
                    return true;
                default:
                    return false;
            }
        }

        private Image Scale(Image imgPhoto)
        {
            float sourceWidth = imgPhoto.Width;
            float sourceHeight = imgPhoto.Height;
            float destHeight = 0;
            float destWidth = 0;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;
            
            if (Width != 0 && Height != 0)
            {
                destWidth = Width;
                destHeight = Height;
            }
            else if (Height != 0)
            {
                destWidth = (float)(Height * sourceWidth) / sourceHeight;
                destHeight = Height;
            }
            else
            {
                destWidth = Width;
                destHeight = (float)(sourceHeight * Width / sourceWidth);
            }

            Bitmap bmPhoto = new Bitmap((int)destWidth, (int)destHeight,
                                        PixelFormat.Format32bppPArgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, (int)destWidth, (int)destHeight),
                new Rectangle(sourceX, sourceY, (int)sourceWidth, (int)sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();

            return bmPhoto;
        }
    }
}