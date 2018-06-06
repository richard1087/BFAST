using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class TrTransferAssetLine
    {
        public int Id { get; set; }
        public string TransferAssetNo { get; set; }
        public string AssetCode { get; set; }
        public string AssetName { get; set; }
        public string AssetSerialNo { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
