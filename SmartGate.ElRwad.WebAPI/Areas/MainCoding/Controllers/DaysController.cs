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
    public class DaysController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllDays()
        {
            return DaysManager.Instance.GetAllDays();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDayById(int id)
        {
            return DaysManager.Instance.GetDayById(id);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameAr"></param>
        /// <param name="nameEn"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostDay(DaysVM d)
        {
            return DaysManager.Instance.PostDay(d);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nameAr"></param>
        /// <param name="nameEn"></param>
        /// <returns></returns>
        [HttpPut]
        //[AcceptVerbs("GET", "POST")]
        public dynamic PutDay(DaysVM d)
        {
            return DaysManager.Instance.PostDay(d);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        //[AcceptVerbs("GET", "POST")]
        public dynamic DeleteDay(int id)
        {
            return DaysManager.Instance.DeleteDay(id);

        }


    }
}
