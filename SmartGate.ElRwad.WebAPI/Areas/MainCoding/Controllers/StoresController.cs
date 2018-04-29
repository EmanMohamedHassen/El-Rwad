using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class StoresController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetAllStores()
        {
            var stores = db.Stores.Select(s => new
            {
                id = s.Id,
                address = s.Address,
                regionId = s.RegionId,
                regionName = s.Region.NameAr,
                cityId = s.CityId,
                cityName = s.City.Name_A,
                phone = s.Phone,
                storeManagerId = s.StoreManagerId,
                storeManagerName = s.Employee.FullName

            }).ToList();
            return stores;
        }

        [HttpGet]
        public dynamic GetStoreById(int id)
        {
            try
            {
                var store = db.Stores.Where(e => e.Id == id).FirstOrDefault();
                if (store != null)
                {
                    return new
                    {
                        id = store.Id,
                        address = store.Address,
                        regionId = store.RegionId,
                        regionName = store.Region.NameAr,
                        cityId = store.CityId,
                        cityName = store.City.Name_A,
                        phone = store.Phone,
                        storeManagerId = store.StoreManagerId,
                        storeManagerName = store.Employee.FullName

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
        public dynamic PostStore(string address, int regionId, int cityId, string phone, int storeManagerId)
        {
            var store = db.Stores.Add(new Store
            {
                Address = address,
                RegionId = regionId,
                CityId = cityId,
                Phone = phone,
                StoreManagerId = storeManagerId

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                storeId = store.Id
            };
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPut]
        public dynamic PutStore(int id, string address, int regionId, int cityId, string phone, int storeManagerId)
        {
            var store = db.Stores.Find(id);
            store.Address = address;
            store.RegionId = regionId;
            store.CityId = cityId;
            store.Phone = phone;
            store.StoreManagerId = storeManagerId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
        public dynamic DeleteStore(int id)
        {
            var store = db.Stores.Where(s => s.Id == id).FirstOrDefault();
            db.Stores.Remove(store);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


    }
}
