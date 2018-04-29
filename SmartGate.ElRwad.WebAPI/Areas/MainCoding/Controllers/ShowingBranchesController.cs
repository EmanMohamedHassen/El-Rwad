using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class ShowingBranchesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        /// <summary>
        /// get all Showing branches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetShowingBranches()
        {
            var showingBranches = db.Showing_Branches.Select(s => new
            {
                showingBranchId = s.Id,
                showingBranchArName = s.NameAr,
                showingBranchEnName = s.NameEn,
                showingBranchLocation = s.Address,
                showingBranchRegionId = s.RegionId,
                showingBranchRegionName = s.Region.NameAr,

                showingBranchCityId = s.CityId,
                showingBranchCityName = s.City.Name_A,
                userId = s.UserId,
                lastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()

            }).ToList();
            return showingBranches;
        }

        /// <summary>
        /// get showing branch by id
        /// </summary>
        /// <param name="showingBranchId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetShowingBranchById(int showingBranchId)
        {
            try
            {
                var showingBranch = db.Showing_Branches.Where(e => e.Id == showingBranchId).FirstOrDefault();
                if (showingBranch != null)
                {
                    return new
                    {

                        showingBranchId = showingBranch.Id,
                        showingBranchArName = showingBranch.NameAr,
                        showingBranchEnName = showingBranch.NameEn,
                        showingBranchLocation = showingBranch.Address,
                        showingBranchRegionId = showingBranch.RegionId,
                        showingBranchRegionName = showingBranch.Region.NameAr,
                        showingBranchCityId = showingBranch.CityId,
                        showingBranchCityName = showingBranch.City.Name_A,
                        userId = showingBranch.UserId,
                        lastUpdate = showingBranch.LastUpdate.Value.ToString("yyyy-MM-dd")
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

        /// <summary>
        /// to add new Showing branch
        /// </summary>
        /// <param name="showingBranchArName"></param>
        /// <param name="showingBranchEnName"></param>
        /// <param name="showingBranchLocation"></param>
        /// <param name="showingBranchRegionId"></param>
        /// <param name="showingBranchCityId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostShowingBranch(string showingBranchArName, string showingBranchEnName,
            string showingBranchLocation, int showingBranchRegionId, int showingBranchCityId, int userId)
        {
            db.Showing_Branches.Add(new Showing_Branches
            {

                NameAr = showingBranchArName,
                NameEn = showingBranchEnName,
                Address = showingBranchLocation,
                RegionId = showingBranchRegionId,
                CityId = showingBranchCityId,
                LastUpdate = DateTime.Now

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        /// <summary>
        /// to update showing branch
        /// </summary>
        /// <param name="showingBranchId"></param>
        /// <param name="showingBranchArName"></param>
        /// <param name="showingBranchEnName"></param>
        /// <param name="showingBranchLocation"></param>
        /// <param name="showingBranchRegionId"></param>
        /// <param name="showingBranchCityId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutShowingBranch(int showingBranchId, string showingBranchArName, string showingBranchEnName, string showingBranchLocation, int showingBranchRegionId, int showingBranchCityId, int userId)
        {
            var showingBranch = db.Showing_Branches.Find(showingBranchId);
            showingBranch.NameAr = showingBranchArName;
            showingBranch.NameEn = showingBranchEnName;
            showingBranch.Address = showingBranchLocation;
            showingBranch.RegionId = showingBranchRegionId;
            showingBranch.CityId = showingBranchCityId;
            showingBranch.LastUpdate = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        /// <summary>
        /// to delete showing branch
        /// </summary>
        /// <param name="showingBranchId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteShowingBranch(int showingBranchId)
        {
            var showingBranch = db.Showing_Branches.Where(s => s.Id == showingBranchId).FirstOrDefault();
            db.Showing_Branches.Remove(showingBranch);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }



    }
}
