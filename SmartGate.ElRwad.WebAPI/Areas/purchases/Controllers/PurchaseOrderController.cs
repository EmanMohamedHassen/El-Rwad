using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.purchases.Controllers
{
    public class PurchaseOrderController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// get all purchase order
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllPurchaseOrder()
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Select(s => new
                {
                    id = s.Id,
                    userId = s.UserId,
                    branchId = s.BranchId,
                    showingBranch = s.Showing_Branches.NameAr,
                    supplierRepresentative = s.SuppliersRepresentative.NameAr,
                    supplierId = s.SupplierId,
                    supplierName = s.Supplier.NameAr,
                    supplierRepresentativeId = s.SupplierRepresentativeId,
                    totalPrice = s.TotalPrice,
                    receivingAddress = s.ReceivingAddress,
                    addressRegionId = s.AddressRegionId,
                    addressCityId = s.AddressCityId,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                    isApprovFinancialManag = s.IsApprovFinancialManag.ToString()

                }).ToList();
                return purchaseOrder;
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
        /// Get all purchase orders between two dates
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllPurchaseOrderByDateNotAccepted(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date && e.IsApprovFinancialManag == false).Select(s => new
                {
                    id = s.Id,
                    userId = s.UserId,
                    branchId = s.BranchId,
                    showingBranch = s.Showing_Branches.NameAr,
                    supplierRepresentative = s.SuppliersRepresentative.NameAr,
                    supplierId = s.SupplierId,
                    supplierName = s.Supplier.NameAr,
                    supplierRepresentativeId = s.SupplierRepresentativeId,
                    totalPrice = s.TotalPrice,
                    receivingAddress = s.ReceivingAddress,
                    addressRegionId = s.AddressRegionId,
                    addressCityId = s.AddressCityId,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString()

                }).ToList();
                return purchaseOrder;
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

        [HttpGet]
        public dynamic GetAllPurchaseOrderByDateAccepted(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date && e.IsApprovFinancialManag == true).Select(s => new
                {
                    id = s.Id,
                    userId = s.UserId,
                    branchId = s.BranchId,
                    showingBranch = s.Showing_Branches.NameAr,
                    supplierRepresentative = s.SuppliersRepresentative.NameAr,
                    supplierId = s.SupplierId,
                    supplierName = s.Supplier.NameAr,
                    supplierRepresentativeId = s.SupplierRepresentativeId,
                    totalPrice = s.TotalPrice,
                    receivingAddress = s.ReceivingAddress,
                    addressRegionId = s.AddressRegionId,
                    addressCityId = s.AddressCityId,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString()

                }).ToList();

                return purchaseOrder;
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
        [HttpGet]
        public dynamic GetAllPurchaseOrderByDateNotTakedActions(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date && e.IsApprovFinancialManag == null).Select(s => new
                {
                    id = s.Id,
                    userId = s.UserId,
                    branchId = s.BranchId,
                    showingBranch = s.Showing_Branches.NameAr,
                    supplierRepresentative = s.SuppliersRepresentative.NameAr,
                    supplierId = s.SupplierId,
                    supplierName = s.Supplier.NameAr,
                    supplierRepresentativeId = s.SupplierRepresentativeId,
                    totalPrice = s.TotalPrice,
                    receivingAddress = s.ReceivingAddress,
                    addressRegionId = s.AddressRegionId,
                    addressCityId = s.AddressCityId,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString()

                }).ToList();
                return purchaseOrder;
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

        public dynamic GetAllPurchaseOrderNotTakedActions()
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(e => e.IsApprovFinancialManag == null).Select(s => new
                {
                    id = s.Id,
                    userId = s.UserId,
                    branchId = s.BranchId,
                    showingBranch = s.Showing_Branches.NameAr,
                    supplierRepresentative = s.SuppliersRepresentative.NameAr,
                    supplierId = s.SupplierId,
                    supplierName = s.Supplier.NameAr,
                    supplierRepresentativeId = s.SupplierRepresentativeId,
                    totalPrice = s.TotalPrice,
                    receivingAddress = s.ReceivingAddress,
                    addressRegionId = s.AddressRegionId,
                    addressCityId = s.AddressCityId,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString()

                }).ToList();
                return purchaseOrder;
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
        /// get purchase order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetByPurchaseOrederId(int id)
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(s => s.Id == id).FirstOrDefault();
                if (purchaseOrder != null)
                {
                    return new
                    {
                        userId = purchaseOrder.UserId,
                        branchId = purchaseOrder.BranchId,
                        showingBranch = purchaseOrder.Showing_Branches.NameAr,
                        supplierRepresentative = purchaseOrder.SuppliersRepresentative.NameAr,
                        supplierId = purchaseOrder.SupplierId,
                        supplierName = purchaseOrder.Supplier.NameAr,
                        supplierRepresentativeId = purchaseOrder.SupplierRepresentativeId,
                        totalPrice = purchaseOrder.TotalPrice,
                        receivingAddress = purchaseOrder.ReceivingAddress,
                        addressRegionId = purchaseOrder.AddressRegionId,
                        addressCityId = purchaseOrder.AddressCityId,
                        orderDate = purchaseOrder.OrderDate.Value.ToString("yyyy-MM-dd"),
                        isApprovFinancialManag = purchaseOrder.IsApprovFinancialManag.ToString()
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
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="branchId"></param>
        /// <param name="supplierId"></param>
        /// <param name="supplierRepresentativeId"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostPurchaseOrder(int userId, int branchId, int supplierId, int supplierRepresentativeId, DateTime orderDate)
        {
            var purchaseOrder = db.purchaseOrders.Add(new purchaseOrder
            {
                UserId = userId,
                BranchId = branchId,
                SupplierId = supplierId,
                SupplierRepresentativeId = supplierRepresentativeId,
                IsApprovFinancialManag = null,
                OrderDate = orderDate

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                id = purchaseOrder.Id

            };
        }



        /// <summary>
        /// to add purchase order's   total price & receiving Address & address Region & address City
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <param name="totalPrice"></param>
        /// <param name="receivingAddress"></param>
        /// <param name="addressRegionId"></param>
        /// <param name="addressCityId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrder(int id, float totalPrice, string receivingAddress, int addressRegionId, int addressCityId)
        {
            var purchaseOrder = db.purchaseOrders.Find(id);
            purchaseOrder.TotalPrice = totalPrice;
            purchaseOrder.ReceivingAddress = receivingAddress;
            purchaseOrder.AddressRegionId = addressRegionId;
            purchaseOrder.AddressCityId = addressCityId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }


        /// <summary>
        /// update all data in purchase order without total price
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userId"></param>
        /// <param name="branchId"></param>
        /// <param name="supplierId"></param>
        /// <param name="supplierRepresentativeId"></param>
        /// <param name="receivingAddress"></param>
        /// <param name="addressRegionId"></param>
        /// <param name="addressCityId"></param>
        /// <param name="orderDate"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrder(int id, int userId, int branchId, int supplierId, int supplierRepresentativeId
            , string receivingAddress, int addressRegionId, int addressCityId, DateTime orderDate)
        {
            var purchaseOrder = db.purchaseOrders.Find(id);
            if (purchaseOrder.IsApprovFinancialManag == true)
            {
                return new
                {
                    result = "can't update in approved orders"
                };
            }

            purchaseOrder.UserId = userId;
            purchaseOrder.BranchId = branchId;
            purchaseOrder.SupplierId = supplierId;
            purchaseOrder.SupplierRepresentativeId = supplierRepresentativeId;
            purchaseOrder.ReceivingAddress = receivingAddress;
            purchaseOrder.AddressRegionId = addressRegionId;
            purchaseOrder.AddressCityId = addressCityId;
            purchaseOrder.OrderDate = orderDate;
            purchaseOrder.IsApprovFinancialManag = null;



            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }



        /// <summary>
        /// update total price
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <param name="totalPrice"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrder(int id, float totalPrice)
        {
            var purchaseOrder = db.purchaseOrders.Find(id);
            purchaseOrder.TotalPrice = totalPrice;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }

        /// <summary>
        /// approv by financial managment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isApprovFinancialManag"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrder(int id, bool isApprovFinancialManag)
        {
            var purchaseOrder = db.purchaseOrders.Find(id);
            purchaseOrder.IsApprovFinancialManag = isApprovFinancialManag;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }

        /// <summary>
        /// delete purchase order
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
        public dynamic DeletePurchaseOrder(int id)
        {
            var purchaseOrder = db.purchaseOrders.Where(s => s.Id == id).FirstOrDefault();
            db.purchaseOrders.Remove(purchaseOrder);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

    }
}
