using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class SpecialtiesController : ApiController
    {

        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetSpecialties()
        {
            var specialties = db.Specialties.Select(s => new
            {
                specialtyId = s.Specialty_ID,
                specialtyArName = s.Specialty_A_Name,
                specialtyEnName = s.Specialty_E_Name,
                specialtyNotes = s.Specialty_Notes

            }).ToList();
            return specialties;
        }
        [HttpGet]
        public dynamic GetSpecialtyById(int specialtiesId)
        {
            try
            {
                var s = db.Specialties.Where(e => e.Specialty_ID == specialtiesId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        //specialtyId = s.Specialty_ID,
                        specialtyArName = s.Specialty_A_Name,
                        specialtyEnName = s.Specialty_E_Name,
                        specialtyNotes = s.Specialty_Notes

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
        [HttpGet]
        //get speciality by faculty
        public dynamic GetSpecialtyByFacultyId(int facultyId)
        {
            try
            {
                var specialty = db.Specialties.Where(e => e.Faculty_ID == facultyId).Select(s => new
                {
                    specialtyId = s.Specialty_ID,
                    specialtyArName = s.Specialty_A_Name,
                    specialtyEnName = s.Specialty_E_Name,
                    specialtyNotes = s.Specialty_Notes

                }).ToList();
                return specialty;
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
        public dynamic PostSpecialty(

            string specialtyArName,
            string specialtyEnName,
            string specialtyNotes
            )
        {
            var specialty = db.Specialties.Add(new Specialty
            {

                Specialty_A_Name = specialtyArName,
                Specialty_E_Name = specialtyEnName,
                Specialty_Notes = specialtyNotes



            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                specialtyId = specialty.Specialty_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSpecialty(
            int specialtiesId,
            string specialtyArName,
            string specialtyEnName,
            string specialtyNotes


            )
        {
            var specialties = db.Specialties.Find(specialtiesId);

            specialties.Specialty_A_Name = specialtyArName;
            specialties.Specialty_E_Name = specialtyEnName;
            specialties.Specialty_Notes = specialtyNotes;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
        [HttpGet]
        private dynamic specialtiesExists(int specialtiesId)
        {
            var specialties = db.Specialties.Count(s => s.Specialty_ID == specialtiesId) > 0 ? true : false;
            return new
            {
                specialties = specialties
            };
        }




    }
}
