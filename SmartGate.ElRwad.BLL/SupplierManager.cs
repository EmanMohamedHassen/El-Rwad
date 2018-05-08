using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL
{
   public class SupplierManager
    {
        private static SupplierManager instance;
        public static SupplierManager Instance { get { return instance; } }
        static SupplierManager()
        {
            instance = new SupplierManager();
        }
        private elRwadEntities db = new elRwadEntities();


    
        public dynamic GetAllSuppliers()
        {
            List<SuppliersVM> suppliers = db.Suppliers.Select(s => new SuppliersVM
            {
                Id = s.Id,
                NameAr= s.NameAr,
                NameEn= s.NameEn,
                phone= s.Phone,
                Mobile= s.Mobile,
                Email= s.Email,
                Address= s.Address,
                CityId = s.CityId,
                CityName = s.City.Name_A,
                RegionId = s.RegionId,
                RegionName = s.Region.NameAr
            }).ToList();
            return suppliers;
        }


        public dynamic GetSupplierById(int supplierId)
        {
            try
            {
                var supplier = db.Suppliers.Where(e => e.Id == supplierId).FirstOrDefault();
                if (supplier != null)
                {
                    return new SuppliersVM
                    {
                        NameAr = supplier.NameAr,
                        NameEn= supplier.NameEn,
                        phone= supplier.Phone,
                        Mobile = supplier.Mobile,
                        Email= supplier.Email,
                        Address= supplier.Address,
                        CityId= supplier.CityId,
                        CityName = supplier.City.Name_A,
                        RegionId = supplier.RegionId,
                        RegionName = supplier.Region.NameAr
                    };
                }
                else
                {
                    return new
                    {
                        Id = 0
                    };
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public dynamic PostSupplier(SuppliersVM s)
        {
            db.Suppliers.Add(new Supplier
            {
                NameAr = s.NameAr,
                NameEn = s.NameEn,
                Phone = s.phone,
                Mobile = s.Mobile,
                Email = s.Email,
                Address = s.Address,
                CityId = s.CityId,
                RegionId = s.RegionId

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        public dynamic PutSupplier(SuppliersVM s)
        {
            var supplier = db.Suppliers.Find(s.Id);

            supplier.NameAr = s.NameAr;
            supplier.NameEn = s.NameEn;
            supplier.Phone = s.phone;
            supplier.Mobile = s.Mobile;
            supplier.Email = s.Email;
            supplier.Address = s.Address;
            supplier.CityId = s.CityId;
            supplier.RegionId = s.RegionId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic DeleteSupplier(int supplierId)
        {
            var supplier = db.Suppliers.Where(s => s.Id == supplierId).FirstOrDefault();
            db.Suppliers.Remove(supplier);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
