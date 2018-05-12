using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.Purchases
{
    public class PurchaseOrderDetailsVM
    {
        public int? id { get; set; }
        public int? purchaseOrderId { get; set; }
        public int? brandId { get; set; }
        public string brandName { get; set; }
        public int? manufacturingYearId { get; set; }
        public int? manufacturingYear { get; set; }
        public int? modelId { get; set; }
        public string modelName { get; set; }
        public int? categoryId { get; set; }
        public string categoryName { get; set; }
        public int? colorId { get; set; }
        public string color { get; set; }
        public string isNew { get; set; }
        public int? count { get; set; }
        public double? price { get; set; }
    }
    public class PostPurchaseOrderDetailsVM
    {
        public int? id { get; set; }
        public int purchaseOrderId { get; set; }
        public int brandId { get; set; }
        public int manufacturingYearId { get; set; }
        public int modelId { get; set; }
        public int categoryId { get; set; }
        public int colorId { get; set; }
        public string color { get; set; }
        public bool isNew { get; set; }
        public int? count { get; set; }
        public int price { get; set; }
    }

    public class PutPurchaseOrderDetailsVM
    {
        public int? id { get; set; }
        public int purchaseOrderId { get; set; }
        public int brandId { get; set; }
        public int manufacturingYearId { get; set; }
        public int modelId { get; set; }
        public int categoryId { get; set; }
        public int colorId { get; set; }
        public string color { get; set; }
        public bool isNew { get; set; }
        public int? count { get; set; }
        public int price { get; set; }
    }
}
