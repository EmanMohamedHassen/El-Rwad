using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
namespace SmartGate.ElRwad.BLL
{
   public class CityManager
    {
        private static CityManager instance;
        public static CityManager Instance { get { return instance; } }

        static CityManager()
        {
            instance = new CityManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetCities()
        {
           List<CityVM> city = db.Cities.Select(s => new CityVM
            {
                Id= s.City_ID,
                NameA= s.Name_A,
                NameE= s.Name_E,
               Description= s.Description,
                UserId = s.User_ID,
                //cityLastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd")
                LastUpdate= s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return city;
        }

        public dynamic GetCityById(int cityId)
        {
            try
            {
                var s = db.Cities.Where(e => e.City_ID == cityId).FirstOrDefault();
                if (s != null)
                {
                    return new CityVM
                    {
                        //cityId = s.City_ID,
                        NameA = s.Name_A,
                        NameE= s.Name_E,
                        Description= s.Description,
                        UserId= s.User_ID,
                        LastUpdate= s.Last_Update.Value.ToString("yyyy-MM-dd")
                    };
                }
                else
                {
                    return new CityVM
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

        public dynamic PostCity(CityVM C)
        {
            var city = db.Cities.Add(new City
            {
                Name_A = C.NameA,
                Name_E = C.NameE,
                Description = C.Description,
                User_ID = C.UserId,
                Last_Update = DateTime.Now



            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                cityId = city.City_ID
            };
        }

        public dynamic PutCity(CityVM C)
        {
            var city = db.Cities.Find(C.Id);
            city.Name_A = C.NameA;
            city.Name_E = C.NameE;

            city.Description = C.Description;
            city.User_ID = C.UserId;
            city.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic DeleteCity(int cityId)
        {
            var city = db.Cities.Where(s => s.City_ID == cityId).FirstOrDefault();
            db.Cities.Remove(city);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

    }
}
