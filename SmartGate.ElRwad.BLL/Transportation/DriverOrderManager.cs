using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel.Transportation;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL.Transportation
{
   public class DriverOrderManager
    {
        private static DriverOrderManager instance;
        public static DriverOrderManager Instance { get { return instance; } }
        static DriverOrderManager()
        {
            instance = new DriverOrderManager();
        }
        private elRwadEntities db = new elRwadEntities();


            public dynamic GetAllDriversOrder(DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<DriverOrderVM> driverOrder = db.Drivers_Orders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date).Select(s => new DriverOrderVM
                    {
                        driverOrderId = s.Id,
                        driverId = s.DriverId,
                        driverName = s.Employee.FullName,
                        purchaseOrderId = s.PurchaseOrderId,
                        supplierId = s.purchaseOrder.Supplier.Id,
                        supplierName = s.purchaseOrder.Supplier.NameAr,
                        orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                        Address = s.Address,
                        notes = s.Notes,
                        userId = s.UserId
                    }).ToList();
                    return driverOrder;
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



            public dynamic GetDriverOrderById(int driverOrderId)
            {

                List<DriverOrderVM> driverOrder = db.Drivers_Orders.Where(e => e.Id == driverOrderId).Select(s => new DriverOrderVM
                {

                    driverOrderId = s.Id,
                    driverId = s.DriverId,
                    driverName = s.Employee.FullName,
                    purchaseOrderId = s.PurchaseOrderId,
                    supplierId = s.purchaseOrder.Supplier.Id,
                    supplierName = s.purchaseOrder.Supplier.NameAr,
                    orderDate = s.OrderDate.Value.ToString("yyyy-MM-dd"),
                    Address = s.Address,
                    notes = s.Notes,
                    userId = s.UserId

                }).ToList();
                return driverOrder;
            }


            public dynamic GetByPurchaseOrderId(int purchaseOrderId)
            {
                try
                {
                    var driverOrder = db.Drivers_Orders.Where(e => e.PurchaseOrderId == purchaseOrderId).FirstOrDefault();
                    if (driverOrder != null)
                    {
                        return new DriverOrderVM
                        {

                            driverOrderId = driverOrder.Id,

                            driverId = driverOrder.DriverId,
                            driverName = driverOrder.Employee.FullName,

                            purchaseOrderId = driverOrder.PurchaseOrderId,
                            supplierId = driverOrder.purchaseOrder.Supplier.Id,
                            supplierName = driverOrder.purchaseOrder.Supplier.NameAr,
                            orderDate = driverOrder.OrderDate.Value.Year.ToString() + "-" + driverOrder.OrderDate.Value.Month.ToString() + "-" + driverOrder.OrderDate.Value.Day.ToString(),
                            Address = driverOrder.Address,

                            notes = driverOrder.Notes,
                            userId = driverOrder.UserId

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

            public dynamic GetByDriverId(int driverId)
            {
                try
                {
                    var driver = db.Drivers_Orders.Where(e => e.DriverId == driverId).FirstOrDefault();
                    if (driver != null)
                    {
                        return new
                        {

                            driverOrderId = driver.Id,
                            driverId = driver.DriverId,
                            driverName = driver.Employee.FullName,

                            supplierId = driver.purchaseOrder.Supplier.Id,
                            supplierName = driver.purchaseOrder.Supplier.NameAr,
                            purchaseOrderId = driver.PurchaseOrderId,
                            orderDate = driver.OrderDate.Value.Year.ToString() + "-" + driver.OrderDate.Value.Month.ToString() + "-" + driver.OrderDate.Value.Day.ToString(),
                            Address = driver.Address,

                            notes = driver.Notes,
                            userId = driver.UserId

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


            public dynamic PostDriverOrder(PostDriverOrderVM p)
            {
                var driverOrder = db.Drivers_Orders.Add(new Drivers_Orders
                {
                    DriverId = p.driverId,
                    PurchaseOrderId = p.purchaseOrderId,
                    OrderDate = p.orderDate,
                    Address = p.Address,
                    Notes = p.notes,
                    UserId = p.userId
                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    driverOrderId = driverOrder.Id
                };
            }

            public dynamic PutDriverOrder(PostDriverOrderVM p)
            {
                var driverOrder = db.Drivers_Orders.Find(p.driverOrderId);
                driverOrder.DriverId = p.driverId;
                driverOrder.PurchaseOrderId = p.purchaseOrderId;
                driverOrder.OrderDate = p.orderDate;
                driverOrder.Address = p.Address;

                driverOrder.Notes = p.notes;
                driverOrder.UserId = p.userId;
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }

            public dynamic DeleteDriverOrder(int driverOrderId)
            {
                var driverOrder = db.Drivers_Orders.Where(s => s.Id == driverOrderId).FirstOrDefault();
                db.Drivers_Orders.Remove(driverOrder);
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }


        }
    }

