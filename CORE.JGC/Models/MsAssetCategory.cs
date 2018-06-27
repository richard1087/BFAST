using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.JGC.Models
{
    public class MsAssetCategory
    {
        public int Id { get; set; }
        public string AssetCategoryCode { get; set; }
        public string AssetCategoryName { get; set; }
        public string Initial { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}