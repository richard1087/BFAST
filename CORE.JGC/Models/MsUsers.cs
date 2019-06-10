using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.JGC.Models
{
    public class MsUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
        public string SiteCode { get; set; }
        public string SiteName { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string Floor { get; set; }
        public bool bActive { get; set; }
        public bool bManager { get; set; }
        public string GroupMenuCode { get; set; }
        public string GroupMenuName { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}