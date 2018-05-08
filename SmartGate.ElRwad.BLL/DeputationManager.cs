using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL
{
    public class DeputationManager
    {
        private static DeputationManager instance;
        public static DeputationManager Instance { get { return instance; } }
        static DeputationManager()
        {
            instance = new DeputationManager();
        }
        private elRwadEntities db = new elRwadEntities();

        
        public dynamic GetDeputations()
        {
            List<DeputationVM> deputation = db.Deputations.Select(s => new DeputationVM
            {
                Deputations_ID = s.Deputations_ID,
                Title = s.Title,
                Tittle_EN = s.Tittle_EN
            }).ToList();
            return deputation;

        }
        
        public dynamic GetDeputationById(int deputationId)
        {
            try
            {
                var s = db.Deputations.Where(e => e.Deputations_ID == deputationId).FirstOrDefault();
                if (s != null)
                {
                    return new DeputationVM
                    {
                        Title = s.Title,
                        Tittle_EN = s.Tittle_EN
                    };
                }
                else
                {
                    return new DeputationVM
                    {
                        Deputations_ID = 0
                    };
                }
            }

            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        
        public dynamic PostDeputation(DeputationVM deputation)
        {
            var deputation1 = db.Deputations.Add(new Deputation
            {
                Title = deputation.Title,
                Tittle_EN = deputation.Tittle_EN

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                deputationId = deputation1.Deputations_ID
            };
        }

        
        public dynamic PutDeputation(DeputationVM deputation)
        {
            var deputation1 = db.Deputations.Find(deputation.Deputations_ID);
            deputation.Title = deputation.Title;
            deputation.Tittle_EN = deputation.Tittle_EN;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        
        public dynamic DeleteDeputation(int deputationId)
        {
            var deputation = db.Deputations.Where(s => s.Deputations_ID == deputationId).FirstOrDefault();
            db.Deputations.Remove(deputation);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };

        }
        
        public dynamic DeputationExists(int deputationId)
        {
            var deputation = db.Deputations.Count(s => s.Deputations_ID == deputationId) > 0 ? true : false;
            return new
            {
                deputation = deputation
            };
        }
    }
}
