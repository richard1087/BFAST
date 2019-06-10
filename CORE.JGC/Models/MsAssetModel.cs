using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.JGC.Models
{
    public class MsAssetModel
    {
        public int Id { get; set; }
        public string ModelCode { get; set; }
        public string ModelName { get; set; }
        public string BrandCode { get; set; }
        public string BrandName { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}