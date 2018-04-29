using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class CityController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetCities()
        {
            var city = db.Cities.Select(s => new
            {
                cityId = s.City_ID,
                cityArName = s.Name_A,
                cityEnName = s.Name_E,
                cityDescription = s.Description,
                cityUserId = s.User_ID,
                //cityLastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd")
                cityLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return city;
        }
        [HttpGet]
        public dynamic GetCityById(int cityId)
        {
            try
            {
                var s = db.Cities.Where(e => e.City_ID == cityId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        //cityId = s.City_ID,
                        cityArName = s.Name_A,
                        cityEnName = s.Name_E,
                        cityDescription = s.Description,
                        cityUserId = s.User_ID,
                        cityLastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd")
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
        public dynamic PostCity(string cityArName, string cityEnName, string cityDescription, int userId)
        {
            var city = db.Cities.Add(new City
            {
                Name_A = cityArName,
                Name_E = cityEnName,
                Description = cityDescription,
                User_ID = userId,
                Last_Update = DateTime.Now



            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                cityId = city.City_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutCity(int cityId, string cityArName, string cityEnName, string cityDescription, int userId)
        {
            var city = db.Cities.Find(cityId);
            city.Name_A = cityArName;
            city.Name_E = cityEnName;

            city.Description = cityDescription;
            city.User_ID = userId;
            city.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
