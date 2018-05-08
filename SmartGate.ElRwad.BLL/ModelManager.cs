using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL
{
   public class ModelManager
    {
        private static ModelManager instance;
        public static ModelManager Instance { get { return instance; } }
        static ModelManager()
        {
            instance = new ModelManager();
        }
        private elRwadEntities db = new elRwadEntities();

        
        public dynamic GetAllModels()
        {
            var models = db.Models.Select(s => new ModelVM
            {
                ID = s.Id,
                NameAr = s.NameAr,
                NameEn = s.NameEn,
                BrandId = s.BrandId,
                BrandNameAr = s.Brand.NameAr
            }).ToList();
            return models;
        }
        
        public dynamic GetModelById(int modelId)
        {
            try
            {
                var model = db.Models.Where(e => e.Id == modelId).FirstOrDefault();
                if (model != null)
                {
                    return new ModelVM
                    {
                        NameAr= model.NameAr,
                        NameEn= model.NameEn,
                        BrandId = model.BrandId,
                        BrandNameAr = model.Brand.NameAr

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
                {Message = ex.Message
                };
            }
        }

        
        public dynamic GetModelByBrandId(int brandId)
        {
            try
            {
                var model = db.Models.Where(e => e.BrandId == brandId).Select(s => new ModelVM
                {
                   ID= s.Id,
                    NameAr= s.NameAr,
                    NameEn= s.NameEn,
                    BrandNameAr= s.Brand.NameAr

                }).ToList();
                return model;
            }
            catch (Exception ex)
            {
                return new
                {
                    message = ex.Message
                };
            }
        }

        public dynamic PostModel(ModelVM m)
        {
            var model = db.Models.Add(new Model
            {
                NameAr = m.NameAr,
                NameEn = m.NameEn,
                BrandId = m.BrandId,


            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                modelId = model.Id

            };
        }
        
        public dynamic PutModel(ModelVM m)
        {
            var model = db.Models.Find(m.ID);

            model.NameAr = m.NameAr;
            model.NameEn = m.NameEn;
            model.BrandId = m.BrandId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        public dynamic DeleteModel(int modelId)
        {
            var model = db.Models.Where(s => s.Id == modelId).FirstOrDefault();
            db.Models.Remove(model);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
