using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.BLL
{
    public class FacultyManager
    {
        private elRwadEntities db = new elRwadEntities();
        private static FacultyManager instance;

        public static FacultyManager Instance { get { return instance; } }

        static FacultyManager()
        {
            instance = new FacultyManager();

        }

        public List<FacultyVM> GetFaculties()
        {
            List< FacultyVM>  faculty = db.Faculties.Select(s => new FacultyVM
            {
                Faculty_ID = s.Faculty_ID,
                Faculty_A_Name = s.Faculty_A_Name,
                Faculty_E_Name = s.Faculty_E_Name,
                Faculty_Notes = s.Faculty_Notes
            }).ToList();
            return faculty;
        }


        public FacultyVM GetFacultyById(int facultyId)
        {
            try
            {
                var s = db.Faculties.Where(e => e.Faculty_ID == facultyId).FirstOrDefault();
                if (s != null)
                {
                    return new FacultyVM
                    {
                        Faculty_ID = s.Faculty_ID,
                        Faculty_A_Name = s.Faculty_A_Name,
                        Faculty_E_Name = s.Faculty_E_Name,
                        Faculty_Notes = s.Faculty_Notes

                    };
                }
                else
                {
                    return new FacultyVM
                    {
                        Faculty_ID = 0,
                        Faculty_A_Name = null,
                        Faculty_E_Name = null,
                        Faculty_Notes = null

                    };
                }
            }
            catch (Exception ex)
            {
                return new FacultyVM
                {
                    Faculty_ID = 0,
                    Faculty_A_Name = null,
                    Faculty_E_Name = null,
                    Faculty_Notes = null

                };
            }
        }


        public dynamic PostFaculty( string facultyArName,string facultyEnName,string facultyNotes)
        {
            var faculty = db.Faculties.Add(new Faculty
            {
                Faculty_A_Name = facultyArName,
                Faculty_E_Name = facultyEnName,
                Faculty_Notes = facultyNotes



            });
            var result = db.SaveChanges() > 0 ? true : false;  
            return new
            {
                result = result,
                facultyId = faculty.Faculty_ID
            };
        }




        public dynamic PutFaculty(int facultyId,string facultyArName,string facultyEnName,string facultyNotes)
        {
            var faculty = db.Faculties.Find(facultyId);
            faculty.Faculty_A_Name = facultyArName;
            faculty.Faculty_E_Name = facultyEnName;
            faculty.Faculty_Notes = facultyNotes;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        public dynamic DeleteFaculty(int facultyId)
        {
            var faculty = db.Faculties.Where(s => s.Faculty_ID == facultyId).FirstOrDefault();
            db.Faculties.Remove(faculty);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


       
    }
}
