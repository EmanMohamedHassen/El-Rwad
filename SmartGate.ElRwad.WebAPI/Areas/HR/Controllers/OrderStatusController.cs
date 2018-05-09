using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.BLL.HR;
using SmartGate.ElRwad.ViewModel.HR;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class OrderStatusController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public dynamic getAllOrederStatus()
        {
            return OrderStatusManager.Instance.getAllOrederStatus();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetOrederStatusById(int id)
        {
            return OrderStatusManager.Instance.GetOrederStatusById(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [HttpPost]

        public dynamic PostOrderStatus(OrderStatusPVM o)
        {
            return OrderStatusManager.Instance.PostOrderStatus(o);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutOrderStatus(OrderStatusVM o)
        {
            return OrderStatusManager.Instance.PutOrderStatus(o);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteOrderStatus(int id)
        {
            return OrderStatusManager.Instance.DeleteOrderStatus(id);
        }

    }
}
