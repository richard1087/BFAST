using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.JGC.Models
{
    public class MsExchangeRate
    {
        public int Id { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCodeConvert { get; set; }
        public string CurrencyNameConvert { get; set; }
        public decimal? ExchangeRate { get; set; }
        public string Iby { get; set; }
        public DateTime Ion { get; set; }
    }
}
