using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class SuppliersController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        /// <summary>
        /// get all suppliers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllSuppliers()
        {
            var suppliers = db.Suppliers.Select(s => new
            {
                supplierId = s.Id,
                supplierNameAr = s.NameAr,
                supplierNameEn = s.NameEn,
                phone = s.Phone,
                mobile = s.Mobile,
                email = s.Email,
                address = s.Address,
                cityId = s.CityId,
                cityName = s.City.Name_A,
                regionId = s.RegionId,
                regionName = s.Region.NameAr
            }).ToList();
            return suppliers;
        }

        /// <summary>
        /// get supplier by id
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetSupplierById(int supplierId)
        {
            try
            {
                var supplier = db.Suppliers.Where(e => e.Id == supplierId).FirstOrDefault();
                if (supplier != null)
                {
                    return new
                    {
                        supplierNameAr = supplier.NameAr,
                        supplierNameEn = supplier.NameEn,
                        phone = supplier.Phone,
                        mobile = supplier.Mobile,
                        email = supplier.Email,
                        address = supplier.Address,
                        cityId = supplier.CityId,
                        cityName = supplier.City.Name_A,
                        regionId = supplier.RegionId,
                        regionName = supplier.Region.NameAr
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
        public dynamic PostSupplier(string supplierNameAr, string supplierNameEn, string phone, string mobile, string email, string address, int cityId, int regionId)
        {
            db.Suppliers.Add(new Supplier
            {
                NameAr = supplierNameAr,
                NameEn = supplierNameEn,
                Phone = phone,
                Mobile = mobile,
                Email = email,
                Address = address,
                CityId = cityId,
                RegionId = regionId

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
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
        public dynamic PutSupplier(int supplierId, string supplierNameAr, string supplierNAmeEn, string phone, string mobile, string email, string address, int cityId, int regionId)
        {
            var supplier = db.Suppliers.Find(supplierId);

            supplier.NameAr = supplierNameAr;
            supplier.NameEn = supplierNAmeEn;
            supplier.Phone = phone;
            supplier.Mobile = mobile;
            supplier.Email = email;
            supplier.Address = address;
            supplier.CityId = cityId;
            supplier.RegionId = regionId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
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
            var supplier = db.Suppliers.Where(s => s.Id == supplierId).FirstOrDefault();
            db.Suppliers.Remove(supplier);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


    }
}
