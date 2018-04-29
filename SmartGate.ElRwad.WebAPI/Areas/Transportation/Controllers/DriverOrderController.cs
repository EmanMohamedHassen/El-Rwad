using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.Transportation.Controllers
{
    public class DriverOrderController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// get all drivers orders
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllDriversOrder(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var driverOrder = db.Drivers_Orders.Where(e => e.OrderDate >= fromDate.Date && e.OrderDate <= toDate.Date).Select(s => new
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



        /// <summary>
        /// get driver Order by id
        /// </summary>
        /// <param name="driverOrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDriverOrderById(int driverOrderId)
        {

            var driverOrder = db.Drivers_Orders.Where(e => e.Id == driverOrderId).Select(s => new
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

        /// <summary>
        /// get driver order by purchase order id
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetByPurchaseOrderId(int purchaseOrderId)
        {
            try
            {
                var driverOrder = db.Drivers_Orders.Where(e => e.PurchaseOrderId == purchaseOrderId).FirstOrDefault();
                if (driverOrder != null)
                {
                    return new
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
        /// add new driver order
        /// </summary>
        /// <param name="driverId"></param>
        /// <param name="purchaseOrderId"></param>
        /// <param name="orderDate"></param>
        /// <param name="notes"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostDriverOrder(int driverId, int purchaseOrderId, DateTime orderDate, string address, string notes, int userId)
        {
            var driverOrder = db.Drivers_Orders.Add(new Drivers_Orders
            {
                DriverId = driverId,
                PurchaseOrderId = purchaseOrderId,
                OrderDate = orderDate,
                Address = address,
                Notes = notes,
                UserId = userId
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                driverOrderId = driverOrder.Id
            };
        }

        /// <summary>
        /// update driver order
        /// </summary>
        /// <param name="driverOrderId"></param>
        /// <param name="driverId"></param>
        /// <param name="purchaseOrderId"></param>
        /// <param name="orderDate"></param>
        /// <param name="notes"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDriverOrder(int driverOrderId, int driverId, int purchaseOrderId, string address, DateTime orderDate, string notes, int userId)
        {
            var driverOrder = db.Drivers_Orders.Find(driverOrderId);
            driverOrder.DriverId = driverId;
            driverOrder.PurchaseOrderId = purchaseOrderId;
            driverOrder.OrderDate = orderDate;
            driverOrder.Address = address;

            driverOrder.Notes = notes;
            driverOrder.UserId = userId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        /// <summary>
        /// delete driver order
        /// </summary>
        /// <param name="driverOrderId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
