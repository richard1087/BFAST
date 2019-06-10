using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class MsEmployee
    {
        public int? Id { get; set; }
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string Notes { get; set; }
        public int bActive { get; set; }
        public string Aktif { get; set; }
        public int? Floor { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
