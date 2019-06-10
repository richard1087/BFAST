using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class AssetMaintenance
    {
        public string MaintenanceNo { get; set; }
        public string MaintenanceBy { get; set; }
        public string Status{ get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime CompleteDate { get; set; }
        public decimal Cost { get; set; }
        public string Note { get; set; }
    }
}
