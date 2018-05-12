using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.BLL.HR;
using SmartGate.ElRwad.ViewModel.HR;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class PermissionTypeController : ApiController
    {
        /// <summary>
        /// get permission type 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermissionType()
        {
            return PermissionTypeManager.Instance.GetPermissionType();
        }
        /// <summary>
        /// get permission type by id 
        /// </summary>
        /// <param name="permissionTypeId"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetPermissionTypeById(int permissionTypeId)
        {
            return PermissionTypeManager.Instance.GetPermissionTypeById(permissionTypeId);
        }
        /// <summary>
        /// post permission type 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPost]

        public dynamic PostPermissionType(PermissionTypePVM p)
        {
            return PermissionTypeManager.Instance.PostPermissionType(p);
        }
        /// <summary>
        /// put permission type 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPermissionType(PermissionTypePVM p)

        {
            return PermissionTypeManager.Instance.PutPermissionType(p);

        }
        /// <summary>
        /// delete permission type 
        /// </summary>
        /// <param name="permissionTypeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeletePermissionType(int permissionTypeId)
        {
            return PermissionTypeManager.Instance.DeletePermissionType(permissionTypeId);
        }
        /// <summary>
        /// check if permission type exists 
        /// </summary>
        /// <param name="permissionTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic PermissionTypeExists(int permissionTypeId)
        {
            return PermissionTypeManager.Instance.PermissionTypeExists(permissionTypeId);
        }





    }
}
