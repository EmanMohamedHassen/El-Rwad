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
    public class RegionsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// get all regions
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic Getregions()
        {
            return RegionManager.Instance.Getregions();
        }
        /// <summary>
        /// get  region by id
        /// </summary>
        /// <param name=" regionId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetRegionById(int regionId)
        {
            return RegionManager.Instance.GetRegionById(regionId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        //get all regions by city id
        [HttpGet]
        public dynamic GetRegionsByCityId(int cityId)
        {
            return RegionManager.Instance.GetRegionById(cityId);
        }

        /// <summary>
        /// add new region
        /// </summary>
        /// <param name="regionArName"></param>
        /// <param name="regionEnName"></param>
        /// <param name="regionCityId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostRegion(RegionVM r)
        {
            return RegionManager.Instance.PostRegion(r);
        }
        /// <summary>
        /// update region details
        /// </summary>
        /// <param name="regionId"></param>
        /// <param name="regionArName"></param>
        /// <param name="regionEnName"></param>
        /// <param name="regionCityId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutRegion(RegionVM r)
        {
            return RegionManager.Instance.PutRegion(r);
        }

        /// <summary>
        /// delete region
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteRegion(int regionId)
        {
            return RegionManager.Instance.DeleteRegion(regionId);
        }

    }
}
