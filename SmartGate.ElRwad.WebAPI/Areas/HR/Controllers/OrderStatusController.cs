using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class OrderStatusController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic getAllOrederStatus()
        {
            var orderStatus = db.OrderStatus.Select(s => new
            {
                id = s.Id,
                orderStatusAr = s.StatusAr,
                orderStatusEn = s.StatusEn

            }).ToList();
            return orderStatus;
        }
        [HttpGet]
        public dynamic GetOrederStatusById(int id)
        {
            try
            {
                var orderStatus = db.OrderStatus.Where(e => e.Id == id).FirstOrDefault();
                if (orderStatus != null)
                {
                    return new
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
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }

        [HttpPost]

        public dynamic PostOrderStatus(string orderStatusAr, string orderStatusEn)
        {
            var orderStatus = db.OrderStatus.Add(new OrderStatu
            {
                StatusAr = orderStatusAr,
                StatusEn = orderStatusEn
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                orderStatusId = orderStatus.Id
            };
        }


        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutOrderStatus(int id, string orderStatusAr, string orderStatusEn)
        {
            var orderStatus = db.OrderStatus.Find(id);

            orderStatus.StatusAr = orderStatusAr;
            orderStatus.StatusEn = orderStatusEn;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
