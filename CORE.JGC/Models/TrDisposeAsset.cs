using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.JGC.Models
{
    public class TrDisposeAsset
    {
        public int Id { get; set; }
        public string DisposeNo { get; set; }
        public string Status { get; set; }
        public string NamaStatus { get; set; }
        public DateTime DisposeDate { get; set; }
        public string DisposeTo { get; set; }
        public string Reason { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}