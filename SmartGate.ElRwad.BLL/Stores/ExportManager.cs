using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL.Stores
{
    public class ExportManager
    {
        private static ExportManager instance;
        public static ExportManager Instance { get { return instance; } }

        static ExportManager()
        {
            instance = new ExportManager();
        }
        private elRwadEntities db = new elRwadEntities();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="exportDate"></param>
        /// <param name="exportMainId"></param>
        /// <returns></returns>
        public dynamic postExportDetails(ExportDetailsVM e)
        {
            var export = db.ExportDetails.Add(new ExportDetail
            {
                CarID = e.carId,
                ExportDate = e.exportDate,
                ExportMainID = e.exportMainId
            });
            var result = db.SaveChanges() > 0 ? true : false;

            return new
            {
                result = result,
                exportDetailsId = export.ExportDetails_ID
            };
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="forSale"></param>
        /// <param name="sellOrderId"></param>
        /// <param name="storeId"></param>
        /// <param name="toStoreId"></param>
        /// <returns></returns>
        public dynamic postExportMain(ExportVM e)
        {
            var export = db.ExportMains.Add(new ExportMain
            {
                ForSale = e.ForSale,
                SellOrder_ID = e.SellOrder_ID,
                StoreID = e.StoreID,
                ToStoreID = e.ToStoreID
            });
            var result = db.SaveChanges() > 0 ? true : false;

            return new
            {
                result = result,
                exportDetailsId = export.ExportMainID
            };

        }
    }
}
