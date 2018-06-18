using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CORE.JGC.Models
{
    public class MsCompany
    {
        public int Id { get; set; }
        public string CompanyID { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Telephone { get; set; }
        public string Aktif { get; set; }
        public bool ?bActive { get; set; }
        public string Iby { get; set; }
        public string status { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}