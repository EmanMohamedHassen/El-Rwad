using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL.HR
{
    public class PermissionTypeManager
    {
        private static PermissionTypeManager instance;
        public static PermissionTypeManager Instance { get { return instance; } }
        static PermissionTypeManager()
        {
            instance = new PermissionTypeManager();
        }
        private elRwadEntities db = new elRwadEntities();
        public dynamic GetPermissionType()
        {
            List<PermissionTypeVM> permissionType = db.PermissionTypes.Select(s => new PermissionTypeVM
            {
                permissionTypeId = s.PermissionType_ID,
                permissionTypeNameAr = s.PermissionType_Name,
                permissionTypeNameEn = s.PermissionType_Name_EN,
                permissionTypeSalaryDeduc = s.Salary_Deduc.ToString(),
                permissionTypededucPercent = s.Deduc_Percent,
                permissionTypeMaxTimes = s.Max_Times, //monthly
                permissionTypeHoursCount = s.Hours_Count, //total
                permissionUserId = s.User_ID,
                permissionTypeLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


            }).ToList();
            return permissionType;
        }

        public dynamic GetPermissionTypeById(int permissionTypeId)
        {
            try
            {
                var s = db.PermissionTypes.Where(e => e.PermissionType_ID == permissionTypeId).FirstOrDefault();
                if (s != null)
                {
                    return new PermissionTypeVM
                    {
                        //permissionTypeId = s.PermissionType_ID,
                        permissionTypeNameAr = s.PermissionType_Name,
                        permissionTypeNameEn = s.PermissionType_Name_EN,
                        permissionTypeSalaryDeduc = s.Salary_Deduc.ToString(),
                        permissionTypededucPercent = s.Deduc_Percent,
                        permissionTypeMaxTimes = s.Max_Times, //monthly
                        permissionTypeHoursCount = s.Hours_Count, //total
                        permissionUserId = s.User_ID,
                        permissionTypeLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

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

        public dynamic PostPermissionType(PermissionTypePVM p)
        {
            db.PermissionTypes.Add(new PermissionType
            {

                PermissionType_Name = p.permissionTypeNameAr,
                PermissionType_Name_EN = p.permissionTypeNameEn,
                Salary_Deduc = p.permissionTypeSalaryDeduc,
                Deduc_Percent = p.permissionTypededucPercent,
                Max_Times = p.permissionTypeMaxTimes,
                Hours_Count = p.permissionTypeHoursCount,
                User_ID = p.permissionUserId,
                Last_Update = DateTime.Now,
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        public dynamic PutPermissionType(PermissionTypePVM p)

        {
            var permissionType = db.PermissionTypes.Find(p.permissionTypeId);

            permissionType.PermissionType_Name = p.permissionTypeNameAr;
            permissionType.PermissionType_Name_EN = p.permissionTypeNameEn;
            permissionType.Salary_Deduc = p.permissionTypeSalaryDeduc;
            permissionType.Deduc_Percent = p.permissionTypededucPercent;
            permissionType.Max_Times = p.permissionTypeMaxTimes; //monthly
            permissionType.Hours_Count = p.permissionTypeHoursCount; //total
            permissionType.User_ID = p.permissionUserId;
            permissionType.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                permissionType = permissionType.PermissionType_ID
            };

        }

        public dynamic DeletePermissionType(int permissionTypeId)
        {
            var permissionType = db.PermissionTypes.Where(s => s.PermissionType_ID == permissionTypeId).FirstOrDefault();
            db.PermissionTypes.Remove(permissionType);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic PermissionTypeExists(int permissionTypeId)
        {
            var permissionType = db.PermissionTypes.Count(s => s.PermissionType_ID == permissionTypeId) > 0 ? true : false;
            return new
            {
                permissionType = permissionType
            };
        }





    }
}