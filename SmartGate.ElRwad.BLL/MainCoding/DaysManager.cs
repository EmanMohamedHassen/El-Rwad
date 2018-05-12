using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL
{
  public  class DaysManager
    {
        private static DaysManager instance;
        public static DaysManager Instance { get { return instance; } }
        static DaysManager()
        {
            instance = new DaysManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllDays()
        {
           List<DaysVM> days = db.Days.Select(s => new DaysVM
            {
                Id= s.Id,
                NameAr= s.NameAr,
                NameEn = s.NAmeEn,
            }).ToList();
            return days;

        }
        public dynamic GetDayById(int id)
        {
            try
            {
                var days = db.Days.Where(e => e.Id == id).FirstOrDefault();
                if (days != null)
                {
                    return new DaysVM
                    {
                        NameAr = days.NameAr,
                        NameEn = days.NAmeEn
                    };
                }
                else
                {
                    return new DaysVM
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

        public dynamic PostDay(DaysVM d)
        {
            var day = db.Days.Add(new Day
            {
                NameAr = d.NameAr,
                NAmeEn = d.NameEn

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                dayId = day.Id
            };

        }

        public dynamic PutDay(DaysVM d)
        {
            var day = db.Days.Find(d.Id);
            day.NameAr = d.NameAr;
            day.NAmeEn = d.NameAr;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic DeleteDay(int id)
        {
            var day = db.Days.Where(e => e.Id == id).FirstOrDefault();

            db.Days.Remove(day);

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };

        }

    }
}
