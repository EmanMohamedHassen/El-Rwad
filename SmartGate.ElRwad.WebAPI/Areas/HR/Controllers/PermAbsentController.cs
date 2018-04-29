using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class PermAbsentController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        enum OrderStatus { Order, AcceptedByManager, RefusedByManager, AcceptedByHr, RefusedByHr };
        [HttpGet]
        public dynamic GetAllPermAbs()
        {
            var permAbs = db.Perm_Absent.Select(s => new
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
        [HttpGet]
        public dynamic GetAllPermAbs(byte monthID, int yearID)
        {
            var permAbs = db.Perm_Absent.Where(s => s.Month == monthID && s.Year == yearID).Select(s => new
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
        [HttpGet]
        public dynamic GetPermAbsById(int permAbsId)
        {
            try
            {
                Perm_Absent s = db.Perm_Absent.Where(e => e.PermAbsent_ID == permAbsId).FirstOrDefault();
                if (s != null)
                {
                    return new
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
                        //permAbsId = permAbs.PermAbsent_ID,
                        //orderDate = permAbs.OrderDate.Value.ToString("yyyy-MM-dd"),
                        //orderStatusId = permAbs.OrderStatu.Id,
                        //orderStatusName = permAbs.OrderStatu.StatusAr,
                        //fromDate = permAbs.PermAbsent_FromDate.Value.ToString("yyyy-MM-dd"),
                        //toDate = permAbs.PermAbsent_ToDate.Value.ToString("yyyy-MM-dd"),
                        //empId = permAbs.Emp_ID,
                        //empName = permAbs.Employee.FullName,
                        //monthId = permAbs.Month,
                        //yearId = permAbs.Year,
                        //approvDate = permAbs.Approv_Date.Value.ToString("yyyy-MM-dd"),
                        //approvEmp = permAbs.Approv_Emp,
                        //userId = permAbs.User_ID,
                        //lastUpdate = permAbs.Last_Update.Value.ToString("yyyy-MM-dd"),
                        //permAbsCauses = permAbs.Abs_Causes,
                        //count = permAbs.count

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
        public dynamic GetPermAbsByDate(DateTime fromDate, DateTime toDate, int orderStatusId)
        {
            try
            {
                List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => ((e.PermAbsent_FromDate >= fromDate.Date && e.PermAbsent_FromDate <= toDate.Date)
                  || (e.PermAbsent_ToDate >= fromDate.Date && e.PermAbsent_ToDate <= toDate.Date)) && e.OrderStatusId != (int)OrderStatus.Order).ToList();
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
        public dynamic getPermAbs(List<Perm_Absent> listPermAbs)
        {
            var returPermAbs = listPermAbs.Select(s => new
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
        //public dynamic GetPermAbsByYear(int year,bool isApprov)
        //{
        //    try
        //    {
        //        List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => e.Approv == isApprov &&e.Year==year).ToList();

        //        var result = getReturnVacation(listPermAbs);
        //        if (result == null)
        //        {
        //            return new
        //            {
        //                Id = 0
        //            };
        //        }

        //        return result;
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

        [HttpGet]
        public dynamic GetPermAbsByDateAndDept(DateTime fromDate, DateTime toDate, int departmentId, int orderStatusId)
        {
            try
            {
                List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => ((e.PermAbsent_FromDate >= fromDate.Date && e.PermAbsent_FromDate <= toDate.Date)
                                || (e.PermAbsent_ToDate >= fromDate.Date && e.PermAbsent_ToDate <= toDate.Date)) && e.OrderStatusId != (int)OrderStatus.Order && e.Employee.Job.Department_ID == departmentId).ToList();
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

        public dynamic GetPermAbsByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => ((e.PermAbsent_FromDate >= fromDate.Date && e.PermAbsent_FromDate <= toDate.Date)
                                || (e.PermAbsent_ToDate >= fromDate.Date && e.PermAbsent_ToDate <= toDate.Date)) && e.OrderStatusId != (int)OrderStatus.Order && e.Emp_ID == empId).ToList();

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

        public dynamic GetPermAbsEmpId(int empId, byte monthID, int yearID)
        {
            var permAbs = db.Perm_Absent.Where(s => s.Emp_ID == empId && s.Month == monthID && s.Year == yearID).Select(s => new
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


        //public dynamic GetPermAbsForEmpByYear(int empId, int year)
        //{ try
        //    {
        //        List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => e.Emp_ID == empId && e.Approv == true && e.Year==year).ToList();

        //        var result = getReturnVacation(listPermAbs);
        //        if (result == null)
        //        {
        //            return new
        //            {
        //                Id = 0
        //            };
        //        }

        //        return result;
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
        // [HttpGet]

        //public dynamic GetPermAbsForEmpByMonth(int empId,int month)
        //{ try
        //    {
        //        List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => e.Emp_ID == empId && e.Approv == true && e.Month==month).ToList();

        //        var result = getReturnVacation(listPermAbs);
        //        if (result == null)
        //        {
        //            return new
        //            {
        //                Id = 0
        //            };
        //        }

        //        return result;
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


        private object getReturnPermAbs(List<Perm_Absent> listPermAbs, int orderStatusId)
        {
            List<Perm_Absent> listPermAbsWithStatus = listPermAbs.Where(e => e.OrderStatusId == orderStatusId).ToList();
            var returnPermAbs = listPermAbsWithStatus.Select(s => new
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



        [HttpGet]

        public dynamic GetPermAbsForManager(int managerId, int month, int year)
        {
            try
            {
                List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => e.Employee.Job.Department.Manager_ID == managerId && e.Year == year && e.Month == month).ToList();

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

        public dynamic GetPermAbsForHr(int month, int year)
        {
            try
            {
                List<Perm_Absent> listPermAbs = db.Perm_Absent.Where(e => e.Year == year && e.Month == month).ToList();

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
        public dynamic PostPermAbsent(DateTime OrderDate, DateTime fromDate, DateTime toDate, int empId, byte monthId, int yearId
            , int userId, string permAbsCauses, byte count)
        {
            var permAbsOrder = db.Perm_Absent.Add(new Perm_Absent
            {
                OrderDate = OrderDate,
                PermAbsent_FromDate = fromDate,
                PermAbsent_ToDate = toDate,
                Emp_ID = empId,
                Month = monthId,
                Year = yearId,
                User_ID = userId,
                Last_Update = DateTime.Now,
                Abs_Causes = permAbsCauses,
                count = count,
                OrderStatusId = Convert.ToInt32(OrderStatus.Order)



            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                permAbsOrder = permAbsOrder.PermAbsent_ID
            };
        }


        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPermAbs(int permAbsId, DateTime OrderDate, DateTime fromDate, DateTime toDate, int empId, byte monthId, int yearId
            , int userId, string permAbsCauses, byte count)
        {


            var permAbs = db.Perm_Absent.Find(permAbsId);
            if (permAbs.OrderStatusId != (int)OrderStatus.Order)
            {
                return new { result = " غير مسموح بتعديل فى اذن تم اخذ القرار فيه " };
            }

            permAbs.OrderDate = OrderDate;
            permAbs.PermAbsent_FromDate = fromDate;
            permAbs.PermAbsent_ToDate = toDate;
            permAbs.Emp_ID = empId;
            permAbs.Month = monthId;
            permAbs.Year = yearId;
            permAbs.User_ID = userId;
            permAbs.Last_Update = DateTime.Now;
            permAbs.Abs_Causes = permAbsCauses;
            permAbs.count = count;
            permAbs.OrderStatusId = Convert.ToInt32(OrderStatus.Order);

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic putPermAbsByManager
            (
            int permAbsId,
            int OrderStatusId,
            int userId
            )
        {
            var permAbs = db.Perm_Absent.Find(permAbsId);

            permAbs.Approv_Emp = userId;
            permAbs.Approv_Date = DateTime.Now;
            permAbs.OrderStatusId = OrderStatusId;
            permAbs.User_ID = userId;
            permAbs.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic putPermAbsByHr(int permAbsId, int OrderStatusId,
            int userId)
        {


            var permAbs = db.Perm_Absent.Find(permAbsId);
            if (OrderStatusId == (int)OrderStatus.AcceptedByHr)
            {
                permAbs.Approv_Date = DateTime.Now;
            }
            permAbs.Approv_Date = DateTime.Now;
            permAbs.OrderStatusId = OrderStatusId;
            permAbs.User_ID = userId;
            permAbs.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
