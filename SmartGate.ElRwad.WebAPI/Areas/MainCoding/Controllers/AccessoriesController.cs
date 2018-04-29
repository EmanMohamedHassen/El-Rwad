using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class AccessoriesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllAccessories()
        {
            var accessories = db.Accessories.Select(s => new
            {
                accessoryId = s.Id,
                accessoryNameA = s.NameA,
                accessoryNameE = s.NameE,
                accessoriePrice = s.Price,

            }).ToList();
            return accessories;
        }


        [HttpGet]
        public dynamic GetAccessoryById(int accessoryId)
        {
            try
            {
                var accessory = db.Accessories.Where(e => e.Id == accessoryId).FirstOrDefault();
                if (accessory != null)
                {
                    return new
                    {
                        accessoryId = accessory.Id,
                        accessoryNameA = accessory.NameA,
                        accessoryNameE = accessory.NameE,
                        accessoriePrice = accessory.Price,

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
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        public dynamic GetAccessoriesByPurchaseOrderId(int purchaseOrderId)
        {

            var accessories = db.PurchaseOrder_Accessories.Where(e => e.PurchaseOrder_Id == purchaseOrderId).Select(s => new
            {
                accessoryId = s.Accessory.Id,
                accessoryNameA = s.Accessory.NameA,
                accessoryNameE = s.Accessory.NameE,
                accessoryPrice = s.Accessory.Price

            }).ToList();
            return accessories;

        }

        public dynamic PostAccessory(string accessoryNameA, string accessoryNameE, float price)
        {
            db.Accessories.Add(new Accessory
            {
                NameA = accessoryNameA,
                NameE = accessoryNameE,
                Price = price,


            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
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
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
        public dynamic PostPurchaseOrderAccesssories(int purchaseOrderId, [FromBody] List<int> accessoriesIDs)
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
