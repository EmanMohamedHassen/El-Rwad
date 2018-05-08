using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL
{
   public class MonthManager
    {
        private static MonthManager instance;
        public static MonthManager Instance { get { return instance; } }
        static MonthManager()
        {
            instance = new MonthManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetMonth()
        {
            List<MonthVM> month = db.Proj_Month.Select(s => new MonthVM
            {
                Id= s.Month_ID,
                NameAr= s.Month_Name,
                NameEn= s.Month_Name_EN
            }).ToList();
            return month;
        }

        public dynamic GetMonthById(int monthId)
        {
            try
            {
                var s = db.Proj_Month.Where(e => e.Month_ID == monthId).FirstOrDefault();
                if (s != null)
                {
                    return new MonthVM
                    {
                        //monthId = s.Month_ID,
                        NameAr= s.Month_Name,
                        NameEn= s.Month_Name_EN

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
                {message = ex.Message
                };
            }
        }

        public dynamic PostMonth(MonthVM m)
        {
            var month = db.Proj_Month.Add(new Proj_Month
            {
                Month_ID = m.Id,
                Month_Name = m.NameAr,
                Month_Name_EN = m.NameEn

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                monthId = month.Month_ID
            };
        }

        public dynamic PutMonth(MonthVM m)
        {
            var month = db.Proj_Month.Find(m.Id);
            month.Month_ID = m.Id;
            month.Month_Name = m.NameAr;
            month.Month_Name_EN = m.NameEn;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic DeleteMonth(byte monthId)
        {
            var month = db.Proj_Month.Where(s => s.Month_ID == monthId).FirstOrDefault();
            db.Proj_Month.Remove(month);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic monthExists(byte monthId)
        {
            var month = db.Proj_Month.Count(s => s.Month_ID == monthId) > 0 ? true : false;
            return new
            {
                month = month
            };
        }

    }
}
