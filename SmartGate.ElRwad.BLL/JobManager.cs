using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;
namespace SmartGate.ElRwad.BLL
{
  public  class JobManager
    {
        private static JobManager instance;
        public static JobManager Instance { get { return instance; } }
        static JobManager()
        {
            instance = new JobManager();
        }
        private elRwadEntities db = new elRwadEntities();
        
        public dynamic GetJobs()
        {
          List<JobVM> job = db.Jobs.Select(s => new JobVM
            {
                Id= s.Job_ID,
                TitleAr= s.Job_A_Title,
                TitleEn = s.Job_E_Title,
                DepartmentId= s.Department_ID,
                DepartmentNameAr= s.Department.Department_A_Name,
                DepartmentNameEn = s.Department.Department_E_Name,
                UserId = s.User_ID,
                LastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return job;
        }


        public dynamic GetJobById(int jobId)
        {
            try
            {
                var s = db.Jobs.Where(e => e.Job_ID == jobId).FirstOrDefault();
                if (s != null)
                {
                    return new JobVM
                    {
                        //jobId=s.Job_ID,

                        TitleAr= s.Job_A_Title,
                        TitleEn= s.Job_E_Title,

                        DepartmentId= s.Department_ID,
                        DepartmentNameAr= s.Department.Department_A_Name,
                        DepartmentNameEn = s.Department.Department_E_Name,

                        UserId= s.User_ID,
                        LastUpdate= s.Last_Update.Value.ToString("yyyy-MM-dd")
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
        public dynamic GetJobByDepartmentId(int departmentId)
        {
            try
            {
                var job = db.Jobs.Where(e => e.Department_ID == departmentId).Select(s => new JobVM
                {
                    Id = s.Job_ID,

                    TitleAr= s.Job_A_Title,
                    TitleEn= s.Job_E_Title,

                    DepartmentId= s.Department_ID,
                    DepartmentNameAr= s.Department.Department_A_Name,
                    DepartmentNameEn = s.Department.Department_E_Name,

                    UserId= s.User_ID,
                    LastUpdate= s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return job;
            }

            catch (Exception ex)
            {
                return new
                {
                    Message = ex.Message
                };
            }
        }
        public dynamic PostJob(JobVM j)
        {
            var job = db.Jobs.Add(new Job
            {

                Job_A_Title = j.TitleAr,
                Job_E_Title = j.TitleEn,
                Department_ID = j.DepartmentId,
                User_ID = j.UserId,
                Last_Update = DateTime.Now
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                jobId = job.Job_ID
            };
        }

        public dynamic PutJob(JobVM j)
        {
            var job = db.Jobs.Find(j.Id);

            job.Job_A_Title = j.TitleAr;
            job.Job_E_Title = j.TitleEn;
            job.Department_ID = j.DepartmentId;
            job.User_ID = j.UserId;
            job.Last_Update = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic DeleteJob(int jobId)
        {
            var job = db.Jobs.Where(s => s.Job_ID == jobId).FirstOrDefault();
            db.Jobs.Remove(job);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic jobExists(int jobId)
        {
            var job = db.Jobs.Count(s => s.Job_ID == jobId) > 0 ? true : false;
            return new
            {
                job = job
            };
        }
    }
}
