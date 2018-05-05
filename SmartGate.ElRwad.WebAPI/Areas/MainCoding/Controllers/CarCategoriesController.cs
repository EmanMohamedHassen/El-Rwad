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
    public class CarCategoriesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// get all categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllCategories()
        {
            return CarCategoriesManager.Instance.GetAllCategories();
        }

        /// <summary>
        /// get category by id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetCategorById(int categoryId)
        {

            return CarCategoriesManager.Instance.GetCategorById(categoryId);
        }


        /// <summary>
        /// get all categories related to model
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetCategoryByModelId(int modelId)
        {
            return CarCategoriesManager.Instance.GetCategoryByModelId(modelId);
        }
        /// <summary>
        /// add new category
        /// </summary>
        /// <param name="categoryNameAr"></param>
        /// <param name="categoryNAmeEn"></param>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostCategory(CarCategoriesVM C)
        {
            return CarCategoriesManager.Instance.PostCategory(C);
        }
        /// <summary>
        /// update category details
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="categoryNameAr"></param>
        /// <param name="categoryNAmeEn"></param>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutModel(CarCategoriesVM C)
        {
            var category = db.CarsCategories.Find(C.Id);

            category.NameAr = C.NameAr;
            category.NameEn = C.NameEn;
            category.ModelId = C.ModelId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        /// <summary>
        /// delete category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteCategory(int categoryId)
        {
            var category = db.CarsCategories.Where(s => s.Id == categoryId).FirstOrDefault();
            db.CarsCategories.Remove(category);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }




    }
}
