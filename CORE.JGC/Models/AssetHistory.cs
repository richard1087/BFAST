using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class AssetHistory
    {
        public int No { get; set; }
        public string AssetCode { get; set; }
        public DateTime Date { get; set; }
        public string Event { get; set; }
        public string Status { get; set; }
        public string StatusFrom { get; set; }
        public string Iby { get; set; }
    }
}
