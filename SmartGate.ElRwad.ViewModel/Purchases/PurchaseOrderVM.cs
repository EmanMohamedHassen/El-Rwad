using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.Purchases
{
    public class PurchaseOrderDetailVM
    {
        public int? id { get; set; }
        public int? userId { get; set; }
        public int? branchId { get; set; }
        public string showingBranch { get; set; }
        public string supplierRepresentative { get; set; }
        public int? supplierId { get; set; }
        public string supplierName { get; set; }
        public int? supplierRepresentativeId { get; set; }
        public double? totalPrice { get; set; }
        public string receivingAddress { get; set; }
        public int? addressRegionId { get; set; }
        public int? addressCityId { get; set; }
        public string orderDate { get; set; }
        public string isApprovFinancialManag { get; set; }

    }

    public class PurchaseOrderVM
    {
        //public int? id { get; set; }
        public int userId { get; set; }
        public int branchId { get; set; }
        public int supplierId { get; set; }
        public int supplierRepresentativeId { get; set; }
        public DateTime orderDate { get; set; }
        public bool isApprovFinancialManag { get; set; }

    }
    public class PutPurchaseOrderVM
    {
        public int? id { get; set; }
        public int addressRegionId { get; set; }
        public string receivingAddress { get; set; }
        public int addressCityId { get; set; }
        public int totalPrice { get; set; }

    }

    public class PurchaseVM
    {
        public int? id { get; set; }
        public int userId { get; set; }
        public int branchId { get; set; }
        public int supplierId { get; set; }
        public int supplierRepresentativeId { get; set; }
        public string receivingAddress { get; set; }
        public int? addressRegionId { get; set; }
        public int? addressCityId { get; set; }
        public DateTime orderDate { get; set; }

    }

    public class PutTotalPriceVM
    {
        public int id { get; set; }
        public int totalPrice { get; set; }

    }

    public class PutIsApprovFinancialManagVM
    {
        public int id { get; set; }
        public bool isApprovFinancialManag { get; set; }

    }
}
