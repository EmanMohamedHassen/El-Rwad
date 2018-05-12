using SmartGate.ElRwad.BLL.Sales;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.Sales.Controllers
{
    public class SalesPurchaseOrderController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        

        [HttpGet]
        public dynamic GetAllSalesPurchaseOrders()
        {
            return SalesPurchaseOrderManager.Instance.GetAllSalesPurchaseOrders();
        }

        [HttpGet]
        public dynamic GetSalesPurchaseOrderById(int purchaseorderId)
        {
            return SalesPurchaseOrderManager.Instance.GetSalesPurchaseOrderById(purchaseorderId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="date"></param>
        /// <param name="buyerName"></param>
        /// <param name="adress"></param>
        /// <param name="cityId"></param>
        /// <param name="regionId"></param>
        /// <param name="mobNumber"></param>
        /// <param name="ssn"></param>
        /// <param name="brandId"></param>
        /// <param name="modelId"></param>
        /// <param name="categoryId"></param>
        /// <param name="colorId"></param>
        /// <param name="internalcolor"></param>
        /// <param name="carStatues"></param>
        /// <param name="price"></param>
        /// <param name="haveInsurance"></param>
        /// <param name="insurcompanyId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostSalesPurchaseOrder(PostSalesPurchaseOrderVM p)
        {
            return SalesPurchaseOrderManager.Instance.PostSalesPurchaseOrder(p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <param name="userid"></param>
        /// <param name="date"></param>
        /// <param name="buyerName"></param>
        /// <param name="adress"></param>
        /// <param name="cityId"></param>
        /// <param name="regionId"></param>
        /// <param name="mobNumber"></param>
        /// <param name="ssn"></param>
        /// <param name="paymentMethod"></param>
        /// <param name="bankId"></param>
        /// <returns></returns>
        [HttpPut]
        //[AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrder(post_SalesPurchaseOrderVM p)
        {
            return SalesPurchaseOrderManager.Instance.PutSalesPurchaseOrder(p);
        }


        [HttpDelete]
        //[AcceptVerbs("GET", "POST")]
        public dynamic DeleteSalesPurchaseOrder(int purchaseOrderId)
        {
            return SalesPurchaseOrderManager.Instance.DeleteSalesPurchaseOrder(purchaseOrderId);
        }

        [HttpGet]
        //special Gets and puts
        public dynamic GetSalesPurchaseOrdersByDate(DateTime fromDate, DateTime toDate)
        {
            return SalesPurchaseOrderManager.Instance.GetSalesPurchaseOrdersByDate(fromDate, toDate);
        }
        [HttpGet]
        public dynamic GetSalesPurchaseOrdersByDateTakedAction(DateTime fromDate, DateTime toDate)
        {
            return SalesPurchaseOrderManager.Instance.GetSalesPurchaseOrdersByDateTakedAction(fromDate, toDate);
        }
        [HttpGet]
        public dynamic GetSalesPurchaseOrdersBySalesEmployeeAndDateTakedAction(DateTime fromDate, DateTime toDate, int empId)
        {
            return SalesPurchaseOrderManager.Instance.GetSalesPurchaseOrdersBySalesEmployeeAndDateTakedAction(fromDate, toDate, empId);
        }
        [HttpGet]
        public dynamic GetSalesPurchaseOrdersAcceptedByDate(DateTime fromDate, DateTime toDate)
        {
            return SalesPurchaseOrderManager.Instance.GetSalesPurchaseOrdersAcceptedByDate(fromDate, toDate);
        }
        [HttpGet]
        public dynamic GetSalesPurchaseOrdersRefusedByDate(DateTime fromDate, DateTime toDate)
        {
            return SalesPurchaseOrderManager.Instance.GetSalesPurchaseOrdersRefusedByDate(fromDate, toDate);
        }
        [HttpGet]
        public dynamic GetSalesPurchaseOrdersNotTakedActionsdByDate(DateTime fromDate, DateTime toDate)
        {
            return SalesPurchaseOrderManager.Instance.GetSalesPurchaseOrdersNotTakedActionsdByDate(fromDate, toDate);
        }

        [HttpPut]
        //[AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrderPaymentMethod(PutSalesPurchaseOrderVM p)
        {
            return SalesPurchaseOrderManager.Instance.PutSalesPurchaseOrderPaymentMethod(p);
        }
        [HttpPut]
        //[AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrderToAccepted(int purchaseorderId)
        {
            return SalesPurchaseOrderManager.Instance.PutSalesPurchaseOrderToAccepted(purchaseorderId);
         }

        [HttpPut]
        //[AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrderToRefused(int purchaseorderId, string refusalReasons)
        {
            return SalesPurchaseOrderManager.Instance.PutSalesPurchaseOrderToRefused(purchaseorderId, refusalReasons);
        }

    }
}
