using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL.HR
{
   public class EmployeeManager
    {
        private static EmployeeManager instance;
        public static EmployeeManager Instance { get { return instance; } }
        static EmployeeManager()
        {
            instance = new EmployeeManager();
        }
        private elRwadEntities db = new elRwadEntities();
        public object GetEmployees()
            {
                List<EmployeeVM> employee = db.Employees.Select(s => new EmployeeVM
                {
                    empId = s.Employee_ID,
                    empPrintCode = s.Employee_Code,
                    fullName = s.FullName,
                    phone = s.Phone,
                    mobile = s.Mobile,
                    departmentId = s.Job.Department.Department_ID,
                    departmentAr = s.Job.Department.Department_A_Name,
                    departmentEn = s.Job.Department.Department_E_Name,
                    managerId = s.Job.Department.Employee.Employee_ID,
                    managerName = s.Job.Department.Employee.FullName,
                    ssn = s.SSN,
                    birthDate = s.BirthDate.Value.Year.ToString() + "-" + s.BirthDate.Value.Month.ToString() + "-" + s.BirthDate.Value.Day.ToString(),
                    cityId = s.City_ID,
                    cityName = s.City.Name_A,
                    jobId = s.Job_ID,
                    jobName = s.Job.Job_A_Title,
                    categoryId = s.Category_ID,
                    categoryName = s.Employees_Categories.Name_A,
                    address = s.Address,
                    email = s.Email,
                    imageId = s.ImageID,
                    branchId = s.Branch_ID,
                    branchName = s.Branch.Branch_A_Title,
                    sex = s.Sex.ToString(),
                    assignmentDate = s.Assigment_Date.Value.Year.ToString() + "-" + s.Assigment_Date.Value.Month.ToString() + "-" + s.Assigment_Date.Value.Day.ToString(),
                    leaveReason = s.LeaveReason,
                    insurance_Number = s.Insurance_Number,
                    isInsurance = s.Is_Insurance.ToString(),
                    basicSalary = s.Basic_Salary,
                    insuranceSalary = s.Insurance_Salary,
                    variableSalary = s.Variable_Salary,
                    isActive = s.IsActive.ToString(),
                    userId = s.User_ID,
                    lastUserId = s.Last_User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    leaveDate = s.leave_Date.Value.Year.ToString() + "-" + s.leave_Date.Value.Month.ToString() + "-" + s.leave_Date.Value.Day.ToString(),
                    insuranceDate = s.Insurance_Date.Value.Year.ToString() + "-" + s.Insurance_Date.Value.Month.ToString() + "-" + s.Insurance_Date.Value.Day.ToString(),
                    healthcheckDate = s.HealthCheck_Date.Value.Year.ToString() + "-" + s.HealthCheck_Date.Value.Month.ToString() + "-" + s.HealthCheck_Date.Value.Day.ToString(),
                    insuranceEndDate = s.Insurnace_EndDate.Value.Year.ToString() + "-" + s.Insurnace_EndDate.Value.Month.ToString() + "-" + s.Insurnace_EndDate.Value.Day.ToString(),
                    deputationId = s.Deputation_ID,
                    deputationName = s.Deputation.Title,
                    weekEndDay = s.WeekEndDay,
                    shiftId = s.Shift_Id,
                    yearlySPInsuranceBasic = s.YearlySPInsurance_Basic,
                    yearlySPInsuranceAdditional = s.YearlySPInsurance_Additional,
                    qualificationTypeId = s.QualificationType.Id,
                    qualificationType = s.QualificationType.Qualification,
                    qualify = s.Qualify,
                    universityId = s.University_ID,
                    facultyId = s.Faculty_ID,
                    specialityId = s.Specialty_ID,
                    gradYear = s.Grad_Year,
                    gradProj = s.Grad_Project,
                    totalGrad = s.Total_Grade,
                    notes = s.Notes

                }).ToList();
                return employee;
            }


            public dynamic GetEmployeesByIsActive(bool isActive)
            {
                List<EmployeeVM> employee = db.Employees.Where(e => e.IsActive == isActive).Select(s => new EmployeeVM
                {
                    empId = s.Employee_ID,
                    empPrintCode = s.Employee_Code,
                    fullName = s.FullName,
                    phone = s.Phone,
                    mobile = s.Mobile,
                    departmentId = s.Job.Department.Department_ID,
                    departmentAr = s.Job.Department.Department_A_Name,
                    departmentEn = s.Job.Department.Department_E_Name,
                    managerId = s.Job.Department.Employee.Employee_ID,
                    managerName = s.Job.Department.Employee.FullName,
                    ssn = s.SSN,
                    birthDate = s.BirthDate.Value.Year.ToString() + "-" + s.BirthDate.Value.Month.ToString() + "-" + s.BirthDate.Value.Day.ToString(),
                    cityId = s.City_ID,
                    cityName = s.City.Name_A,
                    jobId = s.Job_ID,
                    jobName = s.Job.Job_A_Title,
                    categoryId = s.Category_ID,
                    categoryName = s.Employees_Categories.Name_A,
                    address = s.Address,
                    email = s.Email,
                    imageId = s.ImageID,
                    branchId = s.Branch_ID,
                    branchName = s.Branch.Branch_A_Title,
                    sex = s.Sex.ToString(),
                    assignmentDate = s.Assigment_Date.Value.Year.ToString() + "-" + s.Assigment_Date.Value.Month.ToString() + "-" + s.Assigment_Date.Value.Day.ToString(),
                    leaveReason = s.LeaveReason,
                    insurance_Number = s.Insurance_Number,
                    isInsurance = s.Is_Insurance.ToString(),
                    basicSalary = s.Basic_Salary,
                    insuranceSalary = s.Insurance_Salary,
                    variableSalary = s.Variable_Salary,
                    isActive = s.IsActive.ToString(),
                    userId = s.User_ID,
                    lastUserId = s.Last_User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    leaveDate = s.leave_Date.Value.Year.ToString() + "-" + s.leave_Date.Value.Month.ToString() + "-" + s.leave_Date.Value.Day.ToString(),
                    insuranceDate = s.Insurance_Date.Value.Year.ToString() + "-" + s.Insurance_Date.Value.Month.ToString() + "-" + s.Insurance_Date.Value.Day.ToString(),
                    healthcheckDate = s.HealthCheck_Date.Value.Year.ToString() + "-" + s.HealthCheck_Date.Value.Month.ToString() + "-" + s.HealthCheck_Date.Value.Day.ToString(),
                    insuranceEndDate = s.Insurnace_EndDate.Value.Year.ToString() + "-" + s.Insurnace_EndDate.Value.Month.ToString() + "-" + s.Insurnace_EndDate.Value.Day.ToString(),
                    deputationId = s.Deputation_ID,
                    deputationName = s.Deputation.Title,
                    weekEndDay = s.WeekEndDay,
                    shiftId = s.Shift_Id,
                    yearlySPInsuranceBasic = s.YearlySPInsurance_Basic,
                    yearlySPInsuranceAdditional = s.YearlySPInsurance_Additional,
                    qualificationTypeId = s.QualificationType.Id,
                    qualificationType = s.QualificationType.Qualification,
                    qualify = s.Qualify,
                    universityId = s.University_ID,
                    facultyId = s.Faculty_ID,
                    specialityId = s.Specialty_ID,
                    gradYear = s.Grad_Year,
                    gradProj = s.Grad_Project,
                    totalGrad = s.Total_Grade,
                    notes = s.Notes

                }).ToList();
                return employee;

            }

            public dynamic GetActiveEmployees()
            {
                List<EmployeeVM> employee = db.Employees.Where(e => e.IsActive == true).Select(s => new EmployeeVM
                {
                    empPrintCode = s.Employee_Code,
                    fullName = s.FullName,
                    phone = s.Phone,
                    mobile = s.Mobile,
                    departmentId = s.Job.Department.Department_ID,
                    departmentAr = s.Job.Department.Department_A_Name,
                    departmentEn = s.Job.Department.Department_E_Name,
                    managerId = s.Job.Department.Employee.Employee_ID,
                    managerName = s.Job.Department.Employee.FullName,
                    ssn = s.SSN,
                    birthDate = s.BirthDate.Value.Year.ToString() + "-" + s.BirthDate.Value.Month.ToString() + "-" + s.BirthDate.Value.Day.ToString(),
                    cityId = s.City_ID,
                    cityName = s.City.Name_A,
                    jobId = s.Job_ID,
                    jobName = s.Job.Job_A_Title,
                    categoryId = s.Category_ID,
                    categoryName = s.Employees_Categories.Name_A,
                    address = s.Address,
                    email = s.Email,
                    imageId = s.ImageID,
                    branchId = s.Branch_ID,
                    branchName = s.Branch.Branch_A_Title,
                    sex = s.Sex.ToString(),
                    assignmentDate = s.Assigment_Date.Value.Year.ToString() + "-" + s.Assigment_Date.Value.Month.ToString() + "-" + s.Assigment_Date.Value.Day.ToString(),
                    leaveReason = s.LeaveReason,
                    insurance_Number = s.Insurance_Number,
                    isInsurance = s.Is_Insurance.ToString(),
                    basicSalary = s.Basic_Salary,
                    insuranceSalary = s.Insurance_Salary,
                    variableSalary = s.Variable_Salary,
                    isActive = s.IsActive.ToString(),
                    userId = s.User_ID,
                    lastUserId = s.Last_User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    leaveDate = s.leave_Date.Value.Year.ToString() + "-" + s.leave_Date.Value.Month.ToString() + "-" + s.leave_Date.Value.Day.ToString(),
                    insuranceDate = s.Insurance_Date.Value.Year.ToString() + "-" + s.Insurance_Date.Value.Month.ToString() + "-" + s.Insurance_Date.Value.Day.ToString(),
                    healthcheckDate = s.HealthCheck_Date.Value.Year.ToString() + "-" + s.HealthCheck_Date.Value.Month.ToString() + "-" + s.HealthCheck_Date.Value.Day.ToString(),
                    insuranceEndDate = s.Insurnace_EndDate.Value.Year.ToString() + "-" + s.Insurnace_EndDate.Value.Month.ToString() + "-" + s.Insurnace_EndDate.Value.Day.ToString(),
                    deputationId = s.Deputation_ID,
                    deputationName = s.Deputation.Title,
                    weekEndDay = s.WeekEndDay,
                    shiftId = s.Shift_Id,
                    yearlySPInsuranceBasic = s.YearlySPInsurance_Basic,
                    yearlySPInsuranceAdditional = s.YearlySPInsurance_Additional,
                    qualificationTypeId = s.QualificationType.Id,
                    qualificationType = s.QualificationType.Qualification,
                    qualify = s.Qualify,
                    universityId = s.University_ID,
                    facultyId = s.Faculty_ID,
                    specialityId = s.Specialty_ID,
                    gradYear = s.Grad_Year,
                    gradProj = s.Grad_Project,
                    totalGrad = s.Total_Grade,
                    notes = s.Notes
                }).ToList();
                return employee;

            }

            private dynamic getReturnEmps(List<Employee> listEmployees)
            {
                List<EmployeeVM> returnEmpsData = listEmployees.Where(e => e.IsActive == true).Select(s => new EmployeeVM
                {
                    empId = s.Employee_ID,
                    empPrintCode = s.Employee_Code,
                    fullName = s.FullName,
                    phone = s.Phone,
                    mobile = s.Mobile,
                    departmentId = s.Job.Department.Department_ID,
                    departmentAr = s.Job.Department.Department_A_Name,
                    departmentEn = s.Job.Department.Department_E_Name,
                    managerId = s.Job.Department.Employee.Employee_ID,
                    managerName = s.Job.Department.Employee.FullName,
                    ssn = s.SSN,
                    birthDate = s.BirthDate.Value.Year.ToString() + "-" + s.BirthDate.Value.Month.ToString() + "-" + s.BirthDate.Value.Day.ToString(),
                    cityId = s.City_ID,
                    cityName = s.City.Name_A,
                    jobId = s.Job_ID,
                    jobName = s.Job.Job_A_Title,
                    categoryId = s.Category_ID,
                    categoryName = s.Employees_Categories.Name_A,
                    address = s.Address,
                    email = s.Email,
                    imageId = s.ImageID,
                    branchId = s.Branch_ID,
                    branchName = s.Branch.Branch_A_Title,
                    sex = s.Sex.ToString(),
                    assignmentDate = s.Assigment_Date.Value.Year.ToString() + "-" + s.Assigment_Date.Value.Month.ToString() + "-" + s.Assigment_Date.Value.Day.ToString(),
                    leaveReason = s.LeaveReason,
                    insurance_Number = s.Insurance_Number,
                    isInsurance = s.Is_Insurance.ToString(),
                    basicSalary = s.Basic_Salary,
                    insuranceSalary = s.Insurance_Salary,
                    variableSalary = s.Variable_Salary,
                    isActive = s.IsActive.ToString(),
                    userId = s.User_ID,
                    lastUserId = s.Last_User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    leaveDate = s.leave_Date.Value.Year.ToString() + "-" + s.leave_Date.Value.Month.ToString() + "-" + s.leave_Date.Value.Day.ToString(),
                    insuranceDate = s.Insurance_Date.Value.Year.ToString() + "-" + s.Insurance_Date.Value.Month.ToString() + "-" + s.Insurance_Date.Value.Day.ToString(),
                    healthcheckDate = s.HealthCheck_Date.Value.Year.ToString() + "-" + s.HealthCheck_Date.Value.Month.ToString() + "-" + s.HealthCheck_Date.Value.Day.ToString(),
                    insuranceEndDate = s.Insurnace_EndDate.Value.Year.ToString() + "-" + s.Insurnace_EndDate.Value.Month.ToString() + "-" + s.Insurnace_EndDate.Value.Day.ToString(),
                    deputationId = s.Deputation_ID,
                    deputationName = s.Deputation.Title,
                    weekEndDay = s.WeekEndDay,
                    shiftId = s.Shift_Id,
                    yearlySPInsuranceBasic = s.YearlySPInsurance_Basic,
                    yearlySPInsuranceAdditional = s.YearlySPInsurance_Additional,
                    qualificationTypeId = s.QualificationType.Id,
                    qualificationType = s.QualificationType.Qualification,
                    qualify = s.Qualify,
                    universityId = s.University_ID,
                    facultyId = s.Faculty_ID,
                    specialityId = s.Specialty_ID,
                    gradYear = s.Grad_Year,
                    gradProj = s.Grad_Project,
                    totalGrad = s.Total_Grade,
                    notes = s.Notes
                }).ToList();
                return returnEmpsData;
            }

            private object getReturnEmp(Employee s)
            {


                return new EmployeeVM
                {
                    empId = s.Employee_ID,
                    empPrintCode = s.Employee_Code,
                    fullName = s.FullName,
                    phone = s.Phone,
                    mobile = s.Mobile,
                    departmentId = s.Job.Department.Department_ID,
                    departmentAr = s.Job.Department.Department_A_Name,
                    departmentEn = s.Job.Department.Department_E_Name,
                    managerId = s.Job.Department.Employee.Employee_ID,
                    managerName = s.Job.Department.Employee.FullName,
                    ssn = s.SSN,
                    birthDate = s.BirthDate.Value.Year.ToString() + "-" + s.BirthDate.Value.Month.ToString() + "-" + s.BirthDate.Value.Day.ToString(),
                    cityId = s.City_ID,
                    cityName = s.City.Name_A,
                    jobId = s.Job_ID,
                    jobName = s.Job.Job_A_Title,
                    categoryId = s.Category_ID,
                    categoryName = s.Employees_Categories.Name_A,
                    address = s.Address,
                    email = s.Email,
                    imageId = s.ImageID,
                    branchId = s.Branch_ID,
                    branchName = s.Branch.Branch_A_Title,
                    sex = s.Sex.ToString(),
                    assignmentDate = s.Assigment_Date.Value.Year.ToString() + "-" + s.Assigment_Date.Value.Month.ToString() + "-" + s.Assigment_Date.Value.Day.ToString(),
                    leaveReason = s.LeaveReason,
                    insurance_Number = s.Insurance_Number,
                    isInsurance = s.Is_Insurance.ToString(),
                    basicSalary = s.Basic_Salary,
                    insuranceSalary = s.Insurance_Salary,
                    variableSalary = s.Variable_Salary,
                    isActive = s.IsActive.ToString(),
                    userId = s.User_ID,
                    lastUserId = s.Last_User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    leaveDate = s.leave_Date.Value.Year.ToString() + "-" + s.leave_Date.Value.Month.ToString() + "-" + s.leave_Date.Value.Day.ToString(),
                    insuranceDate = s.Insurance_Date.Value.Year.ToString() + "-" + s.Insurance_Date.Value.Month.ToString() + "-" + s.Insurance_Date.Value.Day.ToString(),
                    healthcheckDate = s.HealthCheck_Date.Value.Year.ToString() + "-" + s.HealthCheck_Date.Value.Month.ToString() + "-" + s.HealthCheck_Date.Value.Day.ToString(),
                    insuranceEndDate = s.Insurnace_EndDate.Value.Year.ToString() + "-" + s.Insurnace_EndDate.Value.Month.ToString() + "-" + s.Insurnace_EndDate.Value.Day.ToString(),
                    deputationId = s.Deputation_ID,
                    deputationName = s.Deputation.Title,
                    weekEndDay = s.WeekEndDay,
                    shiftId = s.Shift_Id,
                    yearlySPInsuranceBasic = s.YearlySPInsurance_Basic,
                    yearlySPInsuranceAdditional = s.YearlySPInsurance_Additional,
                    qualificationTypeId = s.QualificationType.Id,
                    qualificationType = s.QualificationType.Qualification,
                    qualify = s.Qualify,
                    universityId = s.University_ID,
                    facultyId = s.Faculty_ID,
                    specialityId = s.Specialty_ID,
                    gradYear = s.Grad_Year,
                    gradProj = s.Grad_Project,
                    totalGrad = s.Total_Grade,
                    notes = s.Notes



                };
            }

            public dynamic GetEmployeeById(int empId)
            {

                try
                {
                    var Employee = db.Employees.Where(e => e.Employee_ID == empId).FirstOrDefault();

                    if (Employee == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmp(Employee);
                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }


            public dynamic GetEmployeeByEmpName(string empName)
            {
                try
                {
                    var Employee = db.Employees.Where(e => e.FullName == empName).FirstOrDefault();



                    if (Employee == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmp(Employee);
                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }

            public dynamic GetEmployeeByEmpPrintCode(string empPrintCode)
            {
                try
                {
                    var Employee = db.Employees.Where(e => e.Employee_Code == empPrintCode).FirstOrDefault();


                    if (Employee == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmp(Employee);

                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }

            public object GetEmployeesByJobId(int jobId)
            {

                try
                {
                    List<Employee> listEmployees = db.Employees.Where(e => e.Job_ID == jobId).ToList();

                    if (listEmployees == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmps(listEmployees);

                    return result;
                }


                catch (Exception ex)
                {
                return ex.Message;
                }
            }


            public object GetEmployeesByDepartmentId(int departmentId)
            {
                try
                {
                    List<Employee> listEmployees = db.Employees.Where(e => e.Job.Department_ID == departmentId).ToList();
                    if (listEmployees == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmps(listEmployees);

                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }


            //public object GetEmployeesByCompanyId(int CompanyId)
            //{
            //   try
            //    {
            //        List<Employee> listEmployees = db.Employees.Where(e => e.Job.de == CompanyId).ToList();
            //        var result = getReturnEmps(listEmployees);
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


            public object GetEmployeesByBranchId(int BranchId)
            {
                try
                {
                    List<Employee> listEmployees = db.Employees.Where(e => e.Branch_ID == BranchId).ToList();
                    if (listEmployees == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmps(listEmployees);

                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }


            public object GetEmployeesByCategoryId(int CategoryId)
            {
                try
                {
                    List<Employee> listEmployees = db.Employees.Where(e => e.Category_ID == CategoryId).ToList();
                    if (listEmployees == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmps(listEmployees);

                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }


            public object GetEmployeesByDeputationId(int DeputationId)
            {
                try
                {
                    List<Employee> listEmployees = db.Employees.Where(e => e.Deputation_ID == DeputationId).ToList();
                    if (listEmployees == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmps(listEmployees);

                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }

            public object GetEmployeesByShiftId(int ShiftId)
            {
                try
                {
                    List<Employee> listEmployees = db.Employees.Where(e => e.Shift_Id == ShiftId).ToList();
                    if (listEmployees == null)
                    {
                        return new
                        {
                            Id = 0
                        };
                    }
                    var result = getReturnEmps(listEmployees);

                    return result;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }

            public dynamic PostEmployee(EmployeePostVM e )
            {
                var employee = db.Employees.Add(new Employee
                {
                    Employee_Code = e.empPrintCode,
                    FullName = e.fullName,
                    Phone = e.phone,
                    Mobile = e.mobile,
                    SSN = e.ssn,
                    BirthDate = e.birthDate,
                    Sex = e.sex,
                    City_ID = e.cityId,
                    Address = e.address,
                    Email = e.email,
                    Branch_ID = e.branchId,
                    Job_ID = e.jobId,
                    Category_ID = e.categoryId,
                    Assigment_Date = e.assignmentDate,
                    Insurance_Number = e.insurance_Number,
                    Is_Insurance = e.isInsurance,
                    Basic_Salary = e.basicSalary,
                    Insurance_Salary = e.insuranceSalary,
                    Variable_Salary = e.variableSalary,
                    User_ID = e.userId,
                    IsActive = true,
                    Last_User_ID = e.userId,
                    Last_Update = DateTime.Now,
                    Insurance_Date = e.insuranceDate,
                    HealthCheck_Date = e.healthcheckDate,
                    Insurnace_EndDate = e.insuranceEndDate,
                    Deputation_ID = e.deputationId,
                    WeekEndDay = e.weekEndDay,
                    Shift_Id = e.shiftId,
                    YearlySPInsurance_Basic = e.yearlySPInsuranceBasic,
                    YearlySPInsurance_Additional = e.yearlySPInsuranceAdditional,
                    Qualify_Type = e.qualificationTypeId,
                    Qualify = e.qualify,
                    University_ID = e.universityId,
                    Faculty_ID = e.facultyId,
                    Specialty_ID = e.specialityId,
                    Grad_Year = e.gradYear,
                    Grad_Project = e.gradProj,
                    Total_Grade = e.totalGrad,
                    Notes = e.notes


                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    employee = employee.Employee_ID
                };
            }
            public dynamic PutEmployee(EmployeePutVM e)
            {
                var employee = db.Employees.Find(e.empId);
                employee.Employee_Code = e.empPrintCode;
                employee.FullName = e.fullName;
                employee.Phone = e.phone;
                employee.Mobile = e.mobile;
                employee.SSN = e.ssn;
                employee.BirthDate = e.birthDate;
                employee.City_ID = e.cityId;
                employee.Address = e.address;
                employee.Email = e.email;
                employee.Branch_ID = e.branchId;
                employee.Job_ID = e.jobId;
                employee.Sex = e.sex;
                employee.Category_ID = e.categoryId;
                employee.Assigment_Date = e.assignmentDate;
                employee.LeaveReason = e.leaveReason;
                employee.Insurance_Number = e.insurance_Number;
                employee.Is_Insurance = e.isInsurance;
                employee.Basic_Salary = e.basicSalary;
                employee.Insurance_Salary = e.insuranceSalary;
                employee.Variable_Salary = e.variableSalary;
                employee.IsActive = e.isActive;
                employee.Last_User_ID = e.userId;
                employee.Last_Update = DateTime.Now;
                employee.leave_Date = e.leaveDate;
                employee.Insurance_Date = e.insuranceDate;
                employee.HealthCheck_Date = e.healthcheckDate;
                employee.Insurnace_EndDate = e.insuranceEndDate;
                employee.Deputation_ID = e.deputationId;
                employee.WeekEndDay = e.weekEndDay;
                employee.Shift_Id = e.shiftId;
                employee.YearlySPInsurance_Basic = e.yearlySPInsuranceBasic;
                employee.YearlySPInsurance_Additional = e.yearlySPInsuranceAdditional;
                employee.Qualify_Type = e.qualificationTypeId;
                employee.Qualify = e.qualify;
                employee.University_ID = e.universityId;
                employee.Faculty_ID = e.facultyId;
                employee.Specialty_ID = e.specialityId;
                employee.Grad_Year = e.gradYear;
                employee.Grad_Project = e.gradProj;
                employee.Total_Grade = e.totalGrad;
                employee.Notes = e.notes;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic DeleteEmployee(int empId)
            {
                var employee = db.Employees.Where(s => s.Employee_ID == empId).FirstOrDefault();
                db.Employees.Remove(employee);
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };

            }
            public dynamic EmployeeExists(int empId)
            {
                var employee = db.Employees.Count(s => s.Employee_ID == empId) > 0 ? true : false;
                return new
                {
                    employee = employee
                };
            }


        }
    }


