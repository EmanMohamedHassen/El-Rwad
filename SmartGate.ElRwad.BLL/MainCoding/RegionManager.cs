using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SmartGate.ElRwad.BLL
{
    public class RegionManager
    {
        private static RegionManager instance;
        public static RegionManager Instance { get { return instance; } }
        static RegionManager()
        {
            instance = new RegionManager();
        }
        private elRwadEntities db = new elRwadEntities();


        public dynamic Getregions()
        {
            List<GetRegionVM> region = db.Regions.Select(s => new GetRegionVM
            {
                Id = s.Id,
                NameAr = s.NameAr,
                NameEN = s.NameEn,
                CityId = s.CityId,
                CityName = s.City.Name_A


            }).ToList();
            return region;
        }

        public dynamic GetRegionById(int regionId)
        {
            try
            {
                var s = db.Regions.Where(e => e.Id == regionId).FirstOrDefault();
                if (s != null)
                {
                    return new GetRegionVM
                    {

                        NameAr = s.NameAr,
                        NameEN = s.NameEn,
                        CityId = s.CityId,
                        CityName = s.City.Name_A

                    };
                }
                else
                {
                    return new GetRegionVM
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

        public dynamic GetRegionsByCityId(int cityId)
        {
            try
            {
                List<GetRegionVM> region = db.Regions.Where(e => e.CityId == cityId).Select(s => new GetRegionVM
                {
                    Id = s.Id,
                    NameAr = s.NameAr,
                    NameEN = s.NameEn,
                    CityId = s.CityId,
                    CityName = s.City.Name_A

                }).ToList();
                return region;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        public dynamic PostRegion(RegionVM r)
        {
            var region = db.Regions.Add(new Region
            {
                NameAr = r.NameAr,
                NameEn = r.NameEN,
                CityId = r.CityId
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                regionId = region.Id
            };
        }

        public dynamic PutRegion(RegionVM r)
        {
            var region = db.Regions.Find(r.Id);
            region.NameAr = r.NameAr;
            region.NameEn = r.NameEN;
            region.CityId = r.CityId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        public dynamic DeleteRegion(int regionId)
        {
            var region = db.Regions.Where(s => s.Id == regionId).FirstOrDefault();
            db.Regions.Remove(region);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}