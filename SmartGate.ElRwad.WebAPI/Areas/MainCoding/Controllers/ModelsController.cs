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
    public class ModelsController : ApiController
    {

        /// <summary>
        /// Get All Models
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllModels()
        {
            return ModelManager.Instance.GetAllModels();
        }

        /// <summary>
        /// Get model by id
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetModelById(int modelId)
        {
            return ModelManager.Instance.GetModelById(modelId);
        }


        /// <summary>
        /// Get all models which related to this brand id
        /// </summary>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetModelByBrandId(int brandId)
        {
            return ModelManager.Instance.GetModelByBrandId(brandId);
        }

        /// <summary>
        /// add new model
        /// </summary>
        /// <param name="modelNameAr"></param>
        /// <param name="modelNAmeEn"></param>
        /// <param name="brandId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostModel(ModelVM m)
        {
            return ModelManager.Instance.PostModel(m);
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
        public dynamic PutModel(ModelVM m)
        {
            return ModelManager.Instance.PutModel(m);
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
            return ModelManager.Instance.DeleteModel(modelId);
        }


    }
}
