using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.DAL;
namespace SmartGate.ElRwad.BLL.HR
{
   public class OrderStatusManager
    {
        private static OrderStatusManager instance;
        public static OrderStatusManager Instance { get { return instance; } }
        static OrderStatusManager()
        {
            instance = new OrderStatusManager();
        }
            private elRwadEntities db = new elRwadEntities();
            public dynamic getAllOrederStatus()
            {
                List<OrderStatusVM> orderStatus = db.OrderStatus.Select(s => new OrderStatusVM
                {
                    id = s.Id,
                    orderStatusAr = s.StatusAr,
                    orderStatusEn = s.StatusEn

                }).ToList();
                return orderStatus;
            }
            public dynamic GetOrederStatusById(int id)
            {
                try
                {
                    var orderStatus = db.OrderStatus.Where(e => e.Id == id).FirstOrDefault();
                    if (orderStatus != null)
                    {
                        return new OrderStatusPVM
                        {
                            orderStatusAr = orderStatus.StatusAr,
                            orderStatusEn = orderStatus.StatusEn
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

            public dynamic PostOrderStatus(OrderStatusPVM o)
            {
                var orderStatus = db.OrderStatus.Add(new OrderStatu
                {
                    StatusAr = o.orderStatusAr,
                    StatusEn = o.orderStatusEn
                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    orderStatusId = orderStatus.Id
                };
            }
            public dynamic PutOrderStatus(OrderStatusVM o)
            {
                var orderStatus = db.OrderStatus.Find(o.id);

                orderStatus.StatusAr = o.orderStatusAr;
                orderStatus.StatusEn = o.orderStatusEn;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic DeleteOrderStatus(int id)
            {
                var orderStatus = db.OrderStatus.Where(s => s.Id == id).FirstOrDefault();
                db.OrderStatus.Remove(orderStatus);

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }

        }
    }


