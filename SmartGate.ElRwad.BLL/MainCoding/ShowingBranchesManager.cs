using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
namespace SmartGate.ElRwad.BLL
{
  public  class ShowingBranchesManager
    {
        private static ShowingBranchesManager instance;
        public static ShowingBranchesManager Instance { get { return instance; } }
        static ShowingBranchesManager()
        {
            instance = new ShowingBranchesManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetShowingBranches()
        {
            List<ShowingBranchesVM> showingBranches = db.Showing_Branches.Select(s => new ShowingBranchesVM
            {
                Id = s.Id,
                NameAr= s.NameAr,
                NameEn= s.NameEn,
                Address= s.Address,
                RegionId= s.RegionId,
                RegionName= s.Region.NameAr,
                CityId = s.CityId,
                CityName = s.City.Name_A,
                UserId = s.UserId,
                LastUpdate= s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()

            }).ToList();
            return showingBranches;
        }
        public dynamic GetShowingBranchById(int showingBranchId)
        {
            try
            {
                var showingBranch = db.Showing_Branches.Where(e => e.Id == showingBranchId).FirstOrDefault();
                if (showingBranch != null)
                {
                    return new ShowingBranchesVM
                    {

                        Id= showingBranch.Id,
                        NameAr= showingBranch.NameAr,
                        NameEn= showingBranch.NameEn,
                        Address= showingBranch.Address,
                        RegionId= showingBranch.RegionId,
                        RegionName= showingBranch.Region.NameAr,
                        CityId= showingBranch.CityId,
                        CityName= showingBranch.City.Name_A,
                        UserId= showingBranch.UserId,
                        LastUpdate= showingBranch.LastUpdate.Value.ToString("yyyy-MM-dd")
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
        
        public dynamic PostShowingBranch(ShowingBranchesVM b)
        {
            db.Showing_Branches.Add(new Showing_Branches
            {

                NameAr = b.NameAr,
                NameEn = b.NameEn,
                Address = b.Address,
                RegionId = b.RegionId,
                CityId = b.CityId,
                LastUpdate = DateTime.Now

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        
        public dynamic PutShowingBranch(ShowingBranchesVM b)
        {
            var showingBranch = db.Showing_Branches.Find(b.Id);
            showingBranch.NameAr = b.NameAr;
            showingBranch.NameEn = b.NameEn;
            showingBranch.Address = b.Address;
            showingBranch.RegionId = b.RegionId;
            showingBranch.CityId = b.CityId;
            showingBranch.LastUpdate = DateTime.Now;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        
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
