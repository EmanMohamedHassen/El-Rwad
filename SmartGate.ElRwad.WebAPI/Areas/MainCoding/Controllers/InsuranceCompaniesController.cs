using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class InsuranceCompaniesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllinsurComponies()
        {
            var insurcompines = db.InsuranceCompanies.Select(s => new
            {
                insurcomId = s.Id,
                insurcomNameA = s.NameA,
                insurcomNameE = s.NameE

            }).ToList();
            return insurcompines;
        }

        public dynamic GetInsurCompanyById(int InsurcompanyId)
        {
            try
            {
                var insurcompany = db.InsuranceCompanies.Where(e => e.Id == InsurcompanyId).FirstOrDefault();
                if (insurcompany != null)
                {
                    return new
                    {
                        companyId = insurcompany.Id,
                        companyNameA = insurcompany.NameA,
                        companyNameE = insurcompany.NameE
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

        public dynamic PostInsurCompany(string companyNameA, string companyNameE)
        {
            db.InsuranceCompanies.Add(new InsuranceCompany
            {
                NameA = companyNameA,
                NameE = companyNameE

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]

        public dynamic PutInsurCompany(int InsurcompanyId, string companyNameA, string companyNameE)
        {
            var insurcompany = db.InsuranceCompanies.Find(InsurcompanyId);

            insurcompany.NameA = companyNameA;
            insurcompany.NameE = companyNameE;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteInsurCompany(int InsurcompanyId)
        {
            var insurcompany = db.InsuranceCompanies.Where(s => s.Id == InsurcompanyId).FirstOrDefault();
            db.InsuranceCompanies.Remove(insurcompany);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }



    }
}
