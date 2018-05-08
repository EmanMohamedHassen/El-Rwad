using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel
{
   public class CompaniesVM
    {
        public int? Id { get; set; }
        public string Code { get; set; }
        public string NameA{ get; set; }
        public string NameE { get; set; }
        public string SmallImage { get; set; }
        public string BackImage{ get; set; }
        public string Notes { get; set; }
        public int? ManagerId { get; set; }
        public int? UserId { get; set; }
        public string LastUpdate { get; set; }
        public string FullName { get; set; }
    }
}
