using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.Transportation
{
    public class DriverOrderVM
    {
        public int? driverOrderId { get; set; }
        public int? driverId { get; set; }
        public string driverName { get; set; }
        public int? purchaseOrderId { get; set; }
        public int supplierId { get; set; }
        public string supplierName { get; set; }
        public string orderDate { get; set; }
        public string Address { get; set; }
        public string notes { get; set; }
        public int? userId { get; set; }
    }

    public class PostDriverOrderVM
    {
        public int? driverOrderId { get; set; }
        public int driverId { get; set; }
        public int purchaseOrderId { get; set; }
        public DateTime orderDate { get; set; }
        public string Address { get; set; }
        public string notes { get; set; }
        public int userId { get; set; }
    }

}
