using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class SuppliersRepresentativeController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// get all suppliers Representatives
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllSuppliersRepresentative()
        {
            var suppliersRepresentative = db.SuppliersRepresentatives.Select(s => new
            {
                supplierRepresentativeId = s.Id,
                supplierId = s.SupplierId,
                supplierName = s.Supplier.NameAr,
                supplierRepresentativeNameEn = s.NameEn,
                supplierRepresentativeNameAr = s.NameAr,
                mobile = s.Mobile,
                email = s.Email,
                job = s.Job,
                userId = s.UserId,
                lastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()
            }).ToList();
            return suppliersRepresentative;
        }

        /// <summary>
        /// get supplier Representative by id
        /// </summary>
        /// <param name="supplierRepresentativeId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetSupplierRepresentativeById(int supplierRepresentativeId)
        {
            try
            {
                var supplierRepresentative = db.SuppliersRepresentatives.Where(e => e.Id == supplierRepresentativeId).FirstOrDefault();
                if (supplierRepresentative != null)
                {
                    return new
                    {
                        supplierRepresentativeId = supplierRepresentative.Id,
                        supplierId = supplierRepresentative.SupplierId,
                        supplierName = supplierRepresentative.Supplier.NameAr,
                        supplierRepresentativeNameEn = supplierRepresentative.NameEn,
                        supplierRepresentativeNameAr = supplierRepresentative.NameAr,
                        mobile = supplierRepresentative.Mobile,
                        email = supplierRepresentative.Email,
                        job = supplierRepresentative.Job,
                        userId = supplierRepresentative.UserId,
                        lastUpdate = supplierRepresentative.LastUpdate.Value.ToString("yyyy-MM-dd")
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
        /// get all representative for this supplier
        /// </summary>
        /// <param name="supplierId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetSupplierRepresentativeBySupplierId(int supplierId)
        {
            try
            {
                var supplierRepresentative = db.SuppliersRepresentatives.Where(e => e.SupplierId == supplierId).Select(s => new
                {
                    supplierRepresentativeId = s.Id,
                    supplierId = s.SupplierId,
                    supplierName = s.Supplier.NameAr,
                    supplierRepresentativeNameEn = s.NameEn,
                    supplierRepresentativeNameAr = s.NameAr,
                    mobile = s.Mobile,
                    email = s.Email,
                    job = s.Job,
                    userId = s.UserId,
                    lastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()
                }).ToList();
                return supplierRepresentative;
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
        /// update supplier representative
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="supplierRepresentativeName"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostSupplierRepresentative(int supplierId, string supplierRepresentativeNameAr, string supplierRepresentativeNameEn,
            string mobile, string email, string job, int userId)
        {
            var supplierRepresentative = db.SuppliersRepresentatives.Add(new SuppliersRepresentative
            {
                SupplierId = supplierId,
                NameAr = supplierRepresentativeNameAr,
                NameEn = supplierRepresentativeNameEn,
                Mobile = mobile,
                Email = email,
                Job = job,
                LastUpdate = DateTime.Now

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                supplierRepresentativeId = supplierRepresentative.Id
            };
        }

        /// <summary>
        /// update supplierRepresentative data
        /// </summary>
        /// <param name="supplierRepresentativeId"></param>
        /// <param name="supplierId"></param>
        /// <param name="supplierRepresentativeName"></param>
        /// <param name="mobile"></param>
        /// <param name="email"></param>
        /// <param name="job"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSupplierRepresentative(int supplierRepresentativeId, int supplierId, string supplierRepresentativeNameAr,
            string supplierRepresentativeNameEn, string mobile, string email, string job, int userId)
        {
            var supplierRepresentative = db.SuppliersRepresentatives.Find(supplierRepresentativeId);

            supplierRepresentative.SupplierId = supplierId;
            supplierRepresentative.NameAr = supplierRepresentativeNameAr;
            supplierRepresentative.NameEn = supplierRepresentativeNameEn;
            supplierRepresentative.Mobile = mobile;
            supplierRepresentative.Email = email;
            supplierRepresentative.Job = job;
            supplierRepresentative.LastUpdate = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        /// <summary>
        /// delete SupplierRepresentative
        /// </summary>
        /// <param name="supplierRepresentativeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteSupplierRepresentative(int supplierRepresentativeId)
        {
            var supplierRepresentative = db.SuppliersRepresentatives.Where(s => s.Id == supplierRepresentativeId).FirstOrDefault();
            db.SuppliersRepresentatives.Remove(supplierRepresentative);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


    }
}
