using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class MessageVM
    {
        public int messageId { get; set; }
        public string messageSubject { get; set; }
        public string message { get; set; }
        public int? fromUserId { get; set; }
        public int? toUserId { get; set; }
        public string filePath { get; set; }
    }
}
