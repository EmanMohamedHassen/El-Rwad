using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class CompaniesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetAllCompanies()
        {
            var companies = db.Companies.Select(s => new
            {
                companyId = s.Company_ID,
                companyNameAr = s.Company_A_Name,
                companyNameEn = s.Company_E_Name,
                //smallImage = s.Small_Image,
                //backImage = s.Back_Image,
                companyNotes = s.Company_Notes,
                managerId = s.Manager_ID,
                managerName = s.Employee.FullName,
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return companies;
        }

        [HttpGet]
        public dynamic GetCompanyId(int companyId)
        {
            try
            {
                var company = db.Companies.Where(e => e.Company_ID == companyId).FirstOrDefault();
                if (company != null)
                {
                    return new
                    {
                        companyNameAr = company.Company_A_Name,
                        companyNameEn = company.Company_E_Name,
                        //smallImage = company.Small_Image,
                        //backImage = company.Back_Image,
                        companyNotes = company.Company_Notes,
                        managerId = company.Manager_ID,
                        managerName = company.Employee.FullName,

                        userId = company.User_ID,
                        lastUpdate = company.Last_Update.Value.ToString("yyyy-MM-dd")
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



        [HttpPost]
        public dynamic PostCompany(string companyNameAr, string companyNameEn, string companyNotes, int managerId, int userId)
        {
            db.Companies.Add(new Company
            {
                Company_A_Name = companyNameAr,
                Company_E_Name = companyNameEn,
                //Small_Image = smallImage,
                //Back_Image = backImage,
                Company_Notes = companyNotes,
                Manager_ID = managerId,
                User_ID = userId,
                Last_Update = DateTime.Now,

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPut]
        public dynamic PutCompany(int companyId, string companyNameAr, string companyNameEn, string companyNotes, int managerId, int userId)
        {
            var company = db.Companies.Find(companyId);
            company.Company_A_Name = companyNameAr;
            company.Company_E_Name = companyNameEn;
            company.Company_Notes = companyNotes;
            company.Manager_ID = managerId;
            company.User_ID = userId;
            company.Last_Update = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
        public dynamic DeleteCompany(int companyId)
        {
            var company = db.Companies.Where(s => s.Company_ID == companyId).FirstOrDefault();
            db.Companies.Remove(company);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


    }
}
