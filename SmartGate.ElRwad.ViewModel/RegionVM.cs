using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel
{
    public class RegionVM
    {
        public int? Id { get; set; }
        public string NameAr{ get; set; }
        public string NameEN { get; set; }
        public int CityId { get; set; }
    }

    public class GetRegionVM
    {
        public int? Id { get; set; }
        public string NameAr { get; set; }
        public string NameEN { get; set; }
        public int? CityId { get; set; }

        public string CityName { get; set; }
    }
}
