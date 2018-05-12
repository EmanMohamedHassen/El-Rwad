using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL.Purchases
{
    public class PurchaseOrderDetailsManager
    {
        private static PurchaseOrderDetailsManager instance;
        public static PurchaseOrderDetailsManager Instance { get { return instance; } }

        static PurchaseOrderDetailsManager()
        {
            instance = new PurchaseOrderDetailsManager();
        }
        private elRwadEntities db = new elRwadEntities();

        
        public dynamic GetAllDetailsPurchaseOrder()
        {
            try
            {
                var purchaseOrderDetails = db.PurchaseOrderDetails.Select(s => new PurchaseOrderDetailsVM
                {
                    id = s.Id,
                    purchaseOrderId = s.PurchaseOrderId,
                    brandId = s.BrandId,
                    brandName = s.Brand.NameAr,
                    modelId = s.ModelId,
                    modelName = s.Model.NameAr,
                    manufacturingYearId = s.ManufacturingYearId,
                    manufacturingYear = s.ManufacturingYear.Year,
                    categoryId = s.CategoryId,
                    categoryName = s.CarsCategory.NameAr,
                    colorId = s.ColorId,
                    color = s.Color.NameAr,
                    isNew = s.IsNew.ToString(),
                    //isBuying = s.IsBuying.ToString(),
                    count = s.Count,
                    price = s.Price,
                    //isReceived = s.IsReceived.ToString()

                }).ToList();
                return purchaseOrderDetails;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public dynamic GetAllDetailsPurchaseOrderByPurchaseOrderId(int purchaseOrderId)
        {
            try
            {
                var purchaseOrderDetails = db.PurchaseOrderDetails.Where(e => e.PurchaseOrderId == purchaseOrderId).Select(s => new PurchaseOrderDetailsVM
                {
                    id = s.Id,
                    purchaseOrderId = s.PurchaseOrderId,
                    brandId = s.BrandId,
                    brandName = s.Brand.NameAr,
                    modelId = s.ModelId,
                    modelName = s.Model.NameAr,
                    manufacturingYearId = s.ManufacturingYearId,
                    manufacturingYear = s.ManufacturingYear.Year,
                    categoryId = s.CategoryId,
                    categoryName = s.CarsCategory.NameAr,
                    colorId = s.ColorId,
                    color = s.Color.NameAr,
                    isNew = s.IsNew.ToString(),
                    count = s.Count,
                    price = s.Price,

                }).ToList();
                return purchaseOrderDetails;
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

        public dynamic GetPurchaseOrderDetailById(int id)
        {
            try
            {
                var PurchaseOrderDetail = db.PurchaseOrderDetails.Where(e => e.Id == id).FirstOrDefault();
                if (PurchaseOrderDetail != null)
                {
                    return new PurchaseOrderDetailsVM
                    {

                        id = PurchaseOrderDetail.Id,
                        purchaseOrderId = PurchaseOrderDetail.PurchaseOrderId,
                        brandId = PurchaseOrderDetail.BrandId,
                        brandName = PurchaseOrderDetail.Brand.NameAr,
                        modelId = PurchaseOrderDetail.ModelId,
                        modelName = PurchaseOrderDetail.Model.NameAr,
                        manufacturingYearId = PurchaseOrderDetail.ManufacturingYearId,
                        manufacturingYear = PurchaseOrderDetail.ManufacturingYear.Year,
                        categoryId = PurchaseOrderDetail.CategoryId,
                        categoryName = PurchaseOrderDetail.CarsCategory.NameAr,
                        colorId = PurchaseOrderDetail.ColorId,
                        color = PurchaseOrderDetail.Color.NameAr,
                        isNew = PurchaseOrderDetail.IsNew.ToString(),
                        count = PurchaseOrderDetail.Count,
                        price = PurchaseOrderDetail.Price,

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
                return ex.Message;
            }
        }



        
        public dynamic PostPurchaseOrderDetails(PostPurchaseOrderDetailsVM p)
        {
            var purchaseOrderDetails = db.PurchaseOrderDetails.Add(new PurchaseOrderDetail
            {
                PurchaseOrderId = p.purchaseOrderId,
                BrandId = p.brandId,
                ModelId = p.modelId,
                ManufacturingYearId = p.manufacturingYearId,
                CategoryId = p.categoryId,
                ColorId = p.colorId,
                IsNew = p.isNew,
                Count = p.count,
                Price = p.price
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                //M.Hamed Add Price*Count to developr to sum total for all items
                //from purchaseOrderDetailsPrice = purchaseOrderDetails.Price 
                purchaseOrderDetailsPrice = purchaseOrderDetails.Price * purchaseOrderDetails.Count,
                purchaseOrderDetailsId = purchaseOrderDetails.Id

            };
        }


        public dynamic PutPurchaseOrderDetails(PostPurchaseOrderDetailsVM p)
        {
            var purchaseOrderDetails = db.PurchaseOrderDetails.Find(p.id);
            purchaseOrderDetails.PurchaseOrderId = p.purchaseOrderId;
            purchaseOrderDetails.BrandId = p.brandId;
            purchaseOrderDetails.ModelId = p.modelId;
            purchaseOrderDetails.ManufacturingYearId = p.manufacturingYearId;
            purchaseOrderDetails.CategoryId = p.categoryId;
            purchaseOrderDetails.ColorId = p.colorId;
            purchaseOrderDetails.IsNew = p.isNew;
            purchaseOrderDetails.Count = p.count;
            purchaseOrderDetails.Price = p.price;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result,
                purchaseOrderDetailsPrice = purchaseOrderDetails.Price * purchaseOrderDetails.Count
            };

        }

        //public dynamic PutIsReceived(int id, bool isReceived)
        //{
        //    var purchaseOrderDetails = db.PurchaseOrderDetails.Find(id);

        //    purchaseOrderDetails.IsReceived = isReceived;

        //    var result = db.SaveChanges() > 0 ? true : false;
        //    return new
        //    {
        //        reslt = result
        //    };

        //}



        public dynamic DeletePurchaseOrderDetails(int id)
        {
            var purchaseOrderDetails = db.PurchaseOrderDetails.Where(s => s.Id == id).FirstOrDefault();
            db.PurchaseOrderDetails.Remove(purchaseOrderDetails);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
