using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL
{
    public class ManufacturingYearManager
    {
        private static ManufacturingYearManager instance;
        public static ManufacturingYearManager Instance { get { return instance; } }
        static ManufacturingYearManager()
        {
            instance = new ManufacturingYearManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllYears()
        {
            List< ManufacturingYearVM> years = db.ManufacturingYears.Select(s => new ManufacturingYearVM
            {
                yearId = s.Id,
                year = s.Year
            }).ToList();
            return years;
        }
        
        public dynamic GetYearById(int yearId)
        {
            try
            {
                var year = db.ManufacturingYears.Where(e => e.Id == yearId).FirstOrDefault();
                if (year != null)
                {
                    return new ManufacturingYearVM
                    {
                        yearId = year.Id,
                        year = year.Year
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
        
        public dynamic PostYear(ManufacturingYearVM year)
        {
            db.ManufacturingYears.Add(new ManufacturingYear
            {
                Year = year.year

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic PutYears(ManufacturingYearVM year)
        {
            var manufacturingYear = db.ManufacturingYears.Find(year.yearId);

            manufacturingYear.Year = year.year;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        
        public dynamic DeleteYear(int yearId)
        {
            var year = db.ManufacturingYears.Where(s => s.Id == yearId).FirstOrDefault();
            db.ManufacturingYears.Remove(year);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
