using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.purchases.Controllers
{
    public class PurchaseOrderDetailsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();



        [HttpGet]
        public dynamic GetAllDetailsPurchaseOrder()
        {
            try
            {
                var purchaseOrderDetails = db.PurchaseOrderDetails.Select(s => new
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
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }


        /// <summary>
        /// get all details related to purchase order
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllDetailsPurchaseOrderByPurchaseOrderId(int purchaseOrderId)
        {
            try
            {
                var purchaseOrderDetails = db.PurchaseOrderDetails.Where(e => e.PurchaseOrderId == purchaseOrderId).Select(s => new
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
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }

        /// <summary>
        /// get Purchase Order by id
        /// </summary>
        /// <param name="PurchaseOrderDetailId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPurchaseOrderDetailById(int id)
        {
            try
            {
                var PurchaseOrderDetail = db.PurchaseOrderDetails.Where(e => e.Id == id).FirstOrDefault();
                if (PurchaseOrderDetail != null)
                {
                    return new
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
                        //isBuying = PurchaseOrderDetail.IsBuying.ToString(),
                        count = PurchaseOrderDetail.Count,
                        price = PurchaseOrderDetail.Price,
                        //isReceived = PurchaseOrderDetail.IsReceived.ToString()

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



        /// <summary>
        /// add new detail for purchase order
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <param name="brandId"></param>
        /// <param name="modelId"></param>
        /// <param name="manufacturingYearId"></param>
        /// <param name="categoryId"></param>
        /// <param name="colorId"></param>
        /// <param name="isNew"></param>
        /// <param name="isBuying"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostPurchaseOrderDetails(int purchaseOrderId, int brandId, int modelId, int manufacturingYearId,
            int categoryId, int colorId, bool isNew, bool isBuying, int count, float price)
        {
            var purchaseOrderDetails = db.PurchaseOrderDetails.Add(new PurchaseOrderDetail
            {
                PurchaseOrderId = purchaseOrderId,
                BrandId = brandId,
                ModelId = modelId,
                ManufacturingYearId = manufacturingYearId,
                CategoryId = categoryId,
                ColorId = colorId,
                IsNew = isNew,
                //IsBuying = isBuying,
                Count = count,
                Price = price
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

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrderDetails(int id, int purchaseOrderId, int brandId, int modelId, int manufacturingYearId,
            int categoryId, int colorId, bool isNew, bool isBuying, int count, float price)
        {
            var purchaseOrderDetails = db.PurchaseOrderDetails.Find(id);
            purchaseOrderDetails.PurchaseOrderId = purchaseOrderId;
            purchaseOrderDetails.BrandId = brandId;
            purchaseOrderDetails.ModelId = modelId;
            purchaseOrderDetails.ManufacturingYearId = manufacturingYearId;
            purchaseOrderDetails.CategoryId = categoryId;
            purchaseOrderDetails.ColorId = colorId;
            purchaseOrderDetails.IsNew = isNew;
            //purchaseOrderDetails.IsBuying = isBuying;
            purchaseOrderDetails.Count = count;
            purchaseOrderDetails.Price = price;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result,
                purchaseOrderDetailsPrice = purchaseOrderDetails.Price * purchaseOrderDetails.Count
            };

        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutIsReceived(int id, bool isReceived)
        {
            var purchaseOrderDetails = db.PurchaseOrderDetails.Find(id);

           // purchaseOrderDetails.IsReceived = isReceived;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }


        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
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
