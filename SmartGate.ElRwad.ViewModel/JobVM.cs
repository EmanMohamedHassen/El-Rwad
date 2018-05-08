using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel
{
   public class JobVM
    {
        public int? Id { get; set; }
        public string TitleAr{ get; set; }
        public string TitleEn { get; set; }
        public int? DepartmentId { get; set; }
        public string DepartmentNameAr { get; set; }
        public string DepartmentNameEn { get; set; }
        public int? UserId { get; set; }
        public string LastUpdate { get; set; }
    }
}
