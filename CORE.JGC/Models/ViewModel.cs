using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CORE.JGC.Models
{
    public class ViewModel
    {
        public List<TrCheckIn> trCheckIn { get; set; }
        public List<TrCheckInLine> trCheckInLine { get; set; }
        public List<TrCheckOut> trCheckOut { get; set; }
        public List<TrCheckOutLine> trCheckOutLine { get; set; }
        public List<TrDisposeAsset> trDisposeAsset { get; set; }
        public List<TrDisposeAssetLine> trDisposeAssetLine { get; set; }
        public List<TrMaintenanceAsset> trMaintenanceAsset { get; set; }
        public List<TrMaintenanceAssetLine> trMaintenanceAssetLine { get; set; }
        public List<TrTransferAsset> trTransferAsset { get; set; }
        public List<TrTransferAssetLine> trTransferAssetLine { get; set; }
        public List<TrJournalAsset> trJournalAsset { get; set; }
        public List<TrJournalAssetLine> trJournalAssetLine { get; set; }
        public List<TrTagAsset> trTagAsset { get; set; }
        public List<TrTagAssetLine> trTagAssetLine { get; set; }

    }
}
