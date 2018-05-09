using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel
{
   public class DepartmentVM
    {
        public int Id { get; set; }
        public string NameA { get; set; }

        public string NameE{ get; set; }
        public string Description { get; set; }
        public int? ManagerId { get; set; }

        public string ManagerName { get; set; }
        public int? UserId { get; set; }
        public string LastUpdate { get; set; }
        public int? BranchId { get; set; }

        public string BranchNameAR { get; set; }
        public string BranchNameEN { get; set; }
    }



}
