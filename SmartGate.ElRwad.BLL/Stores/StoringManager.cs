using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL.Stores
{
    public class StoringManager
    {
        private static StoringManager instance;
        public static StoringManager Instance { get { return instance; } }

        static StoringManager()
        {
            instance = new StoringManager();
        }
        private elRwadEntities db = new elRwadEntities();


        public dynamic GetAllAddingPermission()
        {
            var storingMaster = db.Storing_Master.Select(s => new StoryingMasterVM
            {
                Id = s.Id,
                purchaseOrderId = s.PurchaseOrderId,
                storeId = s.StoreId,
                approvalNo = s.ApprovalNo,
                addingdate = s.AddingDate.Value.Year.ToString() + "-" + s.AddingDate.Value.Month.ToString() + "-" + s.AddingDate.Value.Day.ToString(),
                userId = s.UserId,
                userName = s.User.User_Name

            }).ToList();
            return storingMaster;
        }

        public dynamic GetAllAddingPermissionDetails()
        {
            var storingDetails = db.Storing_Details.Select(s => new StoryingDetailsVM
            {
                Id = s.Id,
                vin = s.VIN,
                plateNo = s.PlateNo,
                motorNo = s.MotorNo,
                desiredCategoryId = s.DesiredCategoryId,
                userId = s.UserId,
                storingMasterId = s.Storing_Master_Id

            }).ToList();

            return storingDetails;
        }
        public dynamic GetAddingPermissionById(int id)
        {
            var addingPermission = db.Storing_Master.Where(s => s.Id == id).Select(s => new StoryingMasterVM
            {
                Id = s.Id,
                purchaseOrderId = s.PurchaseOrderId,
                storeId = s.StoreId,
                approvalNo = s.ApprovalNo,
                addingdate = s.AddingDate.Value.ToString("yyyy-MM-dd"),
                userId = s.UserId,
                userName = s.User.User_Name

            }).ToList();

            return addingPermission;
        }
        
        public dynamic GetAddingPermissionDetailsById(int id)
        {
            try
            {
                var s = db.Storing_Details.Where(e => e.Id == id).FirstOrDefault();
                if (s != null)
                {
                    return new StoryingDetailsVM
                    {

                        Id = s.Id,
                        vin = s.VIN,
                        plateNo = s.PlateNo,
                        motorNo = s.MotorNo,
                        desiredCategoryId = s.DesiredCategoryId,
                        userId = s.UserId,
                        storingMasterId = s.Storing_Master_Id
                    };
                }
                else
                {
                    return new StoryingDetailsVM
                    {
                        Id = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //تقرير اذن اضافة
        public dynamic GetAddingPermissionByDate(DateTime fromDate, DateTime toDate)
        {
            var addingPermission = db.Storing_Master.Where(e => e.AddingDate <= toDate && e.AddingDate >= fromDate).Select(s => new StoryingMasterVM
            {
                Id = s.Id,
                purchaseOrderId = s.PurchaseOrderId,
                storeId = s.StoreId,
                approvalNo = s.ApprovalNo,
                addingdate = s.AddingDate.Value.Year.ToString() + "-" + s.AddingDate.Value.Month.ToString() + "-" + s.AddingDate.Value.Day.ToString(),
                userId = s.UserId,
                userName = s.User.User_Name

            }).ToList();

            return addingPermission;

        }
        //تفاصيل اذن الاضافة
        public dynamic GetAddingPermissionReport(int id)
        {
            var addingPermission = db.Storing_Details.Where(e => e.Storing_Master_Id == id).Select(s => new StoryingDetailsReportVM
            {
                Id = s.Id,
                desiredCategoryId = s.DesiredCategoryId,
                storeId = s.Storing_Master.StoreId,
                approvalNo = s.Storing_Master.ApprovalNo,
                vin = s.VIN,
                plateNo = s.PlateNo,
                motorNo = s.MotorNo,
                brandId = s.PurchaseOrderDetail.Brand.Id,
                brand = s.PurchaseOrderDetail.Brand.NameAr,
                modelId = s.PurchaseOrderDetail.Model.Id,
                model = s.PurchaseOrderDetail.Model.NameAr,
                manufacturingYearId = s.PurchaseOrderDetail.ManufacturingYear.Id,
                manufacturingYear = s.PurchaseOrderDetail.ManufacturingYear.Year,
                isNew = s.PurchaseOrderDetail.IsNew,
                isBuying = s.PurchaseOrderDetail.IsBuying,
                isReceived = s.PurchaseOrderDetail.IsReceived,
                colorId = s.PurchaseOrderDetail.Color.Id,
                color = s.PurchaseOrderDetail.Color.NameAr,
                categoryId = s.PurchaseOrderDetail.CarsCategory.Id,
                category = s.PurchaseOrderDetail.CarsCategory.NameAr

            }).ToList();

            return addingPermission;
        }

        //بيان جرد تفصيلى 
        public dynamic GetDetailedInventoryReport(Storing_DetailsVM d)
        {

            var addPerm = db.Storing_Details.Where(e => e.Storing_Master.AddingDate <= d.toDate && e.Storing_Master.AddingDate >= d.fromDate && e.Storing_Master.StoreId == d.storeId).ToList();

            if (d.modelId != 0)
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.ModelId == d.modelId).ToList();

            if (d.brandId != 0)
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.BrandId == d.brandId).ToList();


            var addingPermission = addPerm.Select(s => new InventoryReportVM
            {
                Id = s.Id,
                desiredCategoryId = s.DesiredCategoryId,
                storeId = s.Storing_Master.StoreId,
                approvalNo = s.Storing_Master.ApprovalNo,
                addingDate = s.Storing_Master.AddingDate.Value.Year.ToString() + "-" + s.Storing_Master.AddingDate.Value.Month.ToString() + "-" + s.Storing_Master.AddingDate.Value.Day.ToString(),
                purchaseOrdreId = s.Storing_Master.PurchaseOrderId,
                addingNo = s.Storing_Master.Id,
                //driverOrder = s.Storing_Master.purchaseOrder.Drivers_Orders.
                vin = s.VIN,
                plateNo = s.PlateNo,
                motorNo = s.MotorNo,
                brandId = s.PurchaseOrderDetail.Brand.Id,
                brand = s.PurchaseOrderDetail.Brand.NameAr,
                modelId = s.PurchaseOrderDetail.Model.Id,
                model = s.PurchaseOrderDetail.Model.NameAr,
                manufacturingYearId = s.PurchaseOrderDetail.ManufacturingYear.Id,
                manufacturingYear = s.PurchaseOrderDetail.ManufacturingYear.Year,
                isNew = s.PurchaseOrderDetail.IsNew,
                isBuying = s.PurchaseOrderDetail.IsBuying,
                isReceived = s.PurchaseOrderDetail.IsReceived,
                colorId = s.PurchaseOrderDetail.Color.Id,
                color = s.PurchaseOrderDetail.Color.NameAr,
                categoryId = s.PurchaseOrderDetail.CarsCategory.Id,
                category = s.PurchaseOrderDetail.CarsCategory.NameAr


            }).ToList();

            return addingPermission;
        }

        //بيان جرد اجمالى
        public dynamic GetTotalInventoryReport(Storing_DetailsVM d)
        {

            var addPerm = db.Storing_Details.Where(e => e.Storing_Master.AddingDate <= d.toDate && e.Storing_Master.AddingDate >= d.fromDate && e.Storing_Master.StoreId == d.storeId).ToList();

            if (d.modelId != 0)
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.ModelId == d.modelId).ToList();
            
            if (d.brandId != 0)
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.BrandId == d.brandId).ToList();
            
            var addingPermission = addPerm.Select(s => new InventoryrVM
            {
                Id = s.Id,
                brandId = s.PurchaseOrderDetail.Brand.Id,
                brand = s.PurchaseOrderDetail.Brand.NameAr,
                modelId = s.PurchaseOrderDetail.Model.Id,
                model = s.PurchaseOrderDetail.Model.NameAr,
                count = s.PurchaseOrderDetail.Count


            }).ToList();

            return addingPermission;
        }
        
        public dynamic PostAddingPermission(PermissionVM  p)
        {
            var found = db.Storing_Master.Where(s => s.PurchaseOrderId == p.purchaseOrderId).FirstOrDefault();
            if (found != null)
            {
                return new { result = "already added" };
            }
            var addingPermission = db.Storing_Master.Add(new Storing_Master
            {
                PurchaseOrderId = p.purchaseOrderId,
                StoreId = p.storeId,
                ApprovalNo = p.approvalNo,
                AddingDate = p.addingDate,
                UserId = p.userId
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                addingPermissionId = addingPermission.Id
            };
        }
        
        public dynamic PostAddingPermissionDetails(PermissionDetailsVM p)
        {

            var addingPermissionDetails = db.Storing_Details.Add(new Storing_Details
            {
                VIN = p.vin,
                PlateNo = p.plateNo,
                MotorNo = p.motorNo,
                DesiredCategoryId = p.desiredCategoryId,
                UserId = p.userId,
                Storing_Master_Id = p.addingPermissionId
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                addingPermissionDetailsId = addingPermissionDetails.Id
            };
        }
        
        public dynamic PutAddingPermission(PermissionVM p)
        {
            var addingPermission = db.Storing_Master.Find(p.Id);

            addingPermission.PurchaseOrderId = p.purchaseOrderId;
            addingPermission.StoreId = p.storeId;
            addingPermission.ApprovalNo = p.approvalNo;
            addingPermission.AddingDate = p.addingDate;
            addingPermission.UserId = p.userId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        
        public dynamic PutAddingPermissionDetails(PermissionDetailsVM p)
        {
            var addingPermissionDetails = db.Storing_Details.Find(p.Id);
            addingPermissionDetails.VIN = p.vin;
            addingPermissionDetails.PlateNo = p.plateNo;
            addingPermissionDetails.MotorNo = p.motorNo;
            addingPermissionDetails.DesiredCategoryId = p.desiredCategoryId;
            addingPermissionDetails.UserId = p.userId;
            addingPermissionDetails.Storing_Master_Id = p.addingPermissionId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        
        public dynamic DeleteAddingPermission(int id)
        {
            var addingPermission = db.Storing_Master.Where(e => e.Id == id).FirstOrDefault();
            db.Storing_Master.Remove(addingPermission);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        
        public dynamic DeleteAddingPermissionDetails(int id)
        {
            var addingPermissionDetails = db.Storing_Details.Where(e => e.Id == id).FirstOrDefault();
            db.Storing_Details.Remove(addingPermissionDetails);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
