using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class MsBarcode
    {
        public int Id { get; set; }
        public string BarcodeCode { get; set; }
        public string SizeBarcode { get; set; }
        public string TitleBarcode { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
