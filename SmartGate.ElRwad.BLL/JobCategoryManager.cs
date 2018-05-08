using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL
{
   public class JobCategoryManager
    {
        private static JobCategoryManager instance;
        public static JobCategoryManager Instance { get { return instance; } }
        static JobCategoryManager()
        {
            instance = new JobCategoryManager();
        }
        private elRwadEntities db = new elRwadEntities();

        //Get all job Categories
        public dynamic GetJobCategories()
        {
            List<jobCategoryVM> jobCategories = db.Employees_Categories.Select(s => new jobCategoryVM
            {
                Category_ID = s.Category_ID,
                Name_A = s.Name_A,
                Name_E = s.Name_E,
                Description = s.Description,
                // departmentId = s.DepartmentId,
                User_ID = s.User_ID,
                Last_Update = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return jobCategories;
        }

        /// <summary>
        /// Get job Category by Id
        /// </summary>
        /// <param name="jobCategoryId"></param>
        /// <returns></returns>
        public dynamic GetJobCategoryById(int jobCategoryId)
        {
            try
            {
                var s = db.Employees_Categories.Where(e => e.Category_ID == jobCategoryId).FirstOrDefault();
                if (s != null)
                {
                    return new jobCategoryVM
                    {
                        Category_ID = s.Category_ID,
                        Name_A = s.Name_A,
                        Name_E = s.Name_E,
                        Description = s.Description,
                        //departmentId = s.DepartmentId,

                        User_ID = s.User_ID,
                        Last_Update = s.Last_Update.Value.ToString("yyyy-MM-dd")
                    };
                }
                else
                {
                    return new jobCategoryVM
                    {
                        Category_ID = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public dynamic PostJobCategory(jobCategoryVM j)
        {
            var jobCategory = db.Employees_Categories.Add(new Employees_Categories
            {
                Name_A = j.Name_A,
                Name_E = j.Name_E,
                Description = j.Description,
                //DepartmentId = departmentId,
                User_ID = j.User_ID,
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
        public dynamic PutJobCategory(jobCategoryVM j)
        {
            var jobCategory = db.Employees_Categories.Find(j.Category_ID);

            jobCategory.Name_A = j.Name_A;
            jobCategory.Name_E = j.Name_E;
            jobCategory.Description = j.Description;
            jobCategory.User_ID = j.User_ID;
            jobCategory.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        //to delete job category
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
