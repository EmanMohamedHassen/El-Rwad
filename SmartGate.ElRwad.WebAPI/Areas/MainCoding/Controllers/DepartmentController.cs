using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class DepartmentController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetDepartment()
        {
            var department = db.Departments.Select(s => new
            {
                departmentId = s.Department_ID,
                departmentAName = s.Department_A_Name,
                departmentEName = s.Department_E_Name,
                departmentBranchNameAr = s.Branch.Branch_A_Title,
                departmentDescription = s.Department_Description,
                departmentManagerId = s.Manager_ID,
                departmentManagerName = s.Employee.FullName,
                departmentUserId = s.User_ID,
                departmentLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                departmentBranchId = s.Branch_Id
            }).ToList();
            return department;
        }

        [HttpGet]
        public dynamic GetDepartmentById(int departmentId)
        {
            try
            {
                var s = db.Departments.Where(e => e.Department_ID == departmentId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        //departmentId = s.Department_ID,
                        departmentAName = s.Department_A_Name,
                        departmentEName = s.Department_E_Name,
                        departmentBranchNameAr = s.Branch.Branch_A_Title,
                        departmentBranchNameEn = s.Branch.Branch_E_Name,


                        departmentDescription = s.Department_Description,
                        departmentManagerId = s.Manager_ID,
                        departmentManagerName = s.Employee.FullName,

                        departmentUserId = s.User_ID,
                        departmentLastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd"),
                        departmentBranchId = s.Branch_Id

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
        public dynamic GetDepartmentByBranchId(int branchId)
        {
            try
            {
                var department = db.Departments.Where(e => e.Branch_Id == branchId).Select(s => new
                {
                    departmentId = s.Department_ID,
                    //departmentBranchId = s.Branch_ID,
                    departmentBranchNameAr = s.Branch.Branch_A_Title,
                    departmentBranchNameEn = s.Branch.Branch_E_Name,

                    departmentAName = s.Department_A_Name,
                    departmentEName = s.Department_E_Name,

                    departmentDescription = s.Department_Description,
                    departmentManagerId = s.Manager_ID,
                    departmentManagerName = s.Employee.FullName,

                    departmentUserId = s.User_ID,
                    departmentLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()
                }).ToList();
                return department;
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
        public dynamic PostDepartment(
          int departmentBranchId,
          string departmentAName,
          string departmentEName,
          string departmentDescription,
           int departmentManagerId,
          int departmentUserId
            )
        {
            var department = db.Departments.Add(new Department
            {
                Branch_Id = departmentBranchId,
                Department_A_Name = departmentAName,
                Department_E_Name = departmentEName,
                Department_Description = departmentDescription,
                Manager_ID = departmentManagerId,
                User_ID = departmentUserId,
                Last_Update = DateTime.Now,
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                departmentId = department.Department_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDepartment(int departmentId,
          int departmentBranchId,
          string departmentAName,
          string departmentEName,
          string departmentDescription,
           int departmentManagerId,
          int departmentUserId
            )
        {
            try
            {
                var department = db.Departments.Find(departmentId);
                department.Branch_Id = departmentBranchId;
                department.Department_A_Name = departmentAName;
                department.Department_E_Name = departmentEName;
                department.Department_Description = departmentDescription;
                department.Manager_ID = departmentManagerId;
                department.User_ID = departmentUserId;
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
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }


        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
        [HttpGet]
        private dynamic departmentExists(int departmentId)
        {
            var department = db.Departments.Count(s => s.Department_ID == departmentId) > 0 ? true : false;
            return new
            {
                department = department
            };
        }

    }
}
