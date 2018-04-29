using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class PermissionTypeController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetPermissionType()
        {
            var permissionType = db.PermissionTypes.Select(s => new
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
        [HttpGet]

        public dynamic GetPermissionTypeById(int permissionTypeId)
        {
            try
            {
                var s = db.PermissionTypes.Where(e => e.PermissionType_ID == permissionTypeId).FirstOrDefault();
                if (s != null)
                {
                    return new
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

        public dynamic PostPermissionType(
            string permissionTypeNameAr,
            string permissionTypeNameEn,
            bool permissionTypeSalaryDeduc,
            float permissionTypededucPercent,
            byte permissionTypeMaxTimes,  //monthly
            byte permissionTypeHoursCount, //total
            int permissionUserId
            )
        {
            db.PermissionTypes.Add(new PermissionType
            {

                PermissionType_Name = permissionTypeNameAr,
                PermissionType_Name_EN = permissionTypeNameEn,
                Salary_Deduc = permissionTypeSalaryDeduc,
                Deduc_Percent = permissionTypededucPercent,
                Max_Times = permissionTypeMaxTimes,
                Hours_Count = permissionTypeHoursCount,
                User_ID = permissionUserId,
                Last_Update = DateTime.Now,
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPermissionType(
            int permissionTypeId,
            string permissionTypeNameAr,
            string permissionTypeNameEn,
            bool permissionTypeSalaryDeduc,
            float permissionTypededucPercent,
            byte permissionTypeMaxTimes,
            byte permissionTypeHoursCount,
            int permissionUserId
            )

        {
            var permissionType = db.PermissionTypes.Find(permissionTypeId);

            permissionType.PermissionType_Name = permissionTypeNameAr;
            permissionType.PermissionType_Name_EN = permissionTypeNameEn;
            permissionType.Salary_Deduc = permissionTypeSalaryDeduc;
            permissionType.Deduc_Percent = permissionTypededucPercent;
            permissionType.Max_Times = permissionTypeMaxTimes; //monthly
            permissionType.Hours_Count = permissionTypeHoursCount; //total
            permissionType.User_ID = permissionUserId;
            permissionType.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                permissionType = permissionType.PermissionType_ID
            };

        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
        [HttpGet]
        private dynamic PermissionTypeExists(int permissionTypeId)
        {
            var permissionType = db.PermissionTypes.Count(s => s.PermissionType_ID == permissionTypeId) > 0 ? true : false;
            return new
            {
                permissionType = permissionType
            };
        }





    }
}
