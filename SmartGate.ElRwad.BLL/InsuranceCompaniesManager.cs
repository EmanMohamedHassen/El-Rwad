using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL
{
  public  class InsuranceCompaniesManager
    {
        private static InsuranceCompaniesManager instance;
        public static InsuranceCompaniesManager Instance { get { return instance; } }
        static InsuranceCompaniesManager()
        {
            instance = new InsuranceCompaniesManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllinsurComponies()
        {
            List<InsuranceCompanyVM> insurcompines = db.InsuranceCompanies.Select(s => new InsuranceCompanyVM
            {
                Id = s.Id,
                NameA = s.NameA,
                NameE = s.NameE

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
                    return new InsuranceCompanyVM
                    {
                        Id = insurcompany.Id,
                        NameA= insurcompany.NameA,
                        NameE= insurcompany.NameE
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
                return ex.Message;
            }
        }

        public dynamic PostInsurCompany(InsuranceCompanyVM i)
        {
            db.InsuranceCompanies.Add(new InsuranceCompany
            {
                NameA = i.NameA,
                NameE = i.NameE

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        
        public dynamic PutInsurCompany(InsuranceCompanyVM i)
        {
            var insurcompany = db.InsuranceCompanies.Find(i.Id);

            insurcompany.NameA = i.NameA;
            insurcompany.NameE = i.NameE;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
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
