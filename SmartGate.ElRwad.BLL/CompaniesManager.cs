using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.BLL
{
   public class CompaniesManager
    {
        private static CompaniesManager instance;
        public static CompaniesManager Instance { get { return instance; } }
        static CompaniesManager()
        {
            instance = new CompaniesManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllCompanies()
        {
           List<CompaniesVM> companies = db.Companies.Select(s => new CompaniesVM
            {
                Id= s.Company_ID,
                NameA= s.Company_A_Name,
                NameE= s.Company_E_Name,
                //smallImage = s.Small_Image,
                //backImage = s.Back_Image,
                Notes= s.Company_Notes,
                ManagerId= s.Manager_ID,
                FullName= s.Employee.FullName,
                UserId = s.User_ID,
                LastUpdate= s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return companies;
        }

        public dynamic GetCompanyId(int companyId)
        {
            try
            {
                var company = db.Companies.Where(e => e.Company_ID == companyId).FirstOrDefault();
                if (company != null)
                {
                    return new CompaniesVM
                    {
                        NameA = company.Company_A_Name,
                        NameE= company.Company_E_Name,
                        //smallImage = company.Small_Image,
                        //backImage = company.Back_Image,
                        Notes= company.Company_Notes,
                        ManagerId= company.Manager_ID,
                        FullName = company.Employee.FullName,

                        UserId= company.User_ID,
                        LastUpdate = company.Last_Update.Value.ToString("yyyy-MM-dd")
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
                    Message = ex.Message
                };
            }
        }


        public dynamic PostCompany(CompaniesVM co)
        {
            db.Companies.Add(new Company
            {
                Company_A_Name = co.NameA,
                Company_E_Name = co.NameE,
                //Small_Image = smallImage,
                //Back_Image = backImage,
                Company_Notes = co.Notes,
                Manager_ID = co.ManagerId,
                User_ID = co.UserId,
                Last_Update = DateTime.Now,

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic PutCompany(CompaniesVM co)
        {
            var company = db.Companies.Find(co.Id);
            company.Company_A_Name = co.NameA;
            company.Company_E_Name = co.NameE;
            company.Company_Notes = co.Notes;
            company.Manager_ID = co.ManagerId;
            company.User_ID = co.UserId;
            company.Last_Update = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
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
