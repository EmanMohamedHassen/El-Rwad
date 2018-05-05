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
    public class CityController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetCities()
        {
            return CityManager.Instance.GetCities();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetCityById(int cityId)
        {
            return CityManager.Instance.GetCityById(cityId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityArName"></param>
        /// <param name="cityEnName"></param>
        /// <param name="cityDescription"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostCity(CityVM C)
        {
            return CityManager.Instance.PostCity(C);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <param name="cityArName"></param>
        /// <param name="cityEnName"></param>
        /// <param name="cityDescription"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutCity(CityVM C)
        {
            return CityManager.Instance.PutCity(C);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteCity(int cityId)
        {
            return CityManager.Instance.DeleteCity(cityId);
        }

    }
}
