using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.Sales
{
    public class SalesPurchaseOrderVM
    {
        public int purchaseorderID { get; set; }
        public int userID { get; set; }
        public string username { get; set; }
        public DateTime date { get; set; }
        public string buyerName { get; set; }
        public string adress { get; set; }
        public int? cityId { get; set; }
        public string cityName { get; set; }
        public int? regionId { get; set; }
        public string regionName { get; set; }
        public int? mobNumber { get; set; }
        public int ssn { get; set; }
        public int? brandId { get; set; }
        public string brandName { get; set; }
        public int? modelId { get; set; }
        public string modelName { get; set; }
        public int? category { get; set; }
        public string catgoryName { get; set; }
        public int? colorid { get; set; }
        public string colorName { get; set; }
        public string internalColor { get; set; }
        public bool? carstatus { get; set; }
        public double? price { get; set; }
        public bool? haveInsurance { get; set; }
        public int? insurcompany { get; set; }
        public string insurcompanyName { get; set; }
        public double? totalPrice { get; set; }
        public double? deposit { get; set; }
        public double? remaining { get; set; }
        public bool? paymentMethod { get; set; }
        public int? bankId { get; set; }
        public string bankName { get; set; }
        public bool? isApproval { get; set; }
        public string refusalReasons { get; set; }
    }

    public class PostSalesPurchaseOrderVM
    {
        public int id { get; set; }
        public int userID { get; set; }
        public DateTime date { get; set; }
        public string buyerName { get; set; }
        public string adress { get; set; }
        public int cityId { get; set; }
        public int regionId { get; set; }
        public int mobNumber { get; set; }
        public int ssn { get; set; }
        public int brandId { get; set; }
        public int modelId { get; set; }
        public int category { get; set; }
        public int colorid { get; set; }
        public string internalColor { get; set; }
        public bool carstatus { get; set; }
        public int price { get; set; }
        public bool haveInsurance { get; set; }
        public int insurcompany { get; set; }
        public int totalPrice { get; set; }
    }

    public class post_SalesPurchaseOrderVM
    {
        public int purchaseorderID { get; set; }
        public int userID { get; set; }
        public DateTime date { get; set; }
        public string buyerName { get; set; }
        public string adress { get; set; }
        public int cityId { get; set; }
        public int regionId { get; set; }
        public int mobNumber { get; set; }
        public int ssn { get; set; }
        public int price { get; set; }
        public int bankId { get; set; }
        public bool isApproval { get; set; }
        public bool refusalReasons { get; set; }
        public bool paymentMethod { get; set; }
    }

    public class PutSalesPurchaseOrderVM
    {
        public int purchaseorderID { get; set; }
        public int totalPrice { get; set; }
        public int deposit { get; set; }
        public int remaining { get; set; }
        public bool paymentMethod { get; set; }
        public int bankId { get; set; }
    }

  



}
