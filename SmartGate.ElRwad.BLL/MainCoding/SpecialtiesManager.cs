using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL
{
    public class SpecialtiesManager
    {
        private static SpecialtiesManager instance;
        public static SpecialtiesManager Instance { get { return instance; } }
        static SpecialtiesManager()
        {
            instance = new SpecialtiesManager();
        }

        private elRwadEntities db = new elRwadEntities();
        public dynamic GetSpecialties()
        {
            List<SpecialtiesVM> specialties = db.Specialties.Select(s => new SpecialtiesVM
            {
                Id = s.Specialty_ID,
                NameA = s.Specialty_A_Name,
                NameE = s.Specialty_E_Name,
                Notes = s.Specialty_Notes

            }).ToList();
            return specialties;
        }
        public dynamic GetSpecialtyById(int specialtiesId)
        {
            try
            {
                var s = db.Specialties.Where(e => e.Specialty_ID == specialtiesId).FirstOrDefault();
                if (s != null)
                {
                    return new SpecialtiesVM
                    {
                        //specialtyId = s.Specialty_ID,
                        NameA = s.Specialty_A_Name,
                        NameE = s.Specialty_E_Name,
                        Notes = s.Specialty_Notes

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
        //get speciality by faculty
        public dynamic GetSpecialtyByFacultyId(int facultyId)
        {
            try
            {
                List<SpecialtiesVM> specialty = db.Specialties.Where(e => e.Faculty_ID == facultyId).Select(s => new SpecialtiesVM
                {
                    Id = s.Specialty_ID,
                    NameA = s.Specialty_A_Name,
                    NameE = s.Specialty_E_Name,
                    Notes = s.Specialty_Notes

                }).ToList();
                return specialty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public dynamic PostSpecialty(SpecialtiesVM s)
        {
            var specialty = db.Specialties.Add(new Specialty
            {
                Specialty_A_Name = s.NameA,
                Specialty_E_Name = s.NameE,
                Specialty_Notes = s.Notes



            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                specialtyId = specialty.Specialty_ID
            };
        }

        public dynamic PutSpecialty(SpecialtiesVM s)
        {
            var specialties = db.Specialties.Find(s.Id);

            specialties.Specialty_A_Name = s.NameA;
            specialties.Specialty_E_Name = s.NameE;
            specialties.Specialty_Notes = s.Notes;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic DeleteSpecialty(int specialtiesId)
        {
            var specialties = db.Specialties.Where(s => s.Specialty_ID == specialtiesId).FirstOrDefault();
            db.Specialties.Remove(specialties);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic specialtiesExists(int specialtiesId)
        {
            var specialties = db.Specialties.Count(s => s.Specialty_ID == specialtiesId) > 0 ? true : false;
            return new
            {
                specialties = specialties
            };
        }

    }
}