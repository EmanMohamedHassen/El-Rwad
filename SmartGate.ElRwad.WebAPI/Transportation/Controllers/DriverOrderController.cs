using SmartGate.ElRwad.BLL;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Transportation;
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
            return DriverOrderManager.Instance.GetAllDriversOrder(fromDate, toDate);
        }



        /// <summary>
        /// get driver Order by id
        /// </summary>
        /// <param name="driverOrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDriverOrderById(int driverOrderId)
        {

            return DriverOrderManager.Instance.GetDriverOrderById(driverOrderId);
        }

        /// <summary>
        /// get driver order by purchase order id
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetByPurchaseOrderId(int purchaseOrderId)
        {
            return DriverOrderManager.Instance.GetByPurchaseOrderId(purchaseOrderId);
        }
        [HttpGet]
        public dynamic GetByDriverId(int driverId)
        {
            return DriverOrderManager.Instance.GetByDriverId(driverId);
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
        public dynamic PostDriverOrder(PostDriverOrderVM d)
        {
            return DriverOrderManager.Instance.PostDriverOrder(d);
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
        public dynamic PutDriverOrder(PostDriverOrderVM d)
        {
            return DriverOrderManager.Instance.PutDriverOrder(d);
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
            return DriverOrderManager.Instance.DeleteDriverOrder(driverOrderId);
        }


    }
}
