using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class MissionController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetAllMissions()
        {
            var mission = db.Missions.Select(s => new
            {
                missionId = s.Mission_ID,
                empId = s.Employee.FullName,
                month = s.Month,
                year = s.Year,
                fromHour = s.From_Hour,
                toHour = s.To_Hour,
                fromMinute = s.From_Minute,
                toMinute = s.To_Minute,
                missionCauses = s.Mission_Causes,
                missionDate = s.Mission_Date.Value.Year.ToString() + "-" + s.Mission_Date.Value.Month.ToString() + "-" + s.Mission_Date.Value.Day.ToString(),
                approv = s.Approv.ToString(),
                approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                managerId = s.ManagerID,
                userId = s.User_ID,
                lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
            }).ToList();
            return mission;
        }

        [HttpGet]
        public dynamic GetMissionsForHr(byte monthID, int yearID)
        {
            var mission = db.Missions.Where(e => e.Month == monthID && e.Year == yearID && e.Approv == null).Select(s => new
            {
                missionId = s.Mission_ID,
                empId = s.Employee.FullName,
                month = s.Month,
                year = s.Year,
                fromHour = s.From_Hour,
                toHour = s.To_Hour,
                fromMinute = s.From_Minute,
                toMinute = s.To_Minute,
                missionCauses = s.Mission_Causes,
                missionDate = s.Mission_Date.Value.Year.ToString() + "-" + s.Mission_Date.Value.Month.ToString() + "-" + s.Mission_Date.Value.Day.ToString(),
                approv = s.Approv.ToString(),
                approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                managerId = s.ManagerID,
                userId = s.User_ID,
                lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
            }).ToList();
            return mission;
        }
        [HttpGet]
        public dynamic GetMissions(byte monthID, int yearID)
        {
            var mission = db.Missions.Where(e => e.Month == monthID && e.Year == yearID && e.Approv == true).Select(s => new
            {
                missionId = s.Mission_ID,
                empId = s.Emp_ID,
                empName = s.Employee.FullName,
                month = s.Month,
                year = s.Year,
                fromHour = s.From_Hour,
                toHour = s.To_Hour,
                fromMinute = s.From_Minute,
                toMinute = s.To_Minute,
                missionCauses = s.Mission_Causes,
                missionDate = s.Mission_Date.Value.Year.ToString() + "-" + s.Mission_Date.Value.Month.ToString() + "-" + s.Mission_Date.Value.Day.ToString(),
                approv = s.Approv.ToString(),
                approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                managerId = s.ManagerID,
                userId = s.User_ID,
                lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
            }).ToList();
            return mission;
        }
        [HttpGet]

        public dynamic GetMissionById(int missionId)
        {
            try
            {
                var s = db.Missions.Where(e => e.Mission_ID == missionId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        missionId = s.Mission_ID,
                        empId = s.Emp_ID,
                        empName = s.Employee.FullName,
                        month = s.Month,
                        year = s.Year,
                        fromHour = s.From_Hour,
                        toHour = s.To_Hour,
                        fromMinute = s.From_Minute,
                        toMinute = s.To_Minute,
                        missionCauses = s.Mission_Causes,
                        missionDate = s.Mission_Date.Value.ToString("yyyy-MM-dd"),
                        approv = s.Approv.ToString(),
                        approvDate = s.Approv_Date.Value.ToString("yyyy-MM-dd"),
                        managerId = s.ManagerID,
                        userId = s.User_ID,
                        lastUpdate = s.Update_Date.Value.ToString("yyyy-MM-dd")

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

        public dynamic GetMissionByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var mission = db.Missions.Where(e => e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new
                {
                    missionId = s.Mission_ID,
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    empCode = s.Employee.Employee_Code,
                    empJob = s.Employee.Job,
                    month = s.Month,
                    year = s.Year,
                    fromHour = s.From_Hour,
                    toHour = s.To_Hour,
                    fromMinute = s.From_Minute,
                    toMinute = s.To_Minute,
                    missionCauses = s.Mission_Causes,
                    missionDate = s.Mission_Date.Value.Year.ToString() + "-" + s.Mission_Date.Value.Month.ToString() + "-" + s.Mission_Date.Value.Day.ToString(),
                    approv = s.Approv.ToString(),
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    userId = s.User_ID,
                    lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
                }).ToList();
                return mission;

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

        public dynamic GetMissionByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var mission = db.Missions.Where(e => e.Emp_ID == empId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new

                {

                    missionId = s.Mission_ID,
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    empCode = s.Employee.Employee_Code,
                    empJob = s.Employee.Job,
                    month = s.Month,
                    year = s.Year,
                    fromHour = s.From_Hour,
                    toHour = s.To_Hour,
                    fromMinute = s.From_Minute,
                    toMinute = s.To_Minute,
                    missionCauses = s.Mission_Causes,
                    missionDate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString(),
                    approv = s.Approv.ToString(),
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    userId = s.User_ID,
                    lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
                }).ToList();
                return mission;

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

        public dynamic GetMissionByDateAndCategory(int categoryId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var mission = db.Missions.Where(e => e.Employee.Category_ID == categoryId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new

                {
                    missionId = s.Mission_ID,
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    empCode = s.Employee.Employee_Code,
                    empJob = s.Employee.Job,
                    month = s.Month,
                    year = s.Year,
                    fromHour = s.From_Hour,
                    toHour = s.To_Hour,
                    fromMinute = s.From_Minute,
                    toMinute = s.To_Minute,
                    missionCauses = s.Mission_Causes,
                    missionDate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString(),
                    approv = s.Approv.ToString(),
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    userId = s.User_ID,
                    lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
                }).ToList();
                return mission;

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

        public dynamic GetMissionByDateAndDepartment(int departmentId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var mission = db.Missions.Where(e => e.Employee.Job.Department_ID == departmentId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new

                {
                    missionId = s.Mission_ID,
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    empCode = s.Employee.Employee_Code,
                    empJob = s.Employee.Job,
                    month = s.Month,
                    year = s.Year,
                    fromHour = s.From_Hour,
                    toHour = s.To_Hour,
                    fromMinute = s.From_Minute,
                    toMinute = s.To_Minute,
                    missionCauses = s.Mission_Causes,
                    missionDate = s.Mission_Date.Value.ToString("yyyy-MM-dd"),
                    approv = s.Approv.ToString(),
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    userId = s.User_ID,
                    lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
                }).ToList();
                return mission;

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

        public dynamic GetMissionByDateAndEmpIdAndDept(int empId, int departmentId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var mission = db.Missions.Where(e => e.Emp_ID == empId && e.Employee.Job.Department_ID == departmentId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new

                {

                    missionId = s.Mission_ID,
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    empCode = s.Employee.Employee_Code,
                    empJob = s.Employee.Job,
                    month = s.Month,
                    year = s.Year,
                    fromHour = s.From_Hour,
                    toHour = s.To_Hour,
                    fromMinute = s.From_Minute,
                    toMinute = s.To_Minute,
                    missionCauses = s.Mission_Causes,
                    missionDate = s.Mission_Date.Value.Year.ToString() + "-" + s.Mission_Date.Value.Month.ToString() + "-" + s.Mission_Date.Value.Day.ToString(),
                    approv = s.Approv.ToString(),
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    userId = s.User_ID,
                    lastUpdate = s.Update_Date.Value.Year.ToString() + "-" + s.Update_Date.Value.Month.ToString() + "-" + s.Update_Date.Value.Day.ToString()
                }).ToList();
                return mission;

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


        public dynamic PostMission
            (
           int empId,
           byte month,
           int year,
           int fromHour,
           int toHour,
           int fromMinute,
           int toMinute,
           string missionCauses,
           DateTime missionDate,
           int userId,
           int managerId

            )
        {

            var mission = db.Missions.Add(new Mission
            {

                Emp_ID = empId,
                Month = month,
                Year = year,
                From_Hour = fromHour,
                To_Hour = toHour,
                From_Minute = fromMinute,
                To_Minute = toMinute,
                Mission_Causes = missionCauses,
                Mission_Date = missionDate,
                Approv = null,
                User_ID = userId,
                Update_Date = DateTime.Now,
                ManagerID = managerId

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                mission = mission.Mission_ID
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutMission(
           int missionId,
           int empId,
           byte month,
           int year,
           int fromHour,
           int toHour,
           int fromMinute,
           int toMinute,
           string missionCauses,
           DateTime missionDate,
           int userId,
           int managerId
            )
        {
            var mission = db.Missions.Find(missionId);
            //check before update if this mission approv and it's time pass or not 
            if (mission.Approv == true && mission.Mission_Date < DateTime.Now)
            {
                return new { result = " غير مسموح تعديل فى مأمورية تمت" };
            }

            mission.Emp_ID = empId;
            mission.Month = month;
            mission.Year = year;
            mission.From_Hour = fromHour;
            mission.To_Hour = toHour;
            mission.From_Minute = fromMinute;
            mission.To_Minute = toMinute;
            mission.Mission_Causes = missionCauses;
            mission.Mission_Date = missionDate;
            mission.Approv = null;
            mission.User_ID = userId;
            mission.Update_Date = DateTime.Now;
            mission.ManagerID = managerId;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutForApprov(
           int missionId,
           bool approv,
          int userId
           )
        {
            var Mission = db.Missions.Find(missionId);

            Mission.Approv = approv;
            Mission.Approv_Date = DateTime.Now;
            Mission.User_ID = userId;
            Mission.Update_Date = DateTime.Now;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteMission(int missionId)
        {
            var mission = db.Missions.Where(s => s.Mission_ID == missionId).FirstOrDefault();
            //check before delete if this mission approv and it's time pass or not 
            if (mission.Approv == true && mission.Mission_Date < DateTime.Now)
            {
                return new { result = " غير مسموح مسح فى مأم,رية تمت" };
            }
            db.Missions.Remove(mission);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpGet]
        private dynamic MissionExists(DateTime missionDate, int empId)
        {
            var mission = db.Missions.Count(e => e.Emp_ID == empId && e.Approv == true && e.Mission_Date == missionDate)
                > 0 ? true : false;
            return new
            {
                mission = mission
            };
        }



    }
}
