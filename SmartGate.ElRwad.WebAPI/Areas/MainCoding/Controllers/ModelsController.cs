using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class ModelsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// Get All Models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllModels()
        {
            var models = db.Models.Select(s => new
            {
                modelId = s.Id,
                modelNameAr = s.NameAr,
                modelNAmeEn = s.NameEn,
                brandId = s.BrandId,
                brandName = s.Brand.NameAr
            }).ToList();
            return models;
        }

        /// <summary>
        /// Get model by id
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetModelById(int modelId)
        {
            try
            {
                var model = db.Models.Where(e => e.Id == modelId).FirstOrDefault();
                if (model != null)
                {
                    return new
                    {
                        modelNameAr = model.NameAr,
                        modelNAmeEn = model.NameEn,
                        brandId = model.BrandId,
                        brandName = model.Brand.NameAr

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
        /// Get all models which related to this brand id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetModelByBrandId(int brandId)
        {
            try
            {
                var model = db.Models.Where(e => e.BrandId == brandId).Select(s => new
                {


                    modelId = s.Id,
                    modelNameAr = s.NameAr,
                    modelNAmeEn = s.NameEn,
                    brandName = s.Brand.NameAr

                }).ToList();
                return model;
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
        /// add new model
        /// </summary>
        /// <param name="modelNameAr"></param>
        /// <param name="modelNAmeEn"></param>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostModel(string modelNameAr, string modelNAmeEn, int brandId)
        {
            var model = db.Models.Add(new Model
            {
                NameAr = modelNameAr,
                NameEn = modelNAmeEn,
                BrandId = brandId,


            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                modelId = model.Id

            };
        }

        /// <summary>
        /// update model data
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="modelNameAr"></param>
        /// <param name="modelNAmeEn"></param>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutModel(int modelId, string modelNameAr, string modelNAmeEn, int brandId)
        {
            var model = db.Models.Find(modelId);

            model.NameAr = modelNameAr;
            model.NameEn = modelNAmeEn;
            model.BrandId = brandId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }



        /// <summary>
        /// delete model
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteModel(int modelId)
        {
            var model = db.Models.Where(s => s.Id == modelId).FirstOrDefault();
            db.Models.Remove(model);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


    }
}
