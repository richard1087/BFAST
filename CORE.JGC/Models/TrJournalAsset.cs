using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class TrJournalAsset
    {
        public int Id { get; set; }
        public string TransNo { get; set; }
        public DateTime TransDate { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public string CompanyID { get; set; }
        public string RefNo { get; set; }
        public string Notes { get; set; }
        public string Periode { get; set; }
        public decimal Cost { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
