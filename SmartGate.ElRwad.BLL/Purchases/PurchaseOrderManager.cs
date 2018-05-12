using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL.Purchases
{
    public class PurchaseOrderManager
    {
        private static PurchaseOrderManager instance;
        public static PurchaseOrderManager Instance { get { return instance; } }

        static PurchaseOrderManager()
        {
            instance = new PurchaseOrderManager();
        }
        private elRwadEntities db = new elRwadEntities();


        public dynamic GetAllPurchaseOrder()
        {
            try
            {
                List<PurchaseOrderDetailVM> purchaseOrder = db.purchaseOrders.Select(s => new PurchaseOrderDetailVM
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
                return ex.Message;
            }
        }
        
        public dynamic GetAllPurchaseOrderByDateNotAccepted(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date && e.IsApprovFinancialManag == false).Select(s => new PurchaseOrderDetailVM
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
                return ex.Message;
            }
        }
        
        public dynamic GetAllPurchaseOrderByDateAccepted(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date && e.IsApprovFinancialManag == true).Select(s => new PurchaseOrderDetailVM
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
                return ex.Message;
            }
        }
        public dynamic GetAllPurchaseOrderByDateNotTakedActions(DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<PurchaseOrderDetailVM> purchaseOrder = db.purchaseOrders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date && e.IsApprovFinancialManag == null).Select(s => new PurchaseOrderDetailVM
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
                return ex.Message;
            }
        }

        public dynamic GetAllPurchaseOrderNotTakedActions()
        {
            try
            {
                List<PurchaseOrderDetailVM> purchaseOrder = db.purchaseOrders.Where(e => e.IsApprovFinancialManag == null).Select(s => new PurchaseOrderDetailVM
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
                return ex.Message;
            }
        }

        public dynamic GetByPurchaseOrederId(int id)
        {
            try
            {
                var purchaseOrder = db.purchaseOrders.Where(s => s.Id == id).FirstOrDefault();
                if (purchaseOrder != null)
                {
                    return new PurchaseOrderDetailVM
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
                    return new PurchaseOrderDetailVM
                    {
                        id = 0
                    };

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public dynamic PostPurchaseOrder(PurchaseOrderVM p)
        {
            var purchaseOrder = db.purchaseOrders.Add(new purchaseOrder
            {
                UserId = p.userId,
                BranchId = p.branchId,
                SupplierId = p.supplierId,
                SupplierRepresentativeId = p.supplierRepresentativeId,
                IsApprovFinancialManag = null,
                OrderDate = p.orderDate

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                id = purchaseOrder.Id

            };
        }
        
        public dynamic PutPurchaseOrder(PutPurchaseOrderVM p)
        {
            var purchaseOrder = db.purchaseOrders.Find(p.id);
            purchaseOrder.TotalPrice = p.totalPrice;
            purchaseOrder.ReceivingAddress = p.receivingAddress;
            purchaseOrder.AddressRegionId = p.addressRegionId;
            purchaseOrder.AddressCityId = p.addressCityId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }


        public dynamic PutPurchaseOrder(PurchaseVM p)
        {
            var purchaseOrder = db.purchaseOrders.Find(p.id);
            if (purchaseOrder.IsApprovFinancialManag == true)
            {
                return new
                {
                    result = "can't update in approved orders"
                };
            }

            purchaseOrder.UserId = p.userId;
            purchaseOrder.BranchId = p.branchId;
            purchaseOrder.SupplierId = p.supplierId;
            purchaseOrder.SupplierRepresentativeId = p.supplierRepresentativeId;
            purchaseOrder.ReceivingAddress = p.receivingAddress;
            purchaseOrder.AddressRegionId = p.addressRegionId;
            purchaseOrder.AddressCityId = p.addressCityId;
            purchaseOrder.OrderDate = p.orderDate;
            purchaseOrder.IsApprovFinancialManag = null;



            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }



        public dynamic PutPurchaseOrder(PutTotalPriceVM p)
        {
            var purchaseOrder = db.purchaseOrders.Find(p.id);
            purchaseOrder.TotalPrice = p.totalPrice;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }

        
        public dynamic PutPurchaseOrder(PutIsApprovFinancialManagVM p)
        {
            var purchaseOrder = db.purchaseOrders.Find(p.id);
            purchaseOrder.IsApprovFinancialManag = p.isApprovFinancialManag;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                reslt = result
            };

        }

        
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
