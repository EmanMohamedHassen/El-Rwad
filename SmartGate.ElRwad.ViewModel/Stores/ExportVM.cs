using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.Stores
{
    public class ExportVM
    {
        public int? ExportMainID { get; set; }
        public bool ForSale { get; set; }
        public int SellOrder_ID { get; set; }
        public int StoreID { get; set; }
        public int ToStoreID { get; set; }
    }

    public class ExportDetailsVM
    {
        public int? ExportDetails_ID { get; set; }
        public int exportMainId { get; set; }
        public int carId { get; set; }
        public DateTime exportDate { get; set; }
    }
}
