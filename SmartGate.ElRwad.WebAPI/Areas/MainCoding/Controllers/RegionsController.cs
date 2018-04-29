using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            var region = db.Regions.Select(s => new
            {
                regionId = s.Id,
                regionArName = s.NameAr,
                regionEnName = s.NameEn,
                regionCityId = s.CityId,
                regionCityName = s.City.Name_A


            }).ToList();
            return region;
        }
        /// <summary>
        /// get  region by id
        /// </summary>
        /// <param name=" regionId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetRegionById(int regionId)
        {
            try
            {
                var s = db.Regions.Where(e => e.Id == regionId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {

                        regionArName = s.NameAr,
                        regionEnName = s.NameEn,
                        regionCityId = s.CityId,
                        regionCityName = s.City.Name_A

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
        //get all regions by city id
        [HttpGet]
        public dynamic GetRegionsByCityId(int cityId)
        {
            try
            {
                var region = db.Regions.Where(e => e.CityId == cityId).Select(s => new
                {


                    regionId = s.Id,
                    regionArName = s.NameAr,
                    regionEnName = s.NameEn,
                    regionCityId = s.CityId,
                    regionCityName = s.City.Name_A

                }).ToList();
                return region;
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

        /// <summary>
        /// add new region
        /// </summary>
        /// <param name="regionArName"></param>
        /// <param name="regionEnName"></param>
        /// <param name="regionCityId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostRegion(string regionArName, string regionEnName, int regionCityId)
        {
            var region = db.Regions.Add(new Region
            {
                NameAr = regionArName,
                NameEn = regionEnName,
                CityId = regionCityId
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                regionId = region.Id
            };
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
        public dynamic PutRegion(int regionId, string regionArName, string regionEnName, int regionCityId)
        {
            var region = db.Regions.Find(regionId);
            region.NameAr = regionArName;
            region.NameEn = regionEnName;
            region.CityId = regionCityId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
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
            var region = db.Regions.Where(s => s.Id == regionId).FirstOrDefault();
            db.Regions.Remove(region);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

    }
}
