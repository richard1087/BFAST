using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.JGC.Models
{
    public class TrMaintenanceAsset
    {
        public int Id { get; set; }
        public string MaintenanceNo { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public DateTime CompleteDate { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public string AssignTo { get; set; }
        public string Damage { get; set; }
        public string Notes { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string AssetSerialNo { get; set; }
        public decimal? Cost { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}