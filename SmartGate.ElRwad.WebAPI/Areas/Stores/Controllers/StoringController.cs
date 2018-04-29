using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.Stores.Controllers
{
    public class StoringController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetAllAddingPermission()
        {
            var storingMaster = db.Storing_Master.Select(s => new
            {
                id = s.Id,
                purchaseOrderId = s.PurchaseOrderId,
                storeId = s.StoreId,
                approvalNo = s.ApprovalNo,
                addingdate = s.AddingDate.Value.Year.ToString() + "-" + s.AddingDate.Value.Month.ToString() + "-" + s.AddingDate.Value.Day.ToString(),
                userId = s.UserId,
                userName = s.User.User_Name

            }).ToList();
            return storingMaster;
        }

        [HttpGet]
        public dynamic GetAllAddingPermissionDetails()
        {
            var storingDetails = db.Storing_Details.Select(s => new
            {
                id = s.Id,
                vin = s.VIN,
                plateNo = s.PlateNo,
                motorNo = s.MotorNo,
                desiredCategoryId = s.DesiredCategoryId,
                userId = s.UserId,
                storingMasterId = s.Storing_Master_Id

            }).ToList();

            return storingDetails;
        }

        [HttpGet]
        public dynamic GetAddingPermissionById(int id)
        {
            var addingPermission = db.Storing_Master.Where(s => s.Id == id).Select(s => new
            {
                id = s.Id,
                purchaseOrderId = s.PurchaseOrderId,
                storeId = s.StoreId,
                approvalNo = s.ApprovalNo,
                addingdate = s.AddingDate.Value.ToString("yyyy-MM-dd"),
                userId = s.UserId,
                userName = s.User.User_Name

            }).ToList();

            return addingPermission;
        }

        [HttpGet]
        public dynamic GetAddingPermissionDetailsById(int id)
        {
            try
            {
                var s = db.Storing_Details.Where(e => e.Id == id).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {

                        id = s.Id,
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
                    return new
                    {
                        Id = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        //تقرير اذن اضافة
        [HttpGet]
        public dynamic GetAddingPermissionByDate(DateTime fromDate, DateTime toDate)
        {
            var addingPermission = db.Storing_Master.Where(e => e.AddingDate <= toDate && e.AddingDate >= fromDate).Select(s => new
            {
                id = s.Id,
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
        [HttpGet]
        public dynamic GetAddingPermissionReport(int id)
        {
            var addingPermission = db.Storing_Details.Where(e => e.Storing_Master_Id == id).Select(s => new
            {
                id = s.Id,
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
        [HttpGet]
        public dynamic GetDetailedInventoryReport(DateTime fromDate, DateTime toDate, int storeId, int brandId, int modelId)
        {

            var addPerm = db.Storing_Details.Where(e => e.Storing_Master.AddingDate <= toDate && e.Storing_Master.AddingDate >= fromDate && e.Storing_Master.StoreId == storeId).ToList();

            if (modelId != 0)
            {
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.ModelId == modelId).ToList();

            }
            if (brandId != 0)
            {
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.BrandId == brandId).ToList();
            }


            var addingPermission = addPerm.Select(s => new
            {
                id = s.Id,
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
        [HttpGet]
        public dynamic GetTotalInventoryReport(DateTime fromDate, DateTime toDate, int storeId, int brandId, int modelId)
        {

            var addPerm = db.Storing_Details.Where(e => e.Storing_Master.AddingDate <= toDate && e.Storing_Master.AddingDate >= fromDate && e.Storing_Master.StoreId == storeId).ToList();

            if (modelId != 0)
            {
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.ModelId == modelId).ToList();

            }
            if (brandId != 0)
            {
                addPerm = addPerm.Where(e => e.PurchaseOrderDetail.BrandId == brandId).ToList();
            }


            var addingPermission = addPerm.Select(s => new
            {
                id = s.Id,
                brandId = s.PurchaseOrderDetail.Brand.Id,
                brand = s.PurchaseOrderDetail.Brand.NameAr,
                modelId = s.PurchaseOrderDetail.Model.Id,
                model = s.PurchaseOrderDetail.Model.NameAr,
                count = s.PurchaseOrderDetail.Count


            }).ToList();

            return addingPermission;
        }



        [HttpPost]
        public dynamic PostAddingPermission(int purchaseOrderId, int storeId, string approvalNo, DateTime addingDate, int userId)
        {
            var found = db.Storing_Master.Where(s => s.PurchaseOrderId == purchaseOrderId).FirstOrDefault();
            if (found != null)
            {
                return new { result = "already added" };
            }
            var addingPermission = db.Storing_Master.Add(new Storing_Master
            {
                PurchaseOrderId = purchaseOrderId,
                StoreId = storeId,
                ApprovalNo = approvalNo,
                AddingDate = addingDate,
                UserId = userId
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                addingPermissionId = addingPermission.Id
            };
        }

        [HttpPost]
        public dynamic PostAddingPermissionDetails(string vin, string plateNo, string motorNo, int desiredCategoryId, int userId, int addingPermissionId)
        {

            var addingPermissionDetails = db.Storing_Details.Add(new Storing_Details
            {
                VIN = vin,
                PlateNo = plateNo,
                MotorNo = motorNo,
                DesiredCategoryId = desiredCategoryId,
                UserId = userId,
                Storing_Master_Id = addingPermissionId
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                addingPermissionDetailsId = addingPermissionDetails.Id
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutAddingPermission(int id, int purchaseOrderId, int storeId, string approvalNo, DateTime addingDate, int userId)
        {
            var addingPermission = db.Storing_Master.Find(id);

            addingPermission.PurchaseOrderId = purchaseOrderId;
            addingPermission.StoreId = storeId;
            addingPermission.ApprovalNo = approvalNo;
            addingPermission.AddingDate = addingDate;
            addingPermission.UserId = userId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutAddingPermissionDetails(int id, string vin, string plateNo, string motorNo, int desiredCategoryId, int userId, int addingPermissionId)
        {
            var addingPermissionDetails = db.Storing_Details.Find(id);
            addingPermissionDetails.VIN = vin;
            addingPermissionDetails.PlateNo = plateNo;
            addingPermissionDetails.MotorNo = motorNo;
            addingPermissionDetails.DesiredCategoryId = desiredCategoryId;
            addingPermissionDetails.UserId = userId;
            addingPermissionDetails.Storing_Master_Id = addingPermissionId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
