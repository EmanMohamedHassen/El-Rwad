using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL
{
    public class UniversityManager
    {
        private static UniversityManager instance;
        public static UniversityManager Instance { get { return instance; } }
        static UniversityManager()
        {
            instance = new UniversityManager();
        }
        private elRwadEntities db = new elRwadEntities();


        public dynamic GetUniversity()
        {
            List< UniversityVM> university = db.Universities.Select(s => new UniversityVM
            {
                University_ID = s.University_ID,
                University_A_Name = s.University_A_Name,
                University_E_Name = s.University_E_Name,
                Notes = s.Notes

            }).ToList();
            return university;
        }

        public dynamic GetUniversityById(int universityId)
        {
            try
            {
                var s = db.Universities.Where(e => e.University_ID == universityId).FirstOrDefault();
                if (s != null)
                {
                    return new UniversityVM
                    {

                        University_ID = s.University_ID,

                        University_A_Name = s.University_A_Name,
                        University_E_Name = s.University_E_Name,
                        Notes = s.Notes

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


        public dynamic PostUniversity( UniversityVM university )
        {
            var university1 = db.Universities.Add(new University
            {
                University_A_Name = university.University_A_Name,
                University_E_Name = university.University_E_Name,
                Notes = university.Notes

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                universityId = university1.University_ID
            };
        }

        public dynamic PutUniversity( UniversityVM university  )
        {
            var university1 = db.Universities.Find(university.University_ID);

            university1.University_A_Name = university1.University_A_Name;
            university1.University_E_Name = university1.University_E_Name;
            university1.Notes = university1.Notes;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic DeleteUniversity(int universityId)
        {
            var university = db.Universities.Where(s => s.University_ID == universityId).FirstOrDefault();
            db.Universities.Remove(university);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic universityExists(int universityId)
        {
            var university = db.Universities.Count(s => s.University_ID == universityId) > 0 ? true : false;
            return new 
            {
                university = university
            };
        }
    }
}
