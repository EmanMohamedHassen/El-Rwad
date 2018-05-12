using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
  public class PermissionTypeVM
    {
        public int permissionTypeId { get; set; }
        public string permissionTypeNameAr { get; set; }
        public string permissionTypeNameEn { get; set; }
        public string permissionTypeSalaryDeduc { get; set; }
        public double? permissionTypededucPercent { get; set; }
        public byte? permissionTypeMaxTimes { get; set; }
        public byte? permissionTypeHoursCount { get; set; }
        public int? permissionUserId { get; set; }
        public string permissionTypeLastUpdate { get; set; }
    }

    public class PermissionTypePVM
    {
        public int permissionTypeId { get; set; }
        public string permissionTypeNameAr { get; set; }
        public string permissionTypeNameEn { get; set; }
        public bool? permissionTypeSalaryDeduc { get; set; }
        public double? permissionTypededucPercent { get; set; }
        public byte? permissionTypeMaxTimes { get; set; }
        public byte? permissionTypeHoursCount { get; set; }
        public int? permissionUserId { get; set; }
    }
}
