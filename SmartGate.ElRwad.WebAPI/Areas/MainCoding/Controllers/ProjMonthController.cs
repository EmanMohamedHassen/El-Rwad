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
    public class ProjMonthController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetMonth()
        {
            return MonthManager.Instance.GetMonth();
        }

        [HttpGet]
        public dynamic GetMonthById(int monthId)
        {
            return MonthManager.Instance.GetMonthById(monthId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthId"></param>
        /// <param name="monthName"></param>
        /// <param name="monthNameEn"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostMonth(MonthVM m)
        {
            return MonthManager.Instance.PostMonth(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthId"></param>
        /// <param name="monthName"></param>
        /// <param name="monthNameEn"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutMonth(MonthVM m)
        {
            return MonthManager.Instance.PutMonth(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteMonth(byte monthId)
        {
            return MonthManager.Instance.DeleteMonth(monthId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic monthExists(byte monthId)
        {
            return MonthManager.Instance.monthExists(monthId);
        }


    }
}
