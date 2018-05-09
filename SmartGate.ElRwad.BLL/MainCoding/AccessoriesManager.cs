using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.BLL
{
    public class AccessoriesManager
    {
        elRwadEntities db = new elRwadEntities();

        private static AccessoriesManager instance;
        public static AccessoriesManager Instance { get { return instance; } }


        static AccessoriesManager()
        {
            instance = new AccessoriesManager();
        }
        public dynamic GetAllAccessories()
        {
            List<AccessoriesVM> accessories = db.Accessories.Select(s => new AccessoriesVM
            {
                Id = s.Id,
                NameA = s.NameA,
                NameE = s.NameE,
                Price = (float)s.Price

            }).ToList();
            return accessories;
        }


        public dynamic GetAccessoryById(int accessoryId)
        {
            try
            {
                var accessory = db.Accessories.Where(s => s.Id == accessoryId).FirstOrDefault();
                if (accessory != null)
                {
                    return new AccessoriesVM
                    {

                        Id = accessory.Id,
                        NameA = accessory.NameA,
                        NameE = accessory.NameE,
                        Price = (float)accessory.Price

                    };
                }
                else
                {
                    return new AccessoriesVM
                    {

                        Id = 0,
                        NameA = null,
                        NameE = null,
                        Price = 0

                    };
                }
            }
            catch (Exception ex)
            {
                return new AccessoriesVM
                {

                    Id = 0,
                    NameA = null,
                    NameE = null,
                    Price = 0

                };
            }
        }
        public dynamic GetAccessoriesByPurchaseOrderId(int purchaseOrderId)
        {

            List< AccessoriesVM> accessories = db.PurchaseOrder_Accessories.Where(e => e.PurchaseOrder_Id == purchaseOrderId).Select(s => new AccessoriesVM
            {
                Id = s.Accessory.Id,
                NameA = s.Accessory.NameA,
                NameE = s.Accessory.NameE,
                Price =(float) s.Accessory.Price

            }).ToList();
            return accessories;

        }

        public dynamic PostAccessory(AccessoriesVM a)
        {
            db.Accessories.Add(new Accessory
            {
                NameA = a.NameA,
                NameE = a.NameE,
                Price = a.Price,


            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        public dynamic PutAccessory(int accessoryId, string accessoryNameA, string accessoryNameE, float price)
        {
            var accessory = db.Accessories.Find(accessoryId);

            accessory.NameA = accessoryNameA;
            accessory.NameE = accessoryNameE;
            accessory.Price = price;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
 
        public dynamic DeleteAccessory(int accessoryId)
        {
            var Accessory = db.Accessories.Where(s => s.Id == accessoryId).FirstOrDefault();
            db.Accessories.Remove(Accessory);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }



        ///////////// post&put purchaseorderaccesssories
        public dynamic PostPurchaseOrderAccesssories(int purchaseOrderId,  List<int> accessoriesIDs)
        {
            List<double> TotalCost = new List<double>();
            foreach (var item in accessoriesIDs)
            {
                var a = db.Accessories.Where(s => s.Id == item).FirstOrDefault();
                var purchaseorderaccessory = db.PurchaseOrder_Accessories.Add(new PurchaseOrder_Accessories
                {

                    PurchaseOrder_Id = purchaseOrderId,
                    Accessories_Id = item

                });
                TotalCost.Add(a.Price.Value);

            }

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                totalprice = TotalCost.Sum()
            };

        }
    }


}
