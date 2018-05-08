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

            public dynamic PostEmployee(
                string empPrintCode,
                string fullName,
                string phone,
                string mobile,
                string ssn,
                DateTime birthDate,
                int cityId,
                string address,
                string email,
                int branchId,
                int jobId,
                bool sex,
                int categoryId,
                DateTime assignmentDate,
                string insurance_Number,
                bool isInsurance,
                float basicSalary,
                float insuranceSalary,
                float variableSalary,
                int userId,
                DateTime insuranceDate,
                DateTime healthcheckDate,
                DateTime insuranceEndDate,
                int deputationId,
                int weekEndDay,
                int shiftId,
                float yearlySPInsuranceBasic,
                float yearlySPInsuranceAdditional,
                byte qualificationTypeId,
                string qualify,
                int universityId,
                int facultyId,
                int specialityId,
                int gradYear,
                string gradProj,
                string totalGrad,
                string notes
                )
            {
                var employee = db.Employees.Add(new Employee
                {
                    Employee_Code = empPrintCode,
                    FullName = fullName,
                    Phone = phone,
                    Mobile = mobile,
                    SSN = ssn,
                    BirthDate = birthDate,
                    Sex = sex,
                    City_ID = cityId,
                    Address = address,
                    Email = email,
                    Branch_ID = branchId,
                    Job_ID = jobId,
                    Category_ID = categoryId,
                    Assigment_Date = assignmentDate,
                    Insurance_Number = insurance_Number,
                    Is_Insurance = isInsurance,
                    Basic_Salary = basicSalary,
                    Insurance_Salary = insuranceSalary,
                    Variable_Salary = variableSalary,
                    User_ID = userId,
                    IsActive = true,
                    Last_User_ID = userId,
                    Last_Update = DateTime.Now,
                    Insurance_Date = insuranceDate,
                    HealthCheck_Date = healthcheckDate,
                    Insurnace_EndDate = insuranceEndDate,
                    Deputation_ID = deputationId,
                    WeekEndDay = weekEndDay,
                    Shift_Id = shiftId,
                    YearlySPInsurance_Basic = yearlySPInsuranceBasic,
                    YearlySPInsurance_Additional = yearlySPInsuranceAdditional,
                    Qualify_Type = qualificationTypeId,
                    Qualify = qualify,
                    University_ID = universityId,
                    Faculty_ID = facultyId,
                    Specialty_ID = specialityId,
                    Grad_Year = gradYear,
                    Grad_Project = gradProj,
                    Total_Grade = totalGrad,
                    Notes = notes


                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    employee = employee.Employee_ID
                };
            }
            [HttpPut]
            [AcceptVerbs("GET", "POST")]
            public dynamic PutEmployee(
                int empId,
                string empPrintCode,
                string fullName,
                string phone,
                string mobile,
                string ssn,
                DateTime birthDate,
                int cityId,
                string address,
                string email,
                int branchId,
                int jobId,
                bool sex,
                int categoryId,
                DateTime assignmentDate,
                string leaveReason,
                string insurance_Number,
                bool isInsurance,
                float basicSalary,
                float insuranceSalary,
                float variableSalary,
                bool isActive,
                int userId,
                DateTime leaveDate,
                DateTime insuranceDate,
                DateTime healthcheckDate,
                DateTime insuranceEndDate,
                int deputationId,
                int weekEndDay,
                int shiftId,
                float yearlySPInsuranceBasic,
                float yearlySPInsuranceAdditional,
                byte qualificationTypeId,
                string qualify,
                int universityId,
                int facultyId,
                int specialityId,
                int gradYear,
                string gradProj,
                string totalGrad,
                string notes
                )
            {
                var employee = db.Employees.Find(empId);
                employee.Employee_Code = empPrintCode;
                employee.FullName = fullName;
                employee.Phone = phone;
                employee.Mobile = mobile;
                employee.SSN = ssn;
                employee.BirthDate = birthDate;
                employee.City_ID = cityId;
                employee.Address = address;
                employee.Email = email;
                employee.Branch_ID = branchId;
                employee.Job_ID = jobId;
                employee.Sex = sex;
                employee.Category_ID = categoryId;
                employee.Assigment_Date = assignmentDate;
                employee.LeaveReason = leaveReason;
                employee.Insurance_Number = insurance_Number;
                employee.Is_Insurance = isInsurance;
                employee.Basic_Salary = basicSalary;
                employee.Insurance_Salary = insuranceSalary;
                employee.Variable_Salary = variableSalary;
                employee.IsActive = isActive;
                employee.Last_User_ID = userId;
                employee.Last_Update = DateTime.Now;
                employee.leave_Date = leaveDate;
                employee.Insurance_Date = insuranceDate;
                employee.HealthCheck_Date = healthcheckDate;
                employee.Insurnace_EndDate = insuranceEndDate;
                employee.Deputation_ID = deputationId;
                employee.WeekEndDay = weekEndDay;
                employee.Shift_Id = shiftId;
                employee.YearlySPInsurance_Basic = yearlySPInsuranceBasic;
                employee.YearlySPInsurance_Additional = yearlySPInsuranceAdditional;
                employee.Qualify_Type = qualificationTypeId;
                employee.Qualify = qualify;
                employee.University_ID = universityId;
                employee.Faculty_ID = facultyId;
                employee.Specialty_ID = specialityId;
                employee.Grad_Year = gradYear;
                employee.Grad_Project = gradProj;
                employee.Total_Grade = totalGrad;
                employee.Notes = notes;

                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            [HttpDelete]
            [AcceptVerbs("GET", "POST")]
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
            [HttpGet]
            private dynamic EmployeeExists(int empId)
            {
                var employee = db.Employees.Count(s => s.Employee_ID == empId) > 0 ? true : false;
                return new
                {
                    employee = employee
                };
            }


        }
    }

}
}
