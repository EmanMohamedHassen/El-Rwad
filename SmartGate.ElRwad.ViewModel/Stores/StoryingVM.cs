using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.Stores
{
    public class StoryingMasterVM
    {
        public int? Id { get; set; }
        public int? purchaseOrderId { get; set; }
        public int? storeId { get; set; }
        public string approvalNo { get; set; }
        public string addingdate { get; set; }
        public int? userId { get; set; }
        public string userName { get; set; }
    }

    public class StoryingDetailsVM
    {
        public int? Id { get; set; }
        public string vin { get; set; }
        public string plateNo { get; set; }
        public string motorNo { get; set; }
        public int? desiredCategoryId { get; set; }
        public int? userId { get; set; }
        public int? storingMasterId { get; set; }
    }
    public class InventoryrVM
    {
        public int? Id { get; set; }
        public int brandId { get; set; }
        public string brand { get; set; }
        public int modelId { get; set; }
        public string model { get; set; }
        public string addingdate { get; set; }
        public int? count { get; set; }
    }

    public class Storing_DetailsVM
    {
        public int brandId { get; set; }
        public int modelId { get; set; }
        public int storeId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
    }
    public class StoryingDetailsReportVM
    {
        public int? Id { get; set; }
        public int? desiredCategoryId { get; set; }
        public string vin { get; set; }
        public int brandId { get; set; }
        public string brand { get; set; }
        public string plateNo { get; set; }
        public string motorNo { get; set; }
        public int? storeId { get; set; }
        public int userId { get; set; }
        public string approvalNo { get; set; }
        public int modelId { get; set; }
        public string model { get; set; }
        public int manufacturingYearId { get; set; }
        public int? manufacturingYear { get; set; }
        public bool? isNew { get; set; }
        public bool? isBuying { get; set; }
        public bool? isReceived { get; set; }
        public int colorId { get; set; }
        public string color { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
    }
    public class InventoryReportVM
    {
        public int? Id { get; set; }
        public int? desiredCategoryId { get; set; }
        public string addingDate { get; set; }
        public int? purchaseOrdreId { get; set; }
        public int addingNo { get; set; }
        public string vin { get; set; }
        public int brandId { get; set; }
        public string brand { get; set; }
        public string plateNo { get; set; }
        public string motorNo { get; set; }
        public int? storeId { get; set; }
        public int userId { get; set; }
        public string approvalNo { get; set; }
        public int modelId { get; set; }
        public string model { get; set; }
        public int manufacturingYearId { get; set; }
        public int? manufacturingYear { get; set; }
        public bool? isNew { get; set; }
        public bool? isBuying { get; set; }
        public bool? isReceived { get; set; }
        public int colorId { get; set; }
        public string color { get; set; }
        public int categoryId { get; set; }
        public string category { get; set; }
    }
    //Master
    public class PermissionVM
    {
        public int? Id { get; set; }
        public int purchaseOrderId { get; set; }
        public DateTime addingDate { get; set; }
        public int purchaseOrdreId { get; set; }
        public string approvalNo { get; set; }
        public int storeId { get; set; }
        public int userId { get; set; }

    }
    public class PermissionDetailsVM
    {
        public int? Id { get; set; }
        public string vin { get; set; }
        public int desiredCategoryId { get; set; }
        public string plateNo { get; set; }
        public int addingPermissionId { get; set; }
        public string motorNo { get; set; }
        public int userId { get; set; }

    }
}
