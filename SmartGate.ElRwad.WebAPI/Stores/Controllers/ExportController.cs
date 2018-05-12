using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.ViewModel.Stores;
using SmartGate.ElRwad.BLL;
using SmartGate.ElRwad.BLL.Stores;

namespace SmartGate.ElRwad.WebAPI.Areas.Stores.Controllers
{
    public class ExportController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        public dynamic postExportDetails(ExportDetailsVM e)
        {
            return ExportManager.Instance.postExportDetails(e);
        }
        
        public dynamic postExportMain(ExportVM e)
        {
            return ExportManager.Instance.postExportMain(e);

        }
    }
}
