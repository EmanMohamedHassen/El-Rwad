using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.ViewModel.Purchases;
using SmartGate.ElRwad.BLL.Purchases;

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
            return PurchaseOrderManager.Instance.GetAllPurchaseOrder();
        }



         
        [HttpGet]
        public dynamic GetAllPurchaseOrderByDateNotAccepted(DateTime fromDate, DateTime toDate)
        {
            return PurchaseOrderManager.Instance.GetAllPurchaseOrderByDateNotAccepted(fromDate, toDate);
        }

        [HttpGet]
        public dynamic GetAllPurchaseOrderByDateAccepted(DateTime fromDate, DateTime toDate)
        {
            return PurchaseOrderManager.Instance.GetAllPurchaseOrderByDateAccepted(fromDate, toDate);
        }
        [HttpGet]
        public dynamic GetAllPurchaseOrderByDateNotTakedActions(DateTime fromDate, DateTime toDate)
        {
            return PurchaseOrderManager.Instance.GetAllPurchaseOrderByDateNotTakedActions(fromDate, toDate);
        }

        public dynamic GetAllPurchaseOrderNotTakedActions()
        {
            return PurchaseOrderManager.Instance.GetAllPurchaseOrderNotTakedActions();
        }
        /// <summary>
        /// get purchase order by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetByPurchaseOrederId(int id)
        {
            return PurchaseOrderManager.Instance.GetByPurchaseOrederId(id);
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
        public dynamic PostPurchaseOrder(PurchaseOrderVM p)
        {
           return PurchaseOrderManager.Instance.PostPurchaseOrder(p);
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
        public dynamic PutPurchaseOrder(PutPurchaseOrderVM p)
        {
            return PurchaseOrderManager.Instance.PutPurchaseOrder(p);

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
        public dynamic PutPurchaseOrder(PurchaseVM p)
        {
            return PurchaseOrderManager.Instance.PutPurchaseOrder(p);

        }



        /// <summary>
        /// update total price
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <param name="totalPrice"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrder(PutTotalPriceVM p)
        {
            return PurchaseOrderManager.Instance.PutPurchaseOrder(p);

        }

        /// <summary>
        /// approv by financial managment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isApprovFinancialManag"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrder(PutIsApprovFinancialManagVM p)
        {
            return PurchaseOrderManager.Instance.PutPurchaseOrder(p);
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
