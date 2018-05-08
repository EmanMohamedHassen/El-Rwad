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
    public class SuppliersController : ApiController
    {
        /// <summary>
        /// get all suppliers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllSuppliers()
        {
            return SupplierManager.Instance.GetAllSuppliers();

        }

        /// <summary>
        /// get supplier by id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetSupplierById(int supplierId)
        {
            return SupplierManager.Instance.GetSupplierById(supplierId);
        }

        /// <summary>
        /// add new supplier
        /// </summary>
        /// <param name="supplierNameAr"></param>
        /// <param name="supplierNAmeEn"></param>
        /// <param name="phone"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="cityId"></param>
        /// <param name="regionId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostSupplier(SuppliersVM s)
        {
            return SupplierManager.Instance.PostSupplier(s);
        }

        /// <summary>
        /// update supplier data
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="supplierNameAr"></param>
        /// <param name="supplierNAmeEn"></param>
        /// <param name="phone"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="cityId"></param>
        /// <param name="regionId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSupplier(SuppliersVM s)
        {
            return SupplierManager.Instance.PutSupplier(s);
        }

        /// <summary>
        /// delete supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteSupplier(int supplierId)
        {
            return SupplierManager.Instance.DeleteSupplier(supplierId);
        }


    }
}
