using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.BLL
{
   public class CarCategoriesManager
    {
            private elRwadEntities db = new elRwadEntities();

        private static CarCategoriesManager instance;
        public static CarCategoriesManager Instance { get { return instance; } }

        static CarCategoriesManager()
        {
            instance = new CarCategoriesManager();
        }
            public dynamic GetAllCategories()
            {
                List<CarCategoriesVM> category = db.CarsCategories.Select(s => new CarCategoriesVM
                {
                    Id = s.Id,
                    NameAr = s.NameAr,
                    NameEn = s.NameEn,
                    ModelId = s.ModelId,
                    ModelName = s.Model.NameAr
                }).ToList();
                return category;
            }

            public dynamic GetCategorById(int categoryId)
            {
                try
                {
                    var category = db.CarsCategories.Where(e => e.Id == categoryId).FirstOrDefault();
                    if (category != null)
                    {
                        return new CarCategoriesVM
                        {
                            NameAr = category.NameAr,
                            NameEn= category.NameEn,
                            ModelId = category.ModelId,
                            ModelName= category.Model.NameAr

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

            public dynamic GetCategoryByModelId(int modelId)
            {
                try
                {
                    var category = db.CarsCategories.Where(e => e.ModelId == modelId).Select(s => new CarCategoriesVM
                    {

                        Id= s.Id,
                        NameAr= s.NameAr,
                        NameEn= s.NameEn,
                        ModelName= s.Model.NameAr

                    }).ToList();
                    return category;
                }
                catch (Exception ex)
                {
                    return new
                    {
                        Message = ex.Message
                    };
                }
            }
            public dynamic PostCategory(CarCategoriesVM C)
            {

                db.CarsCategories.Add(new CarsCategory
                {
                    NameAr = C.NameAr,
                    NameEn = C.NameEn,
                    ModelId = C.ModelId

                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic PutModel(CarCategoriesVM C)
            {
                var category = db.CarsCategories.Find(C.Id);

                category.NameAr = C.NameAr;
                category.NameEn = C.NameEn;
                category.ModelId = C.ModelId;
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic DeleteCategory(int categoryId)
            {
                var category = db.CarsCategories.Where(s => s.Id == categoryId).FirstOrDefault();
                db.CarsCategories.Remove(category);
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }




        }
    }

