using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.BLL;
namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class StoresController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        public dynamic GetAllStores()
        {
            return StoresManager.Instance.GetAllStores();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetStoreById(int id)
        {
            return StoresManager.Instance.GetStoreById(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="regionId"></param>
        /// <param name="cityId"></param>
        /// <param name="phone"></param>
        /// <param name="storeManagerId"></param>
        /// <returns></returns>

        [HttpPost]
        public dynamic PostStore(StoresVM s)
        {
            return StoresManager.Instance.PostStore(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="address"></param>
        /// <param name="regionId"></param>
        /// <param name="cityId"></param>
        /// <param name="phone"></param>
        /// <param name="storeManagerId"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [HttpPut]
        public dynamic PutStore(StoresVM s)
        {
            return StoresManager.Instance.PutStore(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
        public dynamic DeleteStore(int id)
        {
            return StoresManager.Instance.DeleteStore(id);
        }


    }
}
