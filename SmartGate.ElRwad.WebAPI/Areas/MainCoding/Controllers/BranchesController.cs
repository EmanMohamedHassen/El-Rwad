using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class BranchesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetBranches()
        {
            var branches = db.Branches.Select(s => new
            {
                branchId = s.Branch_ID,
                //branchCompanyId=s.Company_ID,
                branchCompanyNameAr = s.Company.Company_A_Name,
                branchCompanyNameEn = s.Company.Company_E_Name,

                branchArName = s.Branch_A_Title,
                branchEnName = s.Branch_E_Name,

                branchLocation = s.Branch_Location,
                branchDescription = s.Branch_Description,
                branchImage = s.Branch_Image,
                //branchManager = s.Manager_ID,
                branchManagerName = s.Employee.FullName,
                branchUserId = s.User_ID,
                branchLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


            }).ToList();
            return branches;
        }
        [HttpGet]
        public dynamic GetBranchById(int branchId)
        {
            try
            {
                var s = db.Branches.Where(e => e.Branch_ID == branchId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        //branchId = s.Branch_ID,
                        branchCompanyId = s.Company_ID,
                        branchArName = s.Branch_A_Title,
                        branchEnName = s.Branch_E_Name,
                        branchLocation = s.Branch_Location,
                        branchDescription = s.Branch_Description,
                        branchImage = s.Branch_Image,
                        branchManager = s.Manager_ID,
                        branchUserId = s.User_ID,
                        branchLastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd")

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
        public dynamic PostBranch(
            int companyId,
            string branchArName,
            string branchEnName,
            string branchLocation,
            string branchDescription,
            string branchImage,
            int managerId,
            int userId

            )
        {
            var branch = db.Branches.Add(new Branch
            {
                Company_ID = companyId,
                Branch_A_Title = branchArName,
                Branch_E_Name = branchEnName,
                Branch_Location = branchLocation,
                Branch_Image = branchImage,
                Branch_Description = branchDescription,
                Manager_ID = managerId,
                User_ID = userId,
                Last_Update = DateTime.Now

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                branchId = branch.Branch_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutBranch(
            int branchId,
            int companyId,
            string branchArName,
            string branchEnName,
            string branchLocation,
            string branchDescription,
            string branchImage,
            int managerId,
            int userId

            )
        {
            var branch = db.Branches.Find(branchId);
            branch.Company_ID = companyId;
            branch.Branch_A_Title = branchArName;
            branch.Branch_E_Name = branchEnName;
            branch.Branch_Location = branchLocation;
            branch.Branch_Image = branchImage;
            branch.Branch_Description = branchDescription;
            branch.Manager_ID = managerId;
            branch.User_ID = userId;
            branch.Last_Update = DateTime.Now;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteBranch(int branchId)
        {
            var branch = db.Branches.Where(s => s.Branch_ID == branchId).FirstOrDefault();
            db.Branches.Remove(branch);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpGet]
        private dynamic branchExists(int branchId)
        {
            var branch = db.Branches.Count(s => s.Branch_ID == branchId) > 0 ? true : false;
            return new
            {
                branch = branch
            };
        }




    }
}
