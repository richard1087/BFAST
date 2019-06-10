using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class UtilMenu
    {
        public string MenuCode { get; set; }
        public string MenuName { get; set; }
        public string MenuPath { get; set; }
        public int? LevelMenu { get; set; }
        public string ParentMenu { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
