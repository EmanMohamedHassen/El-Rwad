using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class BrandsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllBrands()
        {
            var brands = db.Brands.Select(s => new
            {
                brandId = s.Id,
                brandNameAr = s.NameAr,
                brandNameEn = s.NameEn,
                userId = s.UserId,
                lastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()
            }).ToList();
            return brands;
        }

        /// <summary>
        /// Get brand By Id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetBarndById(int brandId)
        {
            try
            {
                var s = db.Brands.Where(e => e.Id == brandId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        brandNameAr = s.NameAr,
                        brandNAmeEn = s.NameEn,
                        userId = s.UserId,
                        lastUpdate = s.LastUpdate.Value.ToString("yyyy-MM-dd")
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

        /// <summary>
        /// add new brand
        /// </summary>
        /// <param name="brandNameAr"></param>
        /// <param name="brandNAmeEn"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostBrand(string brandNameAr, string brandNAmeEn, int userId)
        {
            db.Brands.Add(new Brand
            {
                NameAr = brandNameAr,
                NameEn = brandNAmeEn,
                UserId = userId,
                LastUpdate = DateTime.Now

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        /// <summary>
        /// update brand details
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="brandNameAr"></param>
        /// <param name="brandNAmeEn"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutBrand(int brandId, string brandNameAr, string brandNAmeEn, int userId)
        {
            var brand = db.Brands.Find(brandId);

            brand.NameAr = brandNameAr;
            brand.NameEn = brandNAmeEn;
            brand.UserId = userId;
            brand.LastUpdate = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        /// <summary>
        /// delete brand
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteBrand(int brandId)
        {
            var brand = db.Brands.Where(s => s.Id == brandId).FirstOrDefault();
            db.Brands.Remove(brand);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


    }
}
