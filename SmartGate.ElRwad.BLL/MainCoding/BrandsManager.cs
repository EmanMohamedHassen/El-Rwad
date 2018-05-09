using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.BLL
{
    public class BrandsManager
    {
        private static BrandsManager instance;

        public static BrandsManager Instance { get { return instance; } }

        static BrandsManager()
        {
            instance = new BrandsManager();
        }
        private elRwadEntities db = new elRwadEntities();

            public dynamic GetAllBrands()
            {
                List<BrandVM> brands = db.Brands.Select(s => new BrandVM
                {
                    Id = s.Id,
                    NameAr = s.NameAr,
                    NameEn = s.NameEn,
                    UserId = s.UserId,
                    LastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()
                }).ToList();
                return brands;
            }


            public dynamic GetBarndById(int brandId)
            {
                try
                {
                    var s = db.Brands.Where(e => e.Id == brandId).FirstOrDefault();
                    if (s != null)
                    {
                        return new BrandVM
                        {
                            NameAr = s.NameAr,
                            NameEn = s.NameEn,
                            UserId = s.UserId,
                            LastUpdate = s.LastUpdate.Value.ToString("yyyy-MM-dd")
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


        public dynamic PostBrand(BrandVM B)
        {
            db.Brands.Add(new Brand
            {
                NameAr = B.NameAr,
                NameEn = B.NameEn,
                UserId = B.UserId,
                LastUpdate = DateTime.Now

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
            public dynamic PutBrand(BrandVM B)
            {
                var brand = db.Brands.Find(B.Id);

                brand.NameAr = B.NameAr;
                brand.NameEn = B.NameEn;
                brand.UserId = B.UserId;
                brand.LastUpdate = DateTime.Now;
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }

            public dynamic DeleteBrand(int brandId)
            {
                var brand = db.Brands.Where(s => s.Id == brandId).FirstOrDefault();
                db.Brands.Remove(brand);
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }


        }
    }




