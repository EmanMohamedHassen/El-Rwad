using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel
{
   public class StoresVM
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int? RegionId { get; set; }
        public string RegionName { get; set; }
        public int? CityId { get; set; }
        public string CityName { get; set; }
        public string Phone{ get; set; }
        public int? StoreManagerId { get; set; }
        public string StoreManagerName { get; set; }
    }
}
