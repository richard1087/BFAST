using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.JGC.Models
{
    public class TrCheckOut
    {
        public int Id { get; set; }
        public string CheckOutNo { get; set; }
        public string Status { get; set; }
        public string NamaStatus { get; set; }
        public string Type { get; set; }
        public string NamaType { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime? CheckOutDueDate { get; set; }
        public string AssignTo { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string Notes { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}