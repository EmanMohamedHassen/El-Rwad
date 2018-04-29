using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class JobsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetJobs()
        {
            var job = db.Jobs.Select(s => new
            {
                jobId = s.Job_ID,
                jobArTitle = s.Job_A_Title,
                jobEnTitle = s.Job_E_Title,
                departmentId = s.Department_ID,
                departmentArName = s.Department.Department_A_Name,
                departmentEnName = s.Department.Department_E_Name,
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return job;
        }

        [HttpGet]
        public dynamic GetJobById(int jobId)
        {
            try
            {
                var s = db.Jobs.Where(e => e.Job_ID == jobId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        //jobId=s.Job_ID,

                        jobArTitle = s.Job_A_Title,
                        jobEnTitle = s.Job_E_Title,

                        departmentId = s.Department_ID,
                        departmentArName = s.Department.Department_A_Name,
                        departmentEnName = s.Department.Department_E_Name,

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
        [HttpGet]
        public dynamic GetJobByDepartmentId(int departmentId)
        {
            try
            {
                var job = db.Jobs.Where(e => e.Department_ID == departmentId).Select(s => new
                {
                    jobId = s.Job_ID,

                    jobArTitle = s.Job_A_Title,
                    jobEnTitle = s.Job_E_Title,

                    departmentId = s.Department_ID,
                    departmentArName = s.Department.Department_A_Name,
                    departmentEnName = s.Department.Department_E_Name,

                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return job;
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
        public dynamic PostJob(

            string jobArTitle,
            string jobEnTitle,

            int departmentId,

            int userId
            )
        {
            var job = db.Jobs.Add(new Job
            {

                Job_A_Title = jobArTitle,
                Job_E_Title = jobEnTitle,


                Department_ID = departmentId,

                User_ID = userId,
                Last_Update = DateTime.Now
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                jobId = job.Job_ID
            };
        }
        [AcceptVerbs("GET", "POST")]
        [HttpPut]

        public dynamic PutJob(
            int jobId,

            string jobArTitle,
            string jobEnTitle,

            int departmentId,

            int userId
            )
        {
            var job = db.Jobs.Find(jobId);

            job.Job_A_Title = jobArTitle;
            job.Job_E_Title = jobEnTitle;

            job.Department_ID = departmentId;

            job.User_ID = userId;
            job.Last_Update = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
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
        [HttpGet]
        private dynamic jobExists(int jobId)
        {
            var job = db.Jobs.Count(s => s.Job_ID == jobId) > 0 ? true : false;
            return new
            {
                job = job
            };
        }

    }
}
