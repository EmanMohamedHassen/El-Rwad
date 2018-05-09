using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class MissionVM
    {
        public int missionId { get; set; }
        public int? empId { get; set; }
        public string empName { get; set; }
        public byte? month { get; set; }
        public int? year { get; set; }
        public int? fromHour { get; set; }
        public int? toHour { get; set; }
        public int? fromMinute { get; set; }
        public int? toMinute { get; set; }
        public string missionCauses { get; set; }
        public string missionDate { get; set; }
        public string approv { get; set; }
        public string approvDate { get; set; }
        public int? managerId { get; set; }
        public int? userId { get; set; }
        public string lastUpdate { get; set; }
    }

    public class MissionEmpVM
    {
        public int missionId { get; set; }
        public int? empId { get; set; }
        public string empName { get; set; }
        public string empCode { get; set; }
        public string empJob { get; set; }
        public byte? month { get; set; }
        public int? year { get; set; }
        public int? fromHour { get; set; }
        public int? toHour { get; set; }
        public int? fromMinute { get; set; }
        public int? toMinute { get; set; }
        public string missionCauses { get; set; }
        public string missionDate { get; set; }
        public string approv { get; set; }
        public string approvDate { get; set; }
        public int? managerId { get; set; }
        public int? userId { get; set; }
        public string lastUpdate { get; set; }
    }

    public class MissionPVM
    {
        public int missionId { get; set; }
        public int? empId { get; set; }
        public byte? month { get; set; }
        public int? year { get; set; }
        public int? fromHour { get; set; }
        public int? toHour { get; set; }
        public int? fromMinute { get; set; }
        public int? toMinute { get; set; }
        public string missionCauses { get; set; }
        public DateTime missionDate { get; set; }
        public int? managerId { get; set; }
        public int? userId { get; set; }
    }
    public class MissionAVM
    {
        public int missionId { get; set; }
        public bool? approv { get; set; }
        public int? userId { get; set; }
    }
}
