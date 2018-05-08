using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class DeductionVM
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string NameA { get; set; }
        public string NameE { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public string LastUpdate { get; set; }
    }
}
