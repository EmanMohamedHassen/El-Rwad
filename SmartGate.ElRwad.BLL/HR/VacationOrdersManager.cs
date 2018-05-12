using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.HR;
namespace SmartGate.ElRwad.BLL.HR
{
   public class VacationOrdersManager
    {
        private static VacationOrdersManager instance;
        public static VacationOrdersManager Instance { get { return instance; } }
        static VacationOrdersManager()
        {
            instance = new VacationOrdersManager();
        }
        private elRwadEntities db = new elRwadEntities();

            enum OrderStatus { Order, AcceptedByManager, RefusedByManager, AcceptedByHr, RefusedByHr };

            public dynamic GetVacation()
            {

                List<VacationOrdersVM> vacation = db.Vacations_Orders.Select(s => new VacationOrdersVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    vacationTypeId = s.VacationType_ID,
                    vacationName = s.Vacations_Types.Type_Name,

                    employeeId = s.Employee_ID,
                    employeeName = s.Employee.FullName,
                    fromdate = s.From_Date.Value.Year.ToString() + "-" + s.From_Date.Value.Month.ToString() + "-" + s.From_Date.Value.Day.ToString(),
                    toDate = s.To_Date.Value.Year.ToString() + "-" + s.To_Date.Value.Month.ToString() + "-" + s.To_Date.Value.Day.ToString(),
                    responsibleEmpId = s.Responsible_Employee_ID,
                    orderStatusId = s.OrderStatusId,
                    orderstatusAr = s.OrderStatu.StatusAr,
                    orderstatusEn = s.OrderStatu.StatusEn,
                    acceptedDate = s.Acceptance_Date.Value.Year.ToString() + "-" + s.Acceptance_Date.Value.Month.ToString() + "-" + s.Acceptance_Date.Value.Day.ToString(),
                    acceptedById = s.AccpetedBy_ID,
                    monthId = s.Month_ID,
                    yearId = s.Year_ID,
                    vacationNotes = s.Vacation_Notes,
                    count = s.count,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return vacation;

            }
            public dynamic GetVacation(byte monthID, int yearID)
            {

                List<VacationOrdersVM> vacation = db.Vacations_Orders.Where(s => s.Month_ID == monthID && s.Year_ID == yearID).Select(s => new VacationOrdersVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    vacationTypeId = s.VacationType_ID,
                    vacationName = s.Vacations_Types.Type_Name,
                    employeeId = s.Employee_ID,
                    employeeName = s.Employee.FullName,
                    fromdate = s.From_Date.Value.Year.ToString() + "-" + s.From_Date.Value.Month.ToString() + "-" + s.From_Date.Value.Day.ToString(),
                    toDate = s.To_Date.Value.Year.ToString() + "-" + s.To_Date.Value.Month.ToString() + "-" + s.To_Date.Value.Day.ToString(),
                    responsibleEmpId = s.Responsible_Employee_ID,
                    orderStatusId = s.OrderStatusId,
                    orderstatusAr = s.OrderStatu.StatusAr,
                    orderstatusEn = s.OrderStatu.StatusEn,
                    acceptedDate = s.Acceptance_Date.Value.Year.ToString() + "-" + s.Acceptance_Date.Value.Month.ToString() + "-" + s.Acceptance_Date.Value.Day.ToString(),
                    acceptedById = s.AccpetedBy_ID,
                    monthId = s.Month_ID,
                    yearId = s.Year_ID,
                    vacationNotes = s.Vacation_Notes,
                    count = s.count,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return vacation;

            }
            public dynamic GetVacationById(int vacationId)
            {
                try
                {
                    var s = db.Vacations_Orders.Where(e => e.Order_ID == vacationId).FirstOrDefault();
                    if (s != null)
                    {
                        return new VacationOrdersVM
                        {
                            // orderId = s.Order_ID,
                            orderDate = s.Order_Date.Value.ToString("yyyy-MM-dd"),
                            vacationTypeId = s.VacationType_ID,
                            vacationName = s.Vacations_Types.Type_Name,

                            employeeId = s.Employee_ID,
                            fromdate = s.From_Date.Value.ToString("yyyy-MM-dd"),
                            toDate = s.To_Date.Value.ToString("yyyy-MM-dd"),
                            responsibleEmpId = s.Responsible_Employee_ID,
                            orderStatusId = s.OrderStatusId,
                            orderstatusAr = s.OrderStatu.StatusAr,
                            orderstatusEn = s.OrderStatu.StatusEn,

                            acceptedDate = s.Acceptance_Date.Value.ToString("yyyy-MM-dd"),
                            acceptedById = s.AccpetedBy_ID,
                            monthId = s.Month_ID,
                            yearId = s.Year_ID,
                            vacationNotes = s.Vacation_Notes,
                            count = s.count,
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
                return ex.Message;
                }
            }

            public dynamic GetVacationByDate(DateTime fromDate, DateTime toDate, int statusId)
            {
                try
                {
                    List<Vacations_Orders> listVacationOrder = db.Vacations_Orders.Where(e => e.OrderStatusId != (int)OrderStatus.Order && ((e.From_Date >= fromDate.Date && e.From_Date <= toDate.Date)
                    || (e.To_Date >= fromDate.Date && e.To_Date <= toDate.Date))).ToList();
                    if (statusId != (int)OrderStatus.AcceptedByManager)
                    {
                        return new { result = getReturnVacations(listVacationOrder, statusId) };

                    }
                    List<Vacations_Orders> listVacationOrderForAcceptedByManager = listVacationOrder.Where(e => e.OrderStatusId != (int)OrderStatus.RefusedByManager).ToList();
                    var result = getVacations(listVacationOrderForAcceptedByManager);
                    return result;
                }

                catch (Exception ex)
                {
                return ex.Message;
                    
                }
            }

            private dynamic getVacations(List<Vacations_Orders> listVacations)
            {
                List<VacationOrdersVM> returnVacationsData = listVacations.Select(s => new VacationOrdersVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    vacationTypeId = s.VacationType_ID,
                    vacationName = s.Vacations_Types.Type_Name,
                    employeeId = s.Employee_ID,
                    employeeCode = s.Employee.Employee_Code,
                    employeeJob = s.Employee.Job.Job_A_Title,
                    fromdate = s.From_Date.Value.Year.ToString() + "-" + s.From_Date.Value.Month.ToString() + "-" + s.From_Date.Value.Day.ToString(),
                    toDate = s.To_Date.Value.Year.ToString() + "-" + s.To_Date.Value.Month.ToString() + "-" + s.To_Date.Value.Day.ToString(),
                    acceptedDate = s.Acceptance_Date.Value.Year.ToString() + "-" + s.Acceptance_Date.Value.Month.ToString() + "-" + s.Acceptance_Date.Value.Day.ToString(),
                    acceptedById = s.AccpetedBy_ID,
                    monthId = s.Month_ID,
                    yearId = s.Year_ID,
                    vacationNotes = s.Vacation_Notes,
                    count = s.count,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


                }).ToList();
                return returnVacationsData;
            }

            public dynamic GetVacationsByDateAndDept(DateTime fromDate, DateTime toDate, int departmentId, int statusId)
            {
                try
                {
                    List<Vacations_Orders> listVacationOrder = db.Vacations_Orders.Where(e => e.OrderStatusId != (int)OrderStatus.Order && e.Employee.Job.Department_ID == departmentId
                    && ((e.From_Date >= fromDate.Date && e.From_Date <= toDate.Date)
                    || (e.To_Date >= fromDate.Date && e.To_Date <= toDate.Date))).ToList();
                    if (statusId != (int)OrderStatus.AcceptedByManager)
                    {
                        return new { result = getReturnVacations(listVacationOrder, statusId) };

                    }
                    List<Vacations_Orders> listVacationOrderForAcceptedByManager = listVacationOrder.Where(e => e.OrderStatusId != (int)OrderStatus.RefusedByManager).ToList();
                    var result = getVacations(listVacationOrderForAcceptedByManager);
                    return result;
                }

                catch (Exception ex)
                {
                return ex.Message;
                }
            }
            public dynamic GetVacationByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<Vacations_Orders> listVacationOrder = db.Vacations_Orders.Where( e => ( e.Employee_ID == empId && (e.From_Date >= fromDate.Date && e.From_Date <= toDate.Date) )
                     || (e.To_Date >= fromDate.Date && e.To_Date <= toDate.Date)).ToList();
                    var result = getReturnVacations(listVacationOrder, (int)OrderStatus.AcceptedByHr);

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

            public dynamic GetVacationByEmpId(int empId, int year, byte monthID)
            {
                List<VacationOrdersVM> vacation = db.Vacations_Orders.Where(s => s.Employee_ID == empId && s.Year_ID == year && s.Month_ID == monthID).Select(s => new VacationOrdersVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    vacationTypeId = s.VacationType_ID,
                    vacationName = s.Vacations_Types.Type_Name,
                    employeeId = s.Employee_ID,
                    employeeName = s.Employee.FullName,
                    fromdate = s.From_Date.Value.Year.ToString() + "-" + s.From_Date.Value.Month.ToString() + "-" + s.From_Date.Value.Day.ToString(),
                    toDate = s.To_Date.Value.Year.ToString() + "-" + s.To_Date.Value.Month.ToString() + "-" + s.To_Date.Value.Day.ToString(),
                    responsibleEmpId = s.Responsible_Employee_ID,
                    orderStatusId = s.OrderStatusId,
                    orderstatusAr = s.OrderStatu.StatusAr,
                    orderstatusEn = s.OrderStatu.StatusEn,
                    acceptedDate = s.Acceptance_Date.Value.Year.ToString() + "-" + s.Acceptance_Date.Value.Month.ToString() + "-" + s.Acceptance_Date.Value.Day.ToString(),
                    acceptedById = s.AccpetedBy_ID,
                    monthId = s.Month_ID,
                    yearId = s.Year_ID,
                    vacationNotes = s.Vacation_Notes,
                    count = s.count,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return vacation;

            }

            //public dynamic GetTest(int empId, DateTime fromDate, DateTime toDate)
            //{
            //    List<Vacations_Orders> listVacationOrder = db.Vacations_Orders.Where(e => e.Employee_ID == empId &&
            //       ((e.From_Date >= fromDate.Date && e.From_Date <= toDate.Date) || (e.To_Date >= fromDate.Date && e.To_Date <= toDate.Date))).ToList();

            //    List<Vacations_Orders> list_Results = new List<Vacations_Orders>();

            //    list_Results.AddRange(getReturnVacations(listVacationOrder, (int)OrderStatus.AcceptedByManager));
            //    list_Results.AddRange(getReturnVacations(listVacationOrder, (int)OrderStatus.AcceptedByHr));
            //    list_Results.AddRange(getReturnVacations(listVacationOrder, (int)OrderStatus.RefusedByHr));

            //    List<Vacations_Orders> distinct = list_Results.Distinct().ToList();

            //    return distinct;

            //}

            //لتقرير رصيد الاجازات  
            //By Eng.Eman
            public dynamic GetVacationForEmp(int empId, int year)
            {
                //all vacations which taked by this employee
                var takedVacationsWhichPrint = db.Vacations_Orders.
                               Where(e => e.Employee_ID == empId
                               && e.OrderStatusId == (int)OrderStatus.AcceptedByHr
                               && e.Year_ID == year
                               && e.Vacations_Types.Print_With_Reports == true
                               ).ToList();


                var employee = db.Employees.Where(e => e.Employee_ID == empId).FirstOrDefault();

                //all vacation types which print with report
                List<Vacations_Types> listVacTypes = db.Vacations_Types.Where(s => s.Print_With_Reports == true
                && (s.For_Emp_Type == false || (s.For_Emp_Type == true && s.Emp_Type == employee.Category_ID))).ToList();

                List<retriveVacation> result = new List<retriveVacation>();

                foreach (var typ in listVacTypes)
                {
                    int totalVacations = takedVacationsWhichPrint.Where(s => s.VacationType_ID == typ.VacationType_ID).Sum(s => s.count.Value);
                    result.Add(new retriveVacation
                    {
                        sum = totalVacations,
                        remainedDays = (typ.Max_Days.Value) - totalVacations,
                        vacationType = typ.Type_Name,
                        maxDays = typ.Max_Days.Value

                    });
                }

                return result;

            }


            //return vacations with status id 

            private dynamic getReturnVacations(List<Vacations_Orders> listVacations, int orderStatusId)
            {
                List<Vacations_Orders> listVacationsWithStatus = listVacations.Where(e => e.OrderStatusId == orderStatusId).ToList();
                List<VacationOrdersVM> returnVacationsData = listVacationsWithStatus.Select(s => new VacationOrdersVM
                {
                    orderId = s.Order_ID,
                    orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                    vacationTypeId = s.VacationType_ID,
                    vacationName = s.Vacations_Types.Type_Name,

                    employeeId = s.Employee_ID,
                    employeeName = s.Employee.FullName,
                    employeeCode = s.Employee.Employee_Code,
                    employeeJob = s.Employee.Job.Job_A_Title,
                    fromdate = s.From_Date.Value.Year.ToString() + "-" + s.From_Date.Value.Month.ToString() + "-" + s.From_Date.Value.Day.ToString(),
                    toDate = s.To_Date.Value.Year.ToString() + "-" + s.To_Date.Value.Month.ToString() + "-" + s.To_Date.Value.Day.ToString(),
                    acceptedDate = s.Acceptance_Date.Value.Year.ToString() + "-" + s.Acceptance_Date.Value.Month.ToString() + "-" + s.Acceptance_Date.Value.Day.ToString(),
                    acceptedById = s.AccpetedBy_ID,
                    monthId = s.Month_ID,
                    yearId = s.Year_ID,
                    vacationNotes = s.Vacation_Notes,
                    count = s.count,
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

                }).ToList();
                return returnVacationsData;
            }

            //To Get vacation orders for manager to take actions in it
            public dynamic GetForManager(int managerId, int year, byte monthID)
            {
                try
                {

                    List<Vacations_Orders> listVacationOrders = db.Vacations_Orders.Where(e => e.Employee.Job.Department.Manager_ID == managerId && e.Year_ID == year && e.Month_ID == monthID/*&& e.OrderStatusId==1*/).ToList();
                    if (listVacationOrders != null)
                    {
                        var result = getReturnVacations(listVacationOrders, (int)OrderStatus.Order);
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
            //To Get vacation orders which manager accepted for Hr to take actions in it

            public dynamic GetForHr(int year, byte monthID)
            {
                try
                {

                    List<Vacations_Orders> listVacationOrders = db.Vacations_Orders.Where(e => e.Year_ID == year && e.Month_ID == monthID).ToList();
                    if (listVacationOrders != null)
                    {
                        var result = getReturnVacations(listVacationOrders, (int)OrderStatus.AcceptedByManager);
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

            public dynamic PostVacation(VacationOrderPVM p)
            {

                //select this vacation type 
                var vacationType = db.Vacations_Types.Where(m => m.VacationType_ID == p.vacationTypeId).FirstOrDefault();

                //select the previous vacation for this vacation type for this employee in this year and count days
                var takedVacations = db.Vacations_Orders.
                    Where(b => b.VacationType_ID == p.vacationTypeId && b.Employee_ID == p.employeeId && b.Year_ID == p.yearId && b.OrderStatusId == (int)OrderStatus.AcceptedByHr).ToList();


                //select this employee
                var Emp = db.Employees.Where(f => f.Employee_ID == p.employeeId).FirstOrDefault();


                //تحديد عدد ايام الاجازة
                TimeSpan timeSpan = p.toDate.Date - p.fromDate.Date;
                int orderdays_Count = Convert.ToInt32(timeSpan.TotalDays);


                //check if this employee have vacation days to take it or not 
                if (orderdays_Count > (vacationType.Max_Days - (takedVacations.Sum(v => v.count))))
                {
                    return new { result = " تخطى عدد الايام المسموح" };
                }

                //check if this employee finished the permitted monthes from him assignment date to take this vacation
                if (vacationType.Reg_Max_Month > 0)
                {

                    //للتحديد عدد الشهورر بداية من تعيينه
                    TimeSpan timeSpan2 = p.fromDate.Date - Emp.Assigment_Date.Value;
                    int assignmentMonthes = Convert.ToInt32(timeSpan2.TotalDays) / 30;

                    if (assignmentMonthes < vacationType.Reg_Max_Month)
                    {
                        return new { result = "لم يتخطى المدة المطلوبة منذ تعينه لاخذ الاجازة" };

                    }

                }

                //check if this employee finished the permitted dayes in this month or not
                if (vacationType.Month_Max_Times != 0)
                {

                    if (((takedVacations.Where(m => m.Month_ID == p.monthId).Sum(v => v.count)) + orderdays_Count) > vacationType.Month_Max_Times)
                    {
                        return new { result = "تخطى عدد الايام المسموح بها للاجازة " + vacationType.Type_Name + " خلال الشهر!!" };
                    }
                }


                //check first if this type of vacations demand spicific period and then if demand then check if the order period in it or no
                if (vacationType.With_Period == true)
                {
                    if (p.fromDate.Date > vacationType.To_Date)
                    {
                        return new { result = "خارج الفترة الزمنية لهذا النوع من الاجازة" };
                    }
                }

                //if (vacationsType.For_Emp_Type == false || (vacationsType.For_Emp_Type == true && vacationsType.Emp_Type == g.Category_ID)) 
                //or from list of available vacation types


                var vacationOrder = db.Vacations_Orders.Add(new Vacations_Orders
                {
                    Order_Date = DateTime.Now,
                    VacationType_ID = p.vacationTypeId,
                    Employee_ID = p.employeeId,
                    From_Date = p.fromDate.Date,
                    To_Date = p.toDate.Date,
                    OrderStatusId = Convert.ToInt32(OrderStatus.Order),
                    Month_ID = p.monthId,
                    Year_ID = p.yearId,
                    Vacation_Notes = p.vacationNotes,
                    count = Convert.ToByte(orderdays_Count),
                    User_ID = p.userId,
                    Last_Update = DateTime.Now

                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    vacationOrderId = vacationOrder.Order_ID
                };

            }
            public dynamic PutVacation(VacationOrderPVM p)
            {
                var vacation = db.Vacations_Orders.Find(p.vacationId);
                //check before update if this order active and it's time pass 
                //if (vacation.OrderStatusId == 4 && vacation.From_Date < DateTime.Now)
                //{
                //    return new { result = " غير مسموح بتعديل فى اجازة تمت" };
                //}

                //check if this vacation taked action on it
                if (vacation.OrderStatusId != (int)OrderStatus.Order)
                {
                    return new { result = "  غير مسموح بتعديل فى اجازة تم اخذ القرار فيها " };
                }



                //select this vacation type 
                var vacationType = db.Vacations_Types.Where(m => m.VacationType_ID == p.vacationTypeId).FirstOrDefault();

                //select the previous vacation for this vacation type for this employee in this year and count days
                var takedVacations = db.Vacations_Orders.
                    Where(b => b.VacationType_ID == p.vacationTypeId && b.Employee_ID == p.employeeId && b.Year_ID == p.yearId && b.OrderStatusId == (int)OrderStatus.AcceptedByHr).ToList();


                //select this employee
                var Emp = db.Employees.Where(f => f.Employee_ID == p.employeeId).FirstOrDefault();


                //تحديد عدد ايام الاجازة
                TimeSpan timeSpan = p.toDate.Date - p.fromDate.Date;
                int orderdays_Count = Convert.ToInt32(timeSpan.TotalDays);


                //check if this employee have vacation days to take it or not 
                if (orderdays_Count > (vacationType.Max_Days - (takedVacations.Sum(v => v.count)) + vacation.count))
                {
                    return new { result = " تخطى عدد الايام المسموح" };
                }

                //check if this employee finished the permitted monthes from him assignment date to take this vacation
                if (vacationType.Reg_Max_Month > 0)
                {

                    //للتحديد عدد الشهورر بداية من تعيينه
                    TimeSpan timeSpan2 = p.fromDate.Date - Emp.Assigment_Date.Value.Date;
                    int assignmentMonthes = Convert.ToInt32(timeSpan2.TotalDays) / 30;

                    if (assignmentMonthes < vacationType.Reg_Max_Month)
                    {
                        return new { result = "لم يتخطى المدة المطلوبة منذ تعينه لاخذ الاجازة" };

                    }

                }

                //check if this employee finished the permitted dayes in this month or not
                if (vacationType.Month_Max_Times != 0)
                {

                    if (
                        (
                        (takedVacations.Where(m => m.Month_ID == p.monthId).Sum(v => v.count))
                        + orderdays_Count) > vacationType.Month_Max_Times)
                    {
                        return new { result = "تخطى عدد الايام المسموح بها للاجازة " + vacationType.Type_Name + " خلال الشهر!!" };
                    }
                }

                //check first if this type of vacations demand spicific period and then if demand then check if the order period in it or no
                if (vacationType.With_Period == true)
                {
                    if (p.fromDate.Date > vacationType.To_Date)
                    {
                        return new { result = "خارج الفترة الزمنية لهذا النوع من الاجازة" };
                    }
                }


                //vacation.Order_Date = DateTime.Now;
                vacation.VacationType_ID = p.vacationTypeId;
                vacation.Employee_ID = p.employeeId;
                vacation.From_Date = p.fromDate.Date;
                vacation.To_Date = p.toDate.Date;
                vacation.OrderStatusId = Convert.ToInt32(OrderStatus.Order);
                vacation.Month_ID = p.monthId;
                vacation.Year_ID = p.yearId;
                vacation.Vacation_Notes = p.vacationNotes;
                vacation.count = Convert.ToByte(orderdays_Count);
                vacation.User_ID = p.userId;
                vacation.Last_Update = DateTime.Now;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }

            //for manager to accept and refuse 
            public dynamic PutVacationbyManager(putVacationVM p)
            {
                var vacation = db.Vacations_Orders.Find(p.vacationId);
                if (vacation.From_Date < DateTime.Now)
                {
                    return new { result = " غير مسموح بأخذ قرار فى ميعاد سابق" };
                }
                vacation.OrderStatusId = p.orderStatusId;

                if (p.orderStatusId == (int)OrderStatus.AcceptedByManager)
                {
                    vacation.Acceptance_Date = DateTime.Now;
                    vacation.AccpetedBy_ID = p.userId;
                }

                vacation.User_ID = p.userId;
                vacation.Last_Update = DateTime.Now;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic PutVacationbyHr(putVacationVM p)
            {
                var vacation = db.Vacations_Orders.Find(p.vacationId);
                if (vacation.From_Date < DateTime.Now)
                {
                    return new { result = " غير مسموح بأخذ قرار فى ميعاد سابق" };
                }
                vacation.OrderStatusId = p.orderStatusId;
                vacation.Responsible_Employee_ID = p.userId;
                vacation.User_ID = p.userId;
                vacation.Last_Update = DateTime.Now;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic DeleteVacation(int vacationId)
            {
                var vacation = db.Vacations_Orders.Where(s => s.Order_ID == vacationId).FirstOrDefault();
                if (vacation.OrderStatusId == (int)OrderStatus.AcceptedByHr && vacation.From_Date < DateTime.Now)
                {
                    return new { result = " غير مسموح بمسح اجازة تمت" };
                }

                db.Vacations_Orders.Remove(vacation);

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };

            }
            public dynamic VacationExists(DateTime fromDate, DateTime toDate, int empId)
            {


                var vacation = db.Vacations_Orders

                    .Count(e => e.Employee_ID == empId && e.OrderStatusId == (int)OrderStatus.AcceptedByHr && ((e.From_Date >= fromDate.Date && e.From_Date <= toDate.Date) || (e.To_Date >= fromDate.Date && e.To_Date <= toDate.Date)))
                    > 0 ? true : false;
                return new
                {
                    vacation = vacation
                };
            }

        }

       
    }



