using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            var category = db.CarsCategories.Select(s => new
            {
                categoryId = s.Id,
                categoryNameAr = s.NameAr,
                categoryNameEn = s.NameEn,
                modelId = s.ModelId,
                categoryModelName = s.Model.NameAr
            }).ToList();
            return category;
        }

        /// <summary>
        /// get category by id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetCategorById(int categoryId)
        {
            try
            {
                var category = db.CarsCategories.Where(e => e.Id == categoryId).FirstOrDefault();
                if (category != null)
                {
                    return new
                    {
                        categoryNameAr = category.NameAr,
                        categoryNameEn = category.NameEn,
                        modelId = category.ModelId,
                        categoryModelName = category.Model.NameAr

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
        /// get all categories related to model
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetCategoryByModelId(int modelId)
        {
            try
            {
                var category = db.CarsCategories.Where(e => e.ModelId == modelId).Select(s => new
                {

                    categoryId = s.Id,
                    categoryNameAr = s.NameAr,
                    categoryNameEn = s.NameEn,
                    categoryModelName = s.Model.NameAr

                }).ToList();
                return category;
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
        /// add new category
        /// </summary>
        /// <param name="categoryNameAr"></param>
        /// <param name="categoryNAmeEn"></param>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostCategory(string categoryNameAr, string categoryNameEn, int modelId)
        {
            db.CarsCategories.Add(new CarsCategory
            {
                NameAr = categoryNameAr,
                NameEn = categoryNameEn,
                ModelId = modelId

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
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
        public dynamic PutModel(int categoryId, string categoryNameAr, string categoryNameEn, int modelId)
        {
            var category = db.CarsCategories.Find(categoryId);

            category.NameAr = categoryNameAr;
            category.NameEn = categoryNameEn;
            category.ModelId = modelId;
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
