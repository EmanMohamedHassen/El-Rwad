using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.HR;

namespace SmartGate.ElRwad.BLL.HR
{
   public class PermissionManager
    {
        private static PermissionManager instance;
        public static PermissionManager Instance { get { return instance; } }
        static PermissionManager()
        {
            instance = new PermissionManager();
        }
            private elRwadEntities db = new elRwadEntities();

            enum OrderStatus { Order, AcceptedByManager, RefusedByManager, AcceptedByHr, RefusedByHr };
            public dynamic GetPermission()
            {
                List<PermissionVM> permission = db.HR_Leave_Order.Select(s => new PermissionVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    leaveTypeId = s.LeaveType_ID,
                    employeeId = s.Employee_ID,
                    empCode = s.Employee.Employee_Code,
                    leaveTypeName = s.PermissionType.PermissionType_Name,
                    employeeName = s.Employee.FullName,
                    leaveHours = s.Leave_Hours,
                    acceptedById = s.AccpetedBy_ID,
                    fromHour = s.From_Hour,
                    fromMinute = s.From_Minute,
                    toHour = s.To_Hour,
                    toMinute = s.To_Minute,
                    permissionCause = s.Permission_Causes,
                    dayOrNight = s.DayOrNight.ToString(),

                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    approveDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


                }).ToList();
                return permission;
            }
            public dynamic GetPermission(byte monthID, int yearID)
            {
                List<PermissionVM> permission = db.HR_Leave_Order.Where(s => s.Month == monthID && s.Year == yearID).Select(s => new PermissionVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    leaveTypeId = s.LeaveType_ID,
                    employeeId = s.Employee_ID,
                    empCode = s.Employee.Employee_Code,

                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    leaveTypeName = s.PermissionType.PermissionType_Name,
                    employeeName = s.Employee.FullName,
                    leaveHours = s.Leave_Hours,
                    acceptedById = s.AccpetedBy_ID,
                    fromHour = s.From_Hour,
                    fromMinute = s.From_Minute,
                    toHour = s.To_Hour,
                    toMinute = s.To_Minute,
                    permissionCause = s.Permission_Causes,
                    dayOrNight = s.DayOrNight.ToString(),
                    approveDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


                }).ToList();
                return permission;
            }

            public dynamic GetPermissionById(int orderId)
            {
                try
                {
                    var s = db.HR_Leave_Order.Where(e => e.Order_ID == orderId).FirstOrDefault();
                    if (s != null)
                    {
                        return new PermissionVM
                        {
                            orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                            leaveTypeId = s.LeaveType_ID,
                            employeeId = s.Employee_ID,
                            empCode = s.Employee.Employee_Code,

                            orderStatusId = s.OrderStatu.Id,
                            orderStatusName = s.OrderStatu.StatusAr,
                            leaveTypeName = s.PermissionType.PermissionType_Name,
                            employeeName = s.Employee.FullName,
                            leaveHours = s.Leave_Hours,
                            acceptedById = s.AccpetedBy_ID,
                            fromHour = s.From_Hour,
                            fromMinute = s.From_Minute,
                            toHour = s.To_Hour,
                            toMinute = s.To_Minute,
                            month = s.Month,
                            year = s.Year,
                            permissionCause = s.Permission_Causes,
                            dayOrNight = s.DayOrNight.ToString(),
                            approveDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                            userId = s.User_ID,
                            lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


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
            public dynamic GetPermissionByDate(DateTime fromDate, DateTime toDate, int orderStatusId)
            {
                try
                {
                    List<HR_Leave_Order> listPermission = db.HR_Leave_Order.Where(e => e.Order_Date >= fromDate.Date && e.Order_Date <= toDate.Date && e.OrderStatusId != (int)OrderStatus.Order).ToList();

                    if (orderStatusId != (int)OrderStatus.AcceptedByManager)
                    {

                        return new { result = getReturnPermissions(listPermission, orderStatusId) };
                    }

                    List<HR_Leave_Order> listPermForAcceptedByManager = listPermission.Where(e => e.OrderStatusId != (int)OrderStatus.RefusedByManager).ToList();

                    var result = getPerm(listPermForAcceptedByManager);


                    return new
                    {
                        result = result
                    };
                }

                catch (Exception ex)
                {
                return ex.Message;
                }
            }
            public dynamic getPerm(List<HR_Leave_Order> listPerm)
            {
                List<PermissionVM> returnPerm = listPerm.Select(s => new PermissionVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    leaveTypeId = s.LeaveType_ID,
                    employeeId = s.Employee_ID,
                    empCode = s.Employee.Employee_Code,
                    leaveTypeName = s.PermissionType.PermissionType_Name,
                    employeeName = s.Employee.FullName,
                    leaveHours = s.Leave_Hours,
                    acceptedById = s.AccpetedBy_ID,
                    fromHour = s.From_Hour,
                    fromMinute = s.From_Minute,
                    toHour = s.To_Hour,
                    toMinute = s.To_Minute,
                    permissionCause = s.Permission_Causes,
                    dayOrNight = s.DayOrNight.ToString(),
                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    approveDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return returnPerm;
            }
            public dynamic GetPermissionByDateAndDept(DateTime fromDate, DateTime toDate, int departmentId, int orderStatusId)
            {
                try
                {
                    List<HR_Leave_Order> listPermission = db.HR_Leave_Order
                        .Where(e => e.Order_Date >= fromDate.Date && e.Order_Date <= toDate.Date && e.OrderStatusId != (int)OrderStatus.Order && e.Employee.Job.Department_ID == departmentId).ToList();
                    if (orderStatusId != (int)OrderStatus.AcceptedByManager)
                    {

                        return new { result = getReturnPermissions(listPermission, orderStatusId) };
                    }

                    List<HR_Leave_Order> listPermForAcceptedByManager = listPermission.Where(e => e.OrderStatusId != (int)OrderStatus.RefusedByManager).ToList();

                    var result = getPerm(listPermForAcceptedByManager);


                    return new
                    {
                        result = result
                    };
                }

                catch (Exception ex)
                {
                return ex.Message;
                }
            }
            public dynamic GetPermissionByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<HR_Leave_Order> listPermission = db.HR_Leave_Order
                        .Where(e => e.Order_Date >= fromDate && e.Order_Date <= toDate && e.OrderStatusId != (int)OrderStatus.Order && e.Employee_ID == empId).ToList();
                    var result = getReturnPermissions(listPermission, (int)OrderStatus.AcceptedByHr);

                    if (result == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }

                    return result;
                }


                catch (Exception ex)
                {
                return ex.Message;
                }
            }
            public dynamic GetPermissionByEmpId(int empId, int year, byte monthID)
            {
                List<PermissionVM> permission = db.HR_Leave_Order.Where(s => s.Employee_ID == empId && s.Month == monthID && s.Year == year).Select(s => new PermissionVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    leaveTypeId = s.LeaveType_ID,
                    employeeId = s.Employee_ID,
                    empCode = s.Employee.Employee_Code,
                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    leaveTypeName = s.PermissionType.PermissionType_Name,
                    employeeName = s.Employee.FullName,
                    leaveHours = s.Leave_Hours,
                    acceptedById = s.AccpetedBy_ID,
                    fromHour = s.From_Hour,
                    fromMinute = s.From_Minute,
                    toHour = s.To_Hour,
                    toMinute = s.To_Minute,
                    permissionCause = s.Permission_Causes,
                    dayOrNight = s.DayOrNight.ToString(),
                    approveDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


                }).ToList();
                return permission;
            }

            private object getReturnPermissions(List<HR_Leave_Order> listPermissions, int orderStatusId)
            {
                List<HR_Leave_Order> listPermissionsWithStatus = listPermissions.Where(e => e.OrderStatusId == orderStatusId).ToList();
                List<returnVacationsDataVM> returnVacationsData = listPermissionsWithStatus.Select(s => new returnVacationsDataVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    leaveTypeId = s.LeaveType_ID,
                    employeeId = s.Employee_ID,
                    empCode = s.Employee.Employee_Code,
                    empJob = s.Employee.Job.Job_A_Title,
                    leaveTypeName = s.PermissionType.PermissionType_Name,
                    employeeName = s.Employee.FullName,
                    leaveHours = s.Leave_Hours,
                    acceptedById = s.AccpetedBy_ID,
                    fromHour = s.From_Hour,
                    fromMinute = s.From_Minute,
                    toHour = s.To_Hour,
                    toMinute = s.To_Minute,
                    month = s.Month,
                    year = s.Year,
                    permissionCause = s.Permission_Causes,
                    dayOrNight = s.DayOrNight.ToString(),
                    orderStatusId = s.OrderStatusId,
                    approveDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return returnVacationsData;
            }

            public dynamic GetPermForManager(int managerId, int year, int monthId)
            {
                try
                {

                    List<HR_Leave_Order> listPermission = db.HR_Leave_Order.Where(e => e.Employee.Job.Department.Manager_ID == managerId && e.Year == year && e.Month == monthId
                    ).ToList();
                    if (listPermission != null)
                    {
                        var result = getReturnPermissions(listPermission, (int)OrderStatus.Order);
                        return result;
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
            public dynamic GetPermForHr(int year, int monthId)
            {
                try
                {

                    List<HR_Leave_Order> listPermission = db.HR_Leave_Order.Where(e => e.Year == year && e.Month == monthId).ToList();
                    if (listPermission != null)
                    {
                        var result = getReturnPermissions(listPermission, (int)OrderStatus.AcceptedByManager);
                        return result;
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

            public dynamic PostPermission(PermissionPVM p)
            {
                //select this permission type 
                var permissionType = db.PermissionTypes.Where(m => m.PermissionType_ID == p.leaveTypeId).FirstOrDefault();
                //select the previous permission for this permission type taked by this employee in this year 
                var takedPermissions = db.HR_Leave_Order.
                    Where(b => b.LeaveType_ID == p.leaveTypeId && b.Employee_ID == p.empId && b.Year == p.year && b.OrderStatusId == (int)OrderStatus.AcceptedByHr).ToList();

                //order hours
                int hours = p.toHour - p.fromHour;
                //order minutes
                int minutes = p.toMinute - p.fromMinute;
                //total order time in hours
                float totalTime = hours + (minutes / 60);


                //check if this employee have hours to take in this permission type or not 
                if (totalTime + (takedPermissions.Sum(v => v.Leave_Hours)) > (permissionType.Hours_Count))
                {
                    return new { result = " تخطى عدد الساعات المسموح" };
                }


                //check if this employee finished the permitted hours in this month or not
                if (permissionType.Max_Times != 0)
                {
                    if (((takedPermissions.Where(m => m.Month == p.month).Sum(v => v.Leave_Hours)) + hours) > permissionType.Max_Times)
                        return new { result = "تخطى عدد الساعات المسموح بها للاذن " + permissionType.PermissionType_Name + " خلال الشهر" + p.month };
                }




                var hrLeaveOrder = db.HR_Leave_Order.Add(new HR_Leave_Order
                {

                    Order_Date = p.orderDate,
                    LeaveType_ID = p.leaveTypeId,
                    Employee_ID = p.empId,
                    Leave_Hours = totalTime,
                    //Is_Agreed=false,
                    //AccpetedBy_ID=acceptedById,
                    From_Hour = p.fromHour,
                    From_Minute = p.fromMinute,
                    To_Hour = p.toHour,
                    To_Minute = p.toMinute,
                    Month = p.month,
                    Year = p.year,
                    Permission_Causes = p.permissionCause,
                    DayOrNight = p.dayOrNight,
                    OrderStatusId = Convert.ToInt32(OrderStatus.Order),
                    //Approv_Date=approveDate,
                    //IS_Active=false,
                    User_ID = p.userId,
                    Last_Update = DateTime.Now





                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    hrLeaveOrderId = hrLeaveOrder.Order_ID
                };
            }

            public dynamic PutPermission(PermissionPVM p )
            {
                var Permission = db.HR_Leave_Order.Find(p.orderId);


                ////check before update if this order active and it's time pass 
                //if (Permission.IS_Active==true && Permission.Order_Date < DateTime.Now)
                //{
                //    return new { result = " غير مسموح بتعديل فى اذن تم" };
                //}

                //check if this permission taked action on it
                if (Permission.OrderStatusId != (int)OrderStatus.Order)
                {
                    return new { result = " غير مسموح بتعديل فى اذن تم اخذ القرار فيه " };
                }

                //select this permission type 
                var permissionType = db.PermissionTypes.Where(m => m.PermissionType_ID == p.leaveTypeId).FirstOrDefault();

                //select the previous permission for this permission type taked by this employee in this year 
                var takedPermissions = db.HR_Leave_Order.
                    Where(b => b.LeaveType_ID == p.leaveTypeId && b.Employee_ID == p.empId && b.Year == p.year && b.OrderStatusId == (int)OrderStatus.AcceptedByHr).ToList();


                //order hours
                int hours = p.toHour - p.fromHour;
                //order minutes
                int minutes = p.toMinute - p.fromMinute;
                //total order time in hours
                float totalTime = hours + (minutes / 60);



                //check if this employee have hours to take in this permission type or not 
                if (totalTime +
                    (takedPermissions.Sum(v => v.Leave_Hours))
                    - Permission.Leave_Hours
                    > (permissionType.Hours_Count))
                {
                    return new { result = " تخطى عدد الساعات المسموح" };
                }


                //check if this employee finished the permitted hours in this month or not
                if (permissionType.Max_Times != 0)
                {

                    var totalTakedHours = (takedPermissions.Where(m => m.Month == p.month).Sum(v => v.Leave_Hours)) + hours;

                    //if not change month
                    if (p.month == Permission.Month)
                    {
                        totalTakedHours = totalTakedHours - Permission.Leave_Hours;
                    }
                    //if  change month
                    else
                    {
                        totalTakedHours = totalTakedHours;
                    }

                    if (totalTakedHours > permissionType.Max_Times)
                        return new { result = "تخطى عدد الساعات المسموح بها للاذن " + permissionType.PermissionType_Name + " خلال الشهر" + p.month };
                }





                Permission.Order_Date = p.orderDate;
                Permission.LeaveType_ID = p.leaveTypeId;
                Permission.Employee_ID = p.empId;
                Permission.Leave_Hours = totalTime;
                Permission.From_Hour = p.fromHour;
                Permission.From_Minute = p.fromMinute;
                Permission.To_Hour = p.toHour;
                Permission.To_Minute = p.toMinute;
                Permission.Month = p.month;
                Permission.Year = p.year;
                Permission.OrderStatusId = Convert.ToInt32(OrderStatus.Order);
                Permission.Permission_Causes = p.permissionCause;
                Permission.DayOrNight = p.dayOrNight;
                Permission.User_ID = p.userId;
                Permission.Last_Update = DateTime.Now;







                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }

            //for manager to accept and refuse 
            public dynamic PutPermissionbymanager(putPermission p)
            {
                var Permission = db.HR_Leave_Order.Find(p.permissionId);

                Permission.AccpetedBy_ID = p.userId;
                Permission.OrderStatusId = p.OrderStatusId;
                Permission.User_ID = p.userId;
                Permission.Last_Update = DateTime.Now;
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            //for Hr to accept and refuse
            public dynamic PutPermissionbyHr(putPermission p)
            {
                var Permission = db.HR_Leave_Order.Find(p.permissionId);


                if (p.OrderStatusId == (int)OrderStatus.AcceptedByHr)
                {
                    Permission.Approv_Date = DateTime.Now;
                }

                Permission.OrderStatusId = p.OrderStatusId;
                Permission.User_ID = p.userId;
                Permission.Last_Update = DateTime.Now;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }

            public dynamic DeletePermission(int permissionId)
            {

                var permission = db.HR_Leave_Order.Where(s => s.Order_ID == permissionId).FirstOrDefault();
                //check before delete if this order active and it's time pass 
                if (permission.OrderStatusId == (int)OrderStatus.AcceptedByHr && permission.Order_Date < DateTime.Now)
                {
                    return new { result = " غير مسموح مسح اذن تم" };
                }
                db.HR_Leave_Order.Remove(permission);
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };

            }

            public dynamic PermissionExists(DateTime orderDate, int empId)
            {
                var permission = db.HR_Leave_Order
                    .Count(e => e.Employee_ID == empId && e.OrderStatusId == (int)OrderStatus.AcceptedByHr && e.Order_Date == orderDate.Date) > 0 ? true : false;
                return new
                {
                    permission = permission
                };
            }



        }
    }

