using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class JobCategoryController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        //Get all job Categories
        [HttpGet]
        public dynamic GetJobCategories()
        {
            var jobCategories = db.Employees_Categories.Select(s => new
            {
                jobCategoryId = s.Category_ID,
                jobCategoryAr = s.Name_A,
                jobCategoryEn = s.Name_E,
                description = s.Description,
                // departmentId = s.DepartmentId,
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return jobCategories;
        }

        /// <summary>
        /// Get job Category by Id
        /// </summary>
        /// <param name="jobCategoryId"></param>
        /// <returns></returns>

        [HttpGet]
        public dynamic GetJobCategoryById(int jobCategoryId)
        {
            try
            {
                var s = db.Employees_Categories.Where(e => e.Category_ID == jobCategoryId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        jobCategoryId = s.Category_ID,
                        jobCategoryAr = s.Name_A,
                        jobCategoryEn = s.Name_E,
                        description = s.Description,
                        //departmentId = s.DepartmentId,

                        userId = s.User_ID,
                        lastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd")
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

        ///// <summary>
        ///// get jobs by department id
        ///// </summary>
        ///// <param name="departmentId"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public dynamic GetJobByDepartmentId(int departmentId)
        //{
        //    try
        //    {
        //        var jobCategory = db.Employees_Categories.Where(e => e.DepartmentId == departmentId).Select(s => new
        //        {
        //            jobCategoryId = s.Category_ID,
        //            jobCategoryAr = s.Name_A,
        //            jobCategoryEn = s.Name_E,
        //            description = s.Description,
        //            userId = s.User_ID,
        //            lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

        //        }).ToList();
        //        return jobCategory;
        //    }

        //    catch (Exception ex)
        //    {
        //        return new
        //        {
        //            result = new
        //            {
        //                Id = 0
        //            }
        //        };
        //    }
        //}


        //Add new job Category
        [HttpPost]
        public dynamic PostJobCategory(

            string jobCategoryAr,
            string jobCategoryEn,
            string description,
            //int departmentId,
            int userId
            )
        {
            var jobCategory = db.Employees_Categories.Add(new Employees_Categories
            {
                Name_A = jobCategoryAr,
                Name_E = jobCategoryEn,
                Description = description,
                //DepartmentId = departmentId,
                User_ID = userId,
                Last_Update = DateTime.Now
            });

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                jobCategoryId = jobCategory.Category_ID
            };
        }


        //update job category
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutJobCategory(
            int jobCategoryId,
            string jobCategoryAr,
            string jobCategoryEn,
            string description,
            //int departmentId,
            int userId

            )
        {
            var jobCategory = db.Employees_Categories.Find(jobCategoryId);

            jobCategory.Name_A = jobCategoryAr;
            jobCategory.Name_E = jobCategoryEn;
            jobCategory.Description = description;
            //jobCategory.DepartmentId = departmentId;
            jobCategory.User_ID = userId;
            jobCategory.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        //to delete job category
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteJobCategory(int jobCategoryId)
        {
            var jobCategory = db.Employees_Categories.Where(s => s.Category_ID == jobCategoryId).FirstOrDefault();
            db.Employees_Categories.Remove(jobCategory);

            var result = db.SaveChanges() > 0 ? true : false;

            return new
            {
                result = result
            };
        }


    }
}
