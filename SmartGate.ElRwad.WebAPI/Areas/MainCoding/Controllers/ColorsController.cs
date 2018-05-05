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
    public class ColorsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// get all colors
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetColors()
        {
            return ColorManger.Instance.GetAllColors();
                
        }

        /// <summary>
        /// get color by id
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetColorById(int colorId)
        {
            return ColorManger.Instance.GetColorById(colorId);
        }

        /// <summary>
        /// add new color
        /// </summary>
        /// <param name="colorNameAr"></param>
        /// <param name="colorNAmeEn"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostColor(string colorNameAr, string colorNAmeEn)
        {
            return ColorManger.Instance.PostColor( colorNameAr,  colorNAmeEn);
        }

        /// <summary>
        /// update color data
        /// </summary>
        /// <param name="colorId"></param>
        /// <param name="colorNameAr"></param>
        /// <param name="colorNAmeEn"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutColor(int colorId, string colorNameAr, string colorNAmeEn)
        {
            return ColorManger.Instance.PutColor(colorId, colorNameAr, colorNAmeEn);
        }

        /// <summary>
        /// delete color
        /// </summary>
        /// <param name="colorId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteColor(int colorId)
        {
            return ColorManger.Instance.DeleteColor(colorId);
        }


    }
}
