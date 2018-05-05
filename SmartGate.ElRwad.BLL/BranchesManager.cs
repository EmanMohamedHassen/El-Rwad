using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.BLL
{
    public class BranchesManager
    {

        private static BranchesManager instance;
        public static BranchesManager Instance { get { return instance; } }

        static BranchesManager()
        {
            instance = new BranchesManager();
        }
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetBranches()
        {
            List<BranchesVM> branches = db.Branches.Select(s => new BranchesVM
            {
                Id = s.Branch_ID,
                CompanyNameA = s.Company.Company_A_Name,
                CompanyNameE = s.Company.Company_E_Name,
                BranchName_A = s.Branch_A_Title,
                BranchNameE = s.Branch_E_Name,
                BranchLocation = s.Branch_Location,
                BranchDescription = s.Branch_Description,
                BranchImage = s.Branch_Image,
                ManagerName = s.Employee.FullName,
                UserId = s.User_ID,
                LastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()


            }).ToList();
            return branches;
        }
        public dynamic GetBranchById(int branchId)
        {
            try
            {
                var s = db.Branches.Where(e => e.Branch_ID == branchId).FirstOrDefault();
                if (s != null)
                {
                    return new BranchesVMById
                    {
                        CompanyId = s.Company_ID,
                        BranchName_A = s.Branch_A_Title,
                        BranchNameE = s.Branch_E_Name,
                        BranchLocation = s.Branch_Location,
                        BranchDescription = s.Branch_Description,
                        BranchImage = s.Branch_Image,
                        ManagerId = s.Manager_ID,
                        UserId = s.User_ID,
                        LastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd")

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
            catch 
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


        public dynamic PostBranch(BranchesVM b)
        {
            var branch = db.Branches.Add(new Branch
            {
                Company_ID = b.CompanyId,
                Branch_A_Title = b.BranchName_A,
                Branch_E_Name = b.BranchNameE,
                Branch_Location = b.BranchLocation,
                Branch_Image = b.BranchImage,
                Branch_Description = b.BranchDescription,
                Manager_ID = b.ManagerId,
                User_ID = b.UserId,
                Last_Update = DateTime.Now

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                branchId = branch.Branch_ID
            };
        }

        public dynamic PutBranch(BranchesVM b)
        {
            var branch = db.Branches.Find(b.Id);
            branch.Company_ID = b.CompanyId;
            branch.Branch_A_Title = b.BranchName_A;
            branch.Branch_E_Name = b.BranchNameE;
            branch.Branch_Location = b.BranchLocation;
            branch.Branch_Image = b.BranchImage;
            branch.Branch_Description = b.BranchDescription;
            branch.Manager_ID = b.ManagerId;
            branch.User_ID = b.UserId;
            branch.Last_Update = DateTime.Now;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

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

        public dynamic branchExists(int branchId)
        {
            var branch = db.Branches.Count(s => s.Branch_ID == branchId) > 0 ? true : false;
            return new
            {
                branch = branch
            };
        }

    }
}
