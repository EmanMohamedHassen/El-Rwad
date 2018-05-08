using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel
{
    public class BranchesVM
    {
        public int? Id { get; set; }

        public int CompanyId { get; set; }

        public string CompanyNameA { get; set; }

        public string CompanyNameE { get; set; }

        public string BranchName_A { get; set; }

        public string BranchNameE { get; set; }


        public string BranchLocation { get; set; }

        public string BranchDescription { get; set; }

        public int BranchMobile { get; set; }

        public int BranchPhone { get; set; }

        public int ManagerId { get; set; }

        public string ManagerName { get; set; }

        public int? UserId { get; set; }

        public string LastUpdate { get; set; }

        public string BranchImage { get; set; }
        public int RegionId { get; set; }

        public int CityId { get; set; }
    }

    public class BranchesVMById
    {


        public int? CompanyId { get; set; }

        public string CompanyNameA { get; set; }


        public string BranchName_A { get; set; }

        public string BranchNameE { get; set; }


        public string BranchLocation { get; set; }

        public string BranchDescription { get; set; }

       
        public int? ManagerId { get; set; }

        public int? UserId { get; set; }

        public string LastUpdate { get; set; }

        public string BranchImage { get; set; }
        

    }
}
