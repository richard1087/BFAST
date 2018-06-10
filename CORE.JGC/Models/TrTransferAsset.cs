using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class TrTransferAsset
    {
        public int Id { get; set; }
        public string TransferAssetNo { get; set; }
        public string Status { get; set; }
        public string NamaStatus { get; set; }
        public string Type { get; set; }
        public string NamaType { get; set; }
        public DateTime TransferDate { get; set; }
        public string TransferAssetNoRef { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public int Floor { get; set; }
        public string Notes { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
