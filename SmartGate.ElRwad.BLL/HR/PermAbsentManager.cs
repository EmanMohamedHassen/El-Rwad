using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.HR;

namespace SmartGate.ElRwad.BLL.HR
{
   public class PermAbsentManager
    {
        private static PermAbsentManager instance;
        public static PermAbsentManager Instance { get { return instance; } }
        static PermAbsentManager()
        {
            instance = new PermAbsentManager();
        }
        private elRwadEntities db = new elRwadEntities();
            enum OrderStatus { Order, AcceptedByManager, RefusedByManager, AcceptedByHr, RefusedByHr };
            public dynamic GetAllPermAbs()
            {
                List<PermAbsentVM> permAbs = db.Perm_Absent.Select(s => new PermAbsentVM
                {
                    permAbsId = s.PermAbsent_ID,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    fromDate = s.PermAbsent_FromDate.Value.Year.ToString() + "-" + s.PermAbsent_FromDate.Value.Month.ToString() + "-" + s.PermAbsent_FromDate.Value.Day.ToString(),
                    toDate = s.PermAbsent_ToDate.Value.Year.ToString() + "-" + s.PermAbsent_ToDate.Value.Month.ToString() + "-" + s.PermAbsent_ToDate.Value.Day.ToString(),
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    monthId = s.Month,
                    yearId = s.Year,
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    approvEmp = s.Approv_Emp,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    permAbsCauses = s.Abs_Causes,
                    count = s.count
                }).ToList();
                return permAbs;
            }
            public dynamic GetAllPermAbs(byte monthID, int yearID)
            {
                List<PermAbsentVM> permAbs = db.Perm_Absent.Where(s => s.Month == monthID && s.Year == yearID).Select(s => new PermAbsentVM
                {
                    permAbsId = s.PermAbsent_ID,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    fromDate = s.PermAbsent_FromDate.Value.Year.ToString() + "-" + s.PermAbsent_FromDate.Value.Month.ToString() + "-" + s.PermAbsent_FromDate.Value.Day.ToString(),
                    toDate = s.PermAbsent_ToDate.Value.Year.ToString() + "-" + s.PermAbsent_ToDate.Value.Month.ToString() + "-" + s.PermAbsent_ToDate.Value.Day.ToString(),
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    monthId = s.Month,
                    yearId = s.Year,
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    approvEmp = s.Approv_Emp,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    permAbsCauses = s.Abs_Causes,
                    count = s.count
                }).ToList();
                return permAbs;
            }
            public dynamic GetPermAbsById(int permAbsId)
            {
                try
                {
                    Perm_Absent s = db.Perm_Absent.Where(e => e.PermAbsent_ID == permAbsId).FirstOrDefault();
                    if (s != null)
                    {
                        return new PermAbsentVM
                        {
                            permAbsId = s.PermAbsent_ID,
                            orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                            orderStatusId = s.OrderStatu.Id,
                            orderStatusName = s.OrderStatu.StatusAr,
                            fromDate = s.PermAbsent_FromDate.Value.Year.ToString() + "-" + s.PermAbsent_FromDate.Value.Month.ToString() + "-" + s.PermAbsent_FromDate.Value.Day.ToString(),
                            toDate = s.PermAbsent_ToDate.Value.Year.ToString() + "-" + s.PermAbsent_ToDate.Value.Month.ToString() + "-" + s.PermAbsent_ToDate.Value.Day.ToString(),
                            empId = s.Emp_ID,
                            empName = s.Employee.FullName,
                            monthId = s.Month,
                            yearId = s.Year,
                            approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                            approvEmp = s.Approv_Emp,
                            userId = s.User_ID,
                            lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                            permAbsCauses = s.Abs_Causes,
                            count = s.count

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
            public dynamic GetPermAbsByDate(DateTime fromDate, DateTime toDate, int orderStatusId)
            {
                try
                {
                    List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => (e.PermAbsent_FromDate >= fromDate.Date && e.PermAbsent_FromDate <= toDate.Date)
                      || ((e.PermAbsent_ToDate >= fromDate.Date && e.PermAbsent_ToDate <= toDate.Date) && e.OrderStatusId != (int)OrderStatus.Order)).ToList();
                    if (orderStatusId != (int)OrderStatus.AcceptedByManager)
                    {
                        return new { result = getReturnPermAbs(listPermAbs, orderStatusId) };

                    }
                    List<Perm_Absent> listPermAbsForAcceptedByManager = listPermAbs.Where(e => e.OrderStatusId != (int)OrderStatus.RefusedByManager).ToList();

                    var result = getPermAbs(listPermAbsForAcceptedByManager);

                    return result;
                }

                catch (Exception ex)
                {
                return ex.Message;
                }
            }
            public dynamic getPermAbs(List<Perm_Absent> listPermAbs)
            {
                List<PermAbsentVM> returPermAbs = listPermAbs.Select(s => new PermAbsentVM
                {
                    permAbsId = s.PermAbsent_ID,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    fromDate = s.PermAbsent_FromDate.Value.Year.ToString() + "-" + s.PermAbsent_FromDate.Value.Month.ToString() + "-" + s.PermAbsent_FromDate.Value.Day.ToString(),
                    toDate = s.PermAbsent_ToDate.Value.Year.ToString() + "-" + s.PermAbsent_ToDate.Value.Month.ToString() + "-" + s.PermAbsent_ToDate.Value.Day.ToString(),
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    monthId = s.Month,
                    yearId = s.Year,
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    approvEmp = s.Approv_Emp,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    permAbsCauses = s.Abs_Causes,
                    count = s.count

                }).ToList();
                return returPermAbs;
            }
            public dynamic GetPermAbsByDateAndDept(DateTime fromDate, DateTime toDate, int departmentId, int orderStatusId)
            {
                try
                {
                    List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => (e.PermAbsent_FromDate >= fromDate.Date && e.PermAbsent_FromDate <= toDate.Date)
                                    || ((e.PermAbsent_ToDate >= fromDate.Date && e.PermAbsent_ToDate <= toDate.Date) && e.OrderStatusId != (int)OrderStatus.Order && e.Employee.Job.Department_ID == departmentId)).ToList();
                    if (orderStatusId != (int)OrderStatus.AcceptedByManager)
                    {
                        return new { result = getReturnPermAbs(listPermAbs, orderStatusId) };

                    }
                    List<Perm_Absent> listPermAbsForAcceptedByManager = listPermAbs.Where(e => e.OrderStatusId != (int)OrderStatus.RefusedByManager).ToList();

                    var result = getPermAbs(listPermAbsForAcceptedByManager);

                    return result;
                }

                catch (Exception ex)
                {
                return ex.Message;
                }
            }
            public dynamic GetPermAbsByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => (e.PermAbsent_FromDate >= fromDate.Date && e.PermAbsent_FromDate <= toDate.Date)
                                    || ((e.PermAbsent_ToDate >= fromDate.Date && e.PermAbsent_ToDate <= toDate.Date) && e.OrderStatusId != (int)OrderStatus.Order && e.Emp_ID == empId)).ToList();

                    var result = getReturnPermAbs(listPermAbs, (int)OrderStatus.AcceptedByHr);
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
            public dynamic GetPermAbsEmpId(int empId, byte monthID, int yearID)
            {
                List<PermAbsentVM> permAbs = db.Perm_Absent.Where(s => s.Emp_ID == empId && s.Month == monthID && s.Year == yearID).Select(s => new PermAbsentVM
                {
                    permAbsId = s.PermAbsent_ID,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    fromDate = s.PermAbsent_FromDate.Value.Year.ToString() + "-" + s.PermAbsent_FromDate.Value.Month.ToString() + "-" + s.PermAbsent_FromDate.Value.Day.ToString(),
                    toDate = s.PermAbsent_ToDate.Value.Year.ToString() + "-" + s.PermAbsent_ToDate.Value.Month.ToString() + "-" + s.PermAbsent_ToDate.Value.Day.ToString(),
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    monthId = s.Month,
                    yearId = s.Year,
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    approvEmp = s.Approv_Emp,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    permAbsCauses = s.Abs_Causes,
                    count = s.count
                }).ToList();
                return permAbs;
            }
        
            private object getReturnPermAbs(List<Perm_Absent> listPermAbs, int orderStatusId)
            {
                List<Perm_Absent> listPermAbsWithStatus = listPermAbs.Where(e => e.OrderStatusId == orderStatusId).ToList();
                List<PermAbsentVM> returnPermAbs = listPermAbsWithStatus.Select(s => new PermAbsentVM
                {
                    permAbsId = s.PermAbsent_ID,
                    orderDate = s.OrderDate.Value.Year.ToString() + "-" + s.OrderDate.Value.Month.ToString() + "-" + s.OrderDate.Value.Day.ToString(),
                    orderStatusId = s.OrderStatu.Id,
                    orderStatusName = s.OrderStatu.StatusAr,
                    fromDate = s.PermAbsent_FromDate.Value.Year.ToString() + "-" + s.PermAbsent_FromDate.Value.Month.ToString() + "-" + s.PermAbsent_FromDate.Value.Day.ToString(),
                    toDate = s.PermAbsent_ToDate.Value.Year.ToString() + "-" + s.PermAbsent_ToDate.Value.Month.ToString() + "-" + s.PermAbsent_ToDate.Value.Day.ToString(),
                    empId = s.Emp_ID,
                    empName = s.Employee.FullName,
                    monthId = s.Month,
                    yearId = s.Year,
                    approvDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                    approvEmp = s.Approv_Emp,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    permAbsCauses = s.Abs_Causes,
                    count = s.count
                }).ToList();
                return returnPermAbs;
            }

            public dynamic GetPermAbsForManager(PermAbsentForManagerVM p)
            {
                try
                {
                    List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => e.Employee.Job.Department.Manager_ID == p.managerId && e.Year == p.year && e.Month == p.month).ToList();

                    if (listPermAbs != null)
                    {
                        var result = getReturnPermAbs(listPermAbs, (int)OrderStatus.Order);
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

            public dynamic GetPermAbsForHr(PermAbsentForHrVM p)
            {
                try
                {
                    List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => e.Year == p.year && e.Month == p.month).ToList();

                    if (listPermAbs != null)
                    {
                        var result = getReturnPermAbs(listPermAbs, (int)OrderStatus.AcceptedByManager);
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

            public dynamic PostPermAbsent(PermAbsentPVM p)
            {
                var permAbsOrder = db.Perm_Absent.Add(new Perm_Absent
                {
                    OrderDate = p.OrderDate,
                    PermAbsent_FromDate = p.fromDate,
                    PermAbsent_ToDate = p.toDate,
                    Emp_ID = p.empId,
                    Month = p.monthId,
                    Year = p.yearId,
                    User_ID = p.userId,
                    Last_Update = DateTime.Now,
                    Abs_Causes = p.permAbsCauses,
                    count = p.count,
                    OrderStatusId = Convert.ToInt32(OrderStatus.Order)



                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    permAbsOrder = permAbsOrder.PermAbsent_ID
                };
            }
            public dynamic PutPermAbs(PermAbsentPVM p)
            {


                var permAbs = db.Perm_Absent.Find(p.permAbsId);
                if (permAbs.OrderStatusId != (int)OrderStatus.Order)
                {
                    return new { result = " غير مسموح بتعديل فى اذن تم اخذ القرار فيه " };
                }

                permAbs.OrderDate = p.OrderDate;
                permAbs.PermAbsent_FromDate = p.fromDate;
                permAbs.PermAbsent_ToDate = p.toDate;
                permAbs.Emp_ID = p.empId;
                permAbs.Month = p.monthId;
                permAbs.Year = p.yearId;
                permAbs.User_ID = p.userId;
                permAbs.Last_Update = DateTime.Now;
                permAbs.Abs_Causes = p.permAbsCauses;
                permAbs.count = p.count;
                permAbs.OrderStatusId = Convert.ToInt32(OrderStatus.Order);

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic putPermAbsByManager (PermAbsByVM p)
            {
                var permAbs = db.Perm_Absent.Find(p.permAbsId);

                permAbs.Approv_Emp = p.userId;
                permAbs.Approv_Date = DateTime.Now;
                permAbs.OrderStatusId = p.OrderStatusId;
                permAbs.User_ID = p.userId;
                permAbs.Last_Update = DateTime.Now;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic putPermAbsByHr(PermAbsByVM p)
            {


                var permAbs = db.Perm_Absent.Find(p.permAbsId);
                if (p.OrderStatusId == (int)OrderStatus.AcceptedByHr)
                {
                    permAbs.Approv_Date = DateTime.Now;
                }
                permAbs.Approv_Date = DateTime.Now;
                permAbs.OrderStatusId = p.OrderStatusId;
                permAbs.User_ID = p.userId;
                permAbs.Last_Update = DateTime.Now;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic DeletePermAbs(int permAbsId)
            {
                var permAbs = db.Perm_Absent.Where(s => s.PermAbsent_ID == permAbsId).FirstOrDefault();
                if (permAbs.OrderStatusId == (int)OrderStatus.AcceptedByHr && permAbs.OrderDate < DateTime.Now)
                {
                    return new { result = " غير مسموح بتعديل فى اذن تم اخذ القرار فيه " };
                }
                db.Perm_Absent.Remove(permAbs);
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }




        }
    }

