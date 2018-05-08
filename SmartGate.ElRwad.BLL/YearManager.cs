using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL
{
    public class YearManager
    {
        private static YearManager instance;
        public static YearManager Instance { get { return instance; } }
        static YearManager()
        {
            instance = new YearManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetYear()
        {
            List<YearVM> year = db.Proj_Year.Select(s => new YearVM
            {
                ID = s.ProjYear_ID,
                Year = s.ProjYear_Name
            }).ToList();
            return year;
        }


        public dynamic GetYearById(int yearId)
        {
            try
            {
                var s = db.Proj_Year.Where(e => e.ProjYear_ID == yearId).FirstOrDefault();
                if (s != null)
                {
                    return new YearVM
                    {
                        ID = s.ProjYear_ID,
                        Year = s.ProjYear_Name
                    };
                }
                else
                {
                    return new YearVM
                    {
                        ID = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public dynamic PostYearId(YearVM y)
        {
            var year = db.Proj_Year.Add(new Proj_Year
            {
                ProjYear_ID = y.ID,
                ProjYear_Name = y.Year
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new 
            {
                result = result,
                yearId = year.ProjYear_ID
            };
        }

        public dynamic PutYear(PutYearVM y)
        {
            var year = db.Proj_Year.Find(y.ID);

            year.ProjYear_ID = y.NewID;
            year.ProjYear_Name = y.Year;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic DeleteYear(int yearId)
        {
            var year = db.Proj_Year.Where(s => s.ProjYear_ID == yearId).FirstOrDefault();
            db.Proj_Year.Remove(year);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic yearExists(int yearId)
        {
            var year = db.Proj_Year.Count(s => s.ProjYear_ID == yearId) > 0 ? true : false;
            return new
            {
                year = year
            };
        }

    }
}
