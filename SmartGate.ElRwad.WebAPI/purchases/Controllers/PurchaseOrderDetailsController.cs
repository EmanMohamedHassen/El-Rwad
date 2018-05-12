using SmartGate.ElRwad.BLL.Purchases;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.purchases.Controllers
{
    public class PurchaseOrderDetailsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();



        [HttpGet]
        public dynamic GetAllDetailsPurchaseOrder()
        {
            return PurchaseOrderDetailsManager.Instance.GetAllDetailsPurchaseOrder();
        }


        /// <summary>
        /// get all details related to purchase order
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllDetailsPurchaseOrderByPurchaseOrderId(int purchaseOrderId)
        {
            return PurchaseOrderDetailsManager.Instance.GetAllDetailsPurchaseOrderByPurchaseOrderId(purchaseOrderId);
        }

        /// <summary>
        /// get Purchase Order by id
        /// </summary>
        /// <param name="PurchaseOrderDetailId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPurchaseOrderDetailById(int id)
        {
            return PurchaseOrderDetailsManager.Instance.GetPurchaseOrderDetailById(id);
        }


        /// <summary>
        /// add new detail for purchase order
        /// </summary>
        /// <param name="purchaseOrderId"></param>
        /// <param name="brandId"></param>
        /// <param name="modelId"></param>
        /// <param name="manufacturingYearId"></param>
        /// <param name="categoryId"></param>
        /// <param name="colorId"></param>
        /// <param name="isNew"></param>
        /// <param name="isBuying"></param>
        /// <param name="count"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostPurchaseOrderDetails(PostPurchaseOrderDetailsVM p)
        {
            return PurchaseOrderDetailsManager.Instance.PostPurchaseOrderDetails(p);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPurchaseOrderDetails(PostPurchaseOrderDetailsVM p)
        {
            return PurchaseOrderDetailsManager.Instance.PostPurchaseOrderDetails(p);
        }

        //[HttpPut]
        //[AcceptVerbs("GET", "POST")]
        //public dynamic PutIsReceived(int id, bool isReceived)
        //{
        //    var purchaseOrderDetails = db.PurchaseOrderDetails.Find(id);
        //   // purchaseOrderDetails.IsReceived = isReceived;
        //    var result = db.SaveChanges() > 0 ? true : false;
        //    return new
        //    {
        //        reslt = result
        //    };
        //}


        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
        public dynamic DeletePurchaseOrderDetails(int id)
        {
            return PurchaseOrderDetailsManager.Instance.DeletePurchaseOrderDetails(id);
        }

    }
}
