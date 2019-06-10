using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
   public class TrTagAssetLine
    {
        public int Id { get; set; }
        public string TagNo { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string DeptCode { get; set; }
        public string SiteCode { get; set; }
        public string LocationCode { get; set; }
        public int Floor { get; set; }
        public string AssignTo { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
