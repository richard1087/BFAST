using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class AssetWarranty
    {
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public int WarrantyMonth { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public int Active { get; set; }
    }
}
