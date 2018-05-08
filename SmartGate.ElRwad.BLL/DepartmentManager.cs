using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.BLL
{
   public class DepartmentManager
    {
        private static DepartmentManager instance;
        public static DepartmentManager Instance { get { return instance; } }
        static DepartmentManager()
        {
            instance = new DepartmentManager();
        }
        private elRwadEntities db = new elRwadEntities();
  
        public dynamic GetDepartment()
        {
            List<DepartmentVM> department = db.Departments.Select(s => new DepartmentVM
            {
                Id= s.Department_ID,
                NameA= s.Department_A_Name,
                NameE= s.Department_E_Name,
                BranchNameAR = s.Branch.Branch_A_Title,
                Description = s.Department_Description,
                ManagerId= s.Manager_ID,
                ManagerName = s.Employee.FullName,
                UserId = s.User_ID,
                LastUpdate= s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                BranchId= s.Branch_Id
            }).ToList();
            return department;
        }

        public dynamic GetDepartmentById(int departmentId)
        {
            try
            {
                var s = db.Departments.Where(e => e.Department_ID == departmentId).FirstOrDefault();
                if (s != null)
                {
                    return new DepartmentVM
                    {
                        //departmentId = s.Department_ID,
                        NameA = s.Department_A_Name,
                        NameE= s.Department_E_Name,
                        BranchNameAR= s.Branch.Branch_A_Title,
                        BranchNameEN= s.Branch.Branch_E_Name,
                        Description= s.Department_Description,
                        ManagerId= s.Manager_ID,
                        ManagerName= s.Employee.FullName,
                        UserId= s.User_ID,
                        LastUpdate= s.Last_Update.Value.ToString("yyyy-MM-dd"),
                        BranchId= s.Branch_Id

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
        public dynamic GetDepartmentByBranchId(int branchId)
        {
            try
            {
                var department = db.Departments.Where(e => e.Branch_Id == branchId).Select(s => new DepartmentVM
                {
                    Id= s.Department_ID,
                    //departmentBranchId = s.Branch_ID,
                    BranchNameAR= s.Branch.Branch_A_Title,
                    BranchNameEN= s.Branch.Branch_E_Name,

                    NameA= s.Department_A_Name,
                    NameE= s.Department_E_Name,

                    Description= s.Department_Description,
                    ManagerId= s.Manager_ID,
                    ManagerName= s.Employee.FullName,

                    UserId= s.User_ID,
                    LastUpdate= s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()
                }).ToList();
                return department;
            }
            catch (Exception ex)
            {
                return new
                {
                    Message = ex.Message
                };
            }
        }
        public dynamic PostDepartment(DepartmentVM d)
        {
            var department = db.Departments.Add(new Department
            {
                Branch_Id = d.BranchId,
                Department_A_Name = d.NameA,
                Department_E_Name = d.NameE,
                Department_Description = d.Description,
                Manager_ID = d.ManagerId,
                User_ID = d.UserId,
                Last_Update = DateTime.Now,
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                departmentId = department.Department_ID
            };
        }
        public dynamic PutDepartment(DepartmentVM d)
        {
            try
            {
                var department = db.Departments.Find(d.Id);
                department.Branch_Id = d.BranchId;
                department.Department_A_Name = d.NameA;
                department.Department_E_Name = d.NameE;
                department.Department_Description = d.Description;
                department.Manager_ID = d.ManagerId;
                department.User_ID = d.UserId;
                department.Last_Update = DateTime.Now;
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Message = ex.Message
                };
            }
        }

        public dynamic DeleteDepartment(int departmentId)
        {
            var department = db.Departments.Where(s => s.Department_ID == departmentId).FirstOrDefault();
            db.Departments.Remove(department);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

       public dynamic departmentExists(int departmentId)
        {
            var department = db.Departments.Count(s => s.Department_ID == departmentId) > 0 ? true : false;
            return new
            {
                department = department
            };
        }
    }
}
