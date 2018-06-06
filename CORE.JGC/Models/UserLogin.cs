using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    class UserLogin
    {
        public int? Jumlah { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string DeptName { get; set; }
        public string LocationName { get; set; }
        public string CompanyName { get; set; }
        public bool bActive { get; set; }
        public bool? bManager { get; set; }

    }
}
