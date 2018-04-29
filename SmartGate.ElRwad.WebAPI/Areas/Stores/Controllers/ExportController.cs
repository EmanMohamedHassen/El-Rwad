using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.Stores.Controllers
{
    public class ExportController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        public dynamic postExportDetails(int carId, DateTime exportDate, int exportMainId)
        {
            var export = db.ExportDetails.Add(new ExportDetail
            {
                CarID = carId,
                ExportDate = exportDate,
                ExportMainID = exportMainId
            });


            var result = db.SaveChanges();

            return new
            {
                result = result,
                exportDetailsId = export.ExportDetails_ID
            };

        }



        public dynamic postExportMain(bool forSale, int sellOrderId, int storeId, int toStoreId)
        {
            var export = db.ExportMains.Add(new ExportMain
            {
                ForSale = forSale,
                SellOrder_ID = sellOrderId,
                StoreID = storeId,
                ToStoreID = toStoreId
            });


            var result = db.SaveChanges();

            return new
            {
                result = result,
                exportDetailsId = export.ExportMainID
            };

        }
    }
}
