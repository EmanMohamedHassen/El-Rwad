using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL
{
   public class StoresManager
    {
        private static StoresManager instance;
        public static StoresManager Instance { get { return instance; } }
        static StoresManager()
        {
            instance = new StoresManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllStores()
        {
            List<StoresVM> stores = db.Stores.Select(s => new StoresVM
            {
                Id = s.Id,
                Address= s.Address,
                RegionId = s.RegionId,
                RegionName = s.Region.NameAr,
                CityId = s.CityId,
                CityName = s.City.Name_A,
                Phone = s.Phone,
                StoreManagerId = s.StoreManagerId,
                StoreManagerName = s.Employee.FullName

            }).ToList();
            return stores;
        }
        public dynamic GetStoreById(int id)
        {
            try
            {
                var store = db.Stores.Where(e => e.Id == id).FirstOrDefault();
                if (store != null)
                {
                    return new StoresVM
                    {
                        Id = store.Id,
                        Address = store.Address,
                        RegionId = store.RegionId,
                        RegionName = store.Region.NameAr,
                        CityId = store.CityId,
                        CityName = store.City.Name_A,
                        Phone = store.Phone,
                        StoreManagerId = store.StoreManagerId,
                        StoreManagerName = store.Employee.FullName

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

        public dynamic PostStore(StoresVM s)
        {
            var store = db.Stores.Add(new Store
            {
                Address = s.Address,
                RegionId = s.RegionId,
                CityId = s.CityId,
                Phone = s.Phone,
                StoreManagerId = s.StoreManagerId

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                storeId = store.Id
            };
        }

        public dynamic PutStore(StoresVM s)
        {
            var store = db.Stores.Find(s.Id);
            store.Address = s.Address;
            store.RegionId = s.RegionId;
            store.CityId = s.CityId;
            store.Phone = s.Phone;
            store.StoreManagerId =s.StoreManagerId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

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
