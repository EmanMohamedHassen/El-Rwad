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
            return BrandsManager.Instance.GetAllBrands();
        }

        /// <summary>
        /// Get brand By Id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetBarndById(int brandId)
        {
            return BrandsManager.Instance.GetBarndById(brandId);
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
            BrandVM B = new BrandVM();
            B.NameAr = brandNameAr;
            B.NameEn = brandNAmeEn;
            B.UserId = userId;
            return BrandsManager.Instance.PostBrand(B);
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
            BrandVM B = new BrandVM();
            B.Id = brandId;
            B.NameAr = brandNameAr;
            B.NameEn = brandNAmeEn;
            B.UserId = userId;
            return BrandsManager.Instance.PutBrand(B);
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
