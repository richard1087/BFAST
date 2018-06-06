using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class TrJournalAssetLine
    {
        public int Id { get; set; }
        public string TransNo { get; set; }
        public string OrderNo { get; set; }
        public string NoAccount { get; set; }
        public string KetAccount { get; set; }
        public decimal Debet { get; set; }
        public decimal Kredit { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
        public string Uby { get; set; }
        public DateTime Uon { get; set; }
    }
}
