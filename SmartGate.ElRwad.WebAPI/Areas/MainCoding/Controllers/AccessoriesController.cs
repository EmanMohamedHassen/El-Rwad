using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.BLL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class AccessoriesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllAccessories()
        {
            return AccessoriesManager.Instance.GetAllAccessories();
        }


        [HttpGet]
        public dynamic GetAccessoryById(int accessoryId)
        {
           return AccessoriesManager.Instance.GetAccessoryById(accessoryId);
        }
        public dynamic GetAccessoriesByPurchaseOrderId(int purchaseOrderId)
        {

            return AccessoriesManager.Instance.GetAccessoriesByPurchaseOrderId(purchaseOrderId);

        }

        public dynamic PostAccessory(AccessoriesVM A)
        {/*
            AccessoriesVM A = new AccessoriesVM();
            A.NameA = accessoryNameA;
            A.NameE = accessoryNameE;
            A.Price = price;*/
            return AccessoriesManager.Instance.PostAccessory(A);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutAccessory(int accessoryId, string accessoryNameA, string accessoryNameE, float price)
        {
            AccessoriesVM A = new AccessoriesVM();
            A.Id = accessoryId;
            A.NameA = accessoryNameA;
            A.NameE = accessoryNameE;
            A.Price = price;
            return AccessoriesManager.Instance.PutAccessory(accessoryId, accessoryNameA, accessoryNameE, price);
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteAccessory(int accessoryId)
        {
            return AccessoriesManager.Instance.DeleteAccessory(accessoryId);
        }



        ///////////// post&put purchaseorderaccesssories
        public dynamic PostPurchaseOrderAccesssories(int purchaseOrderId, [FromBody] List<int> accessoriesIDs)
        {
            return AccessoriesManager.Instance.PostPurchaseOrderAccesssories(purchaseOrderId, accessoriesIDs);

        }


    }
}
