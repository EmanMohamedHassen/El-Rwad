using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel
{
    public class YearVM
    {
        public int ID { get; set; }
        public string Year { get; set; }
    }
    public class PutYearVM
    {
        public int ID { get; set; }
        public int NewID { get; set; }
        public string Year { get; set; }
    }
}
