using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.HR;

namespace SmartGate.ElRwad.BLL.HR
{
   public class MissionManager
    {
            private static MissionManager instance;
            public static MissionManager Instance { get { return instance; } }
            static MissionManager()
            {
                instance = new MissionManager();
            }
            private elRwadEntities db = new elRwadEntities();
            public dynamic GetAllMissions()
            {
                List<MissionVM> mission = db.Missions.Select(s => new MissionVM
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

            public dynamic GetMissionsForHr(byte monthID, int yearID)
            {
                List<MissionVM> mission = db.Missions.Where(e => e.Month == monthID && e.Year == yearID && e.Approv == null).Select(s => new MissionVM
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
            public dynamic GetMissions(byte monthID, int yearID)
            {
                List<MissionVM> mission = db.Missions.Where(e => e.Month == monthID && e.Year == yearID && e.Approv == true).Select(s => new MissionVM
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

            public dynamic GetMissionById(int missionId)
            {
                try
                {
                    var s = db.Missions.Where(e => e.Mission_ID == missionId).FirstOrDefault();
                    if (s != null)
                    {
                        return new MissionEmpVM
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
                return ex.Message;
                }
            }

            public dynamic GetMissionByDate(DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<MissionEmpVM> mission = db.Missions.Where(e => e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new MissionEmpVM
                    {
                        missionId = s.Mission_ID,
                        empId = s.Emp_ID,
                        empName = s.Employee.FullName,
                        empCode = s.Employee.Employee_Code,
                        empJob = s.Employee.Job.Job_A_Title,
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
                return ex.Message;
                }
            }

            public dynamic GetMissionByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<MissionEmpVM> mission = db.Missions.Where(e => e.Emp_ID == empId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new MissionEmpVM

                    {

                        missionId = s.Mission_ID,
                        empId = s.Emp_ID,
                        empName = s.Employee.FullName,
                        empCode = s.Employee.Employee_Code,
                        empJob = s.Employee.Job.Job_A_Title,
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
                return ex.Message;
                }
            }

            public dynamic GetMissionByDateAndCategory(int categoryId, DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<MissionEmpVM> mission = db.Missions.Where(e => e.Employee.Category_ID == categoryId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new MissionEmpVM

                    {
                        missionId = s.Mission_ID,
                        empId = s.Emp_ID,
                        empName = s.Employee.FullName,
                        empCode = s.Employee.Employee_Code,
                        empJob = s.Employee.Job.Job_A_Title,
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
                return ex.Message;
                }
            }

            public dynamic GetMissionByDateAndDepartment(int departmentId, DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<MissionEmpVM> mission = db.Missions.Where(e => e.Employee.Job.Department_ID == departmentId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new MissionEmpVM

                    {
                        missionId = s.Mission_ID,
                        empId = s.Emp_ID,
                        empName = s.Employee.FullName,
                        empCode = s.Employee.Employee_Code,
                        empJob = s.Employee.Job.Job_A_Title,
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
                return ex.Message;
                }
            }

            public dynamic GetMissionByDateAndEmpIdAndDept(int empId, int departmentId, DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<MissionEmpVM> mission = db.Missions.Where(e => e.Emp_ID == empId && e.Employee.Job.Department_ID == departmentId && e.Mission_Date >= fromDate.Date && e.Mission_Date <= toDate.Date && e.Approv == true).Select(s => new MissionEmpVM

                    {

                        missionId = s.Mission_ID,
                        empId = s.Emp_ID,
                        empName = s.Employee.FullName,
                        empCode = s.Employee.Employee_Code,
                        empJob = s.Employee.Job.Job_A_Title,
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
                return ex.Message;
                }
            }
            public dynamic PostMission(MissionPVM m)
            {

                var mission = db.Missions.Add(new Mission
                {
                    Emp_ID = m.empId,
                    Month = m.month,
                    Year = m.year,
                    From_Hour = m.fromHour,
                    To_Hour = m.toHour,
                    From_Minute = m.fromMinute,
                    To_Minute = m.toMinute,
                    Mission_Causes = m.missionCauses,
                    Mission_Date = m.missionDate,
                    Approv = null,
                    User_ID = m.userId,
                    Update_Date = DateTime.Now,
                    ManagerID = m.managerId

                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    mission = mission.Mission_ID
                };
            }
            public dynamic PutMission(MissionPVM m)
            {
                var mission = db.Missions.Find(m.missionId);
                //check before update if this mission approv and it's time pass or not 
                if (mission.Approv == true && mission.Mission_Date < DateTime.Now)
                {
                    return new { result = " غير مسموح تعديل فى مأمورية تمت" };
                }

                mission.Emp_ID = m.empId;
                mission.Month = m.month;
                mission.Year = m.year;
                mission.From_Hour = m.fromHour;
                mission.To_Hour = m.toHour;
                mission.From_Minute = m.fromMinute;
                mission.To_Minute = m.toMinute;
                mission.Mission_Causes = m.missionCauses;
                mission.Mission_Date = m.missionDate;
                mission.Approv = null;
                mission.User_ID = m.userId;
                mission.Update_Date = DateTime.Now;
                mission.ManagerID = m.managerId;


                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic PutForApprov(MissionAVM m)
            {
                var Mission = db.Missions.Find(m.missionId);

                Mission.Approv = m.approv;
                Mission.Approv_Date = DateTime.Now;
                Mission.User_ID = m.userId;
                Mission.Update_Date = DateTime.Now;


                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
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
            public dynamic MissionExists(DateTime missionDate, int empId)
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
