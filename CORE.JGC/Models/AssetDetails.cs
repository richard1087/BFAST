using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class AssetDetails
    {
        public List<AssetHistory> history { get; set; }
        public List<AssetMaintenance> maintenance { get; set; }
        public List<AssetWarranty> warranty { get; set; }
    }
}
