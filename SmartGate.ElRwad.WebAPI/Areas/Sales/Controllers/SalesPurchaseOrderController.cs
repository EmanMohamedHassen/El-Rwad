using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.Sales.Controllers
{
    public class SalesPurchaseOrderController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        public dynamic GetAllSalesPurchaseOrders()
        {
            var purchaseorders = db.Sales_PurchaseOrder.Select(s => new
            {
                purchaseorderID = s.Id,
                userID = s.User_id,
                username = s.User.User_Name,
                date = s.Date,
                buyerName = s.Buyer_Name,
                adress = s.Adress,
                cityId = s.City_Id,
                cityName = s.City.Name_A,
                regionId = s.Region_Id,
                regionName = s.Region.NameAr,
                mobNumber = s.Mob_Number,
                ssn = s.SSN,
                brandId = s.Brand_Id,
                brandName = s.Brand.NameAr,
                modelId = s.Model_Id,
                modelName = s.Model.NameAr,
                category = s.Category_Id,
                catgoryName = s.CarsCategory.NameAr,
                colorid = s.Color_Id,
                colorName = s.Color.NameAr,
                internalColor = s.Internal_Color,
                carstatus = s.CarStatus,
                price = s.Price,
                haveInsurance = s.HaveInsurance,
                insurcompany = s.InsurCom_Id,
                insurcompanyName = s.InsuranceCompany.NameA,
                totalPrice = s.Total_Price,
                depoist = s.Deposit,
                remaining = s.Remaining,
                paymentMethod = s.Payment_Method,
                bankId = s.Bank_Id,
                bankName = s.Bank.NameA

            }).ToList();
            return purchaseorders;
        }


        public dynamic GetSalesPurchaseOrderById(int purchaseorderId)
        {
            try
            {
                var purchaseorder1 = db.Sales_PurchaseOrder.Where(e => e.Id == purchaseorderId).Select(purchaseorder => new
                {

                    purchaseorderID = purchaseorder.Id,
                    userID = purchaseorder.User_id,
                    username = purchaseorder.User.User_Name,
                    date = purchaseorder.Date,
                    buyerName = purchaseorder.Buyer_Name,
                    adress = purchaseorder.Adress,
                    cityId = purchaseorder.City_Id,
                    cityName = purchaseorder.City.Name_A,
                    regionId = purchaseorder.Region_Id,
                    regionName = purchaseorder.Region.NameAr,
                    mobNumber = purchaseorder.Mob_Number,
                    ssn = purchaseorder.SSN,
                    brandId = purchaseorder.Brand_Id,
                    brandName = purchaseorder.Brand.NameAr,
                    modelId = purchaseorder.Model_Id,
                    modelName = purchaseorder.Model.NameAr,
                    category = purchaseorder.Category_Id,
                    catgoryName = purchaseorder.CarsCategory.NameAr,
                    colorid = purchaseorder.Color_Id,
                    colorName = purchaseorder.Color.NameAr,
                    internalColor = purchaseorder.Internal_Color,
                    carstatus = purchaseorder.CarStatus,
                    price = purchaseorder.Price,
                    haveInsurance = purchaseorder.HaveInsurance,
                    insurcompany = purchaseorder.InsurCom_Id,
                    insurcompanyName = purchaseorder.InsuranceCompany.NameA,
                    totalPrice = purchaseorder.Total_Price,
                    depoist = purchaseorder.Deposit,
                    remaining = purchaseorder.Remaining,
                    paymentMethod = purchaseorder.Payment_Method,
                    bankId = purchaseorder.Bank_Id,
                    bankName = purchaseorder.Bank.NameA,
                    isApproval = purchaseorder.IsApproval,
                    refusalReasons = purchaseorder.RefusalReasons


                }).ToList();
                return purchaseorder1;

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

        public dynamic PostSalesPurchaseOrder(int userid, DateTime date, string buyerName, string adress, int cityId, int regionId,
            int mobNumber, int ssn, int brandId, int modelId, int categoryId, int colorId, string internalcolor,
            bool carStatues, float price, bool haveInsurance, int insurcompanyId)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Add(new Sales_PurchaseOrder
            {
                User_id = userid,
                Date = date,
                Buyer_Name = buyerName,
                Adress = adress,
                City_Id = cityId,
                Region_Id = regionId,
                Mob_Number = mobNumber,
                SSN = ssn,
                Brand_Id = brandId,
                Model_Id = modelId,
                Category_Id = categoryId,
                Color_Id = colorId,
                Internal_Color = internalcolor,
                CarStatus = carStatues,
                Price = price,
                HaveInsurance = haveInsurance,
                InsurCom_Id = insurcompanyId,
                IsApproval = null,
                RefusalReasons = null

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                id = purchaseorder.Id
            };
        }


        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrder(int purchaseOrderId, int userid, DateTime date, string buyerName, string adress, int cityId, int regionId,
            int mobNumber, int ssn, bool paymentMethod, int bankId)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Find(purchaseOrderId);
            purchaseorder.User_id = userid;
            purchaseorder.Date = date;
            purchaseorder.Buyer_Name = buyerName;
            purchaseorder.Adress = adress;
            purchaseorder.City_Id = cityId;
            purchaseorder.Region_Id = regionId;
            purchaseorder.Mob_Number = mobNumber;
            purchaseorder.SSN = ssn;
            purchaseorder.Payment_Method = paymentMethod;
            purchaseorder.Bank_Id = bankId;
            purchaseorder.IsApproval = null;
            purchaseorder.RefusalReasons = null;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteSalesPurchaseOrder(int purchaseOrderId)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Where(s => s.Id == purchaseOrderId).FirstOrDefault();
            db.Sales_PurchaseOrder.Remove(purchaseorder);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        //special Gets and puts



        public dynamic GetSalesPurchaseOrdersByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate).Select(s => new

                {
                    purchaseorderID = s.Id,
                    userID = s.User_id,
                    username = s.User.User_Name,
                    date = s.Date,
                    buyerName = s.Buyer_Name,
                    adress = s.Adress,
                    cityId = s.City_Id,
                    cityName = s.City.Name_A,
                    regionId = s.Region_Id,
                    regionName = s.Region.NameAr,
                    mobNumber = s.Mob_Number,
                    ssn = s.SSN,
                    brandId = s.Brand_Id,
                    brandName = s.Brand.NameAr,
                    modelId = s.Model_Id,
                    modelName = s.Model.NameAr,
                    category = s.Category_Id,
                    catgoryName = s.CarsCategory.NameAr,
                    colorid = s.Color_Id,
                    colorName = s.Color.NameAr,
                    internalColor = s.Internal_Color,
                    carstatus = s.CarStatus,
                    price = s.Price,
                    haveInsurance = s.HaveInsurance,
                    insurcompany = s.InsurCom_Id,
                    insurcompanyName = s.InsuranceCompany.NameA,
                    totalPrice = s.Total_Price,
                    depoist = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA

                }).ToList();

                return purchaseorders;


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
        public dynamic GetSalesPurchaseOrdersByDateTakedAction(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate && e.IsApproval != null).Select(s => new

                {
                    purchaseorderID = s.Id,
                    userID = s.User_id,
                    username = s.User.User_Name,
                    date = s.Date,
                    buyerName = s.Buyer_Name,
                    adress = s.Adress,
                    cityId = s.City_Id,
                    cityName = s.City.Name_A,
                    regionId = s.Region_Id,
                    regionName = s.Region.NameAr,
                    mobNumber = s.Mob_Number,
                    ssn = s.SSN,
                    brandId = s.Brand_Id,
                    brandName = s.Brand.NameAr,
                    modelId = s.Model_Id,
                    modelName = s.Model.NameAr,
                    category = s.Category_Id,
                    catgoryName = s.CarsCategory.NameAr,
                    colorid = s.Color_Id,
                    colorName = s.Color.NameAr,
                    internalColor = s.Internal_Color,
                    carstatus = s.CarStatus,
                    price = s.Price,
                    haveInsurance = s.HaveInsurance,
                    insurcompany = s.InsurCom_Id,
                    insurcompanyName = s.InsuranceCompany.NameA,
                    totalPrice = s.Total_Price,
                    depoist = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA,
                    isApproval = s.IsApproval,
                    refusalReasons = s.RefusalReasons

                }).ToList();

                return purchaseorders;


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


        public dynamic GetSalesPurchaseOrdersBySalesEmployeeAndDateTakedAction(DateTime fromDate, DateTime toDate, int empId)
        {
            try
            {

                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.User_id == empId && e.Date >= fromDate && e.Date <= toDate && e.IsApproval != null).Select(s => new
                {
                    purchaseorderID = s.Id,
                    userID = s.User_id,
                    username = s.User.User_Name,
                    date = s.Date,
                    buyerName = s.Buyer_Name,
                    adress = s.Adress,
                    cityId = s.City_Id,
                    cityName = s.City.Name_A,
                    regionId = s.Region_Id,
                    regionName = s.Region.NameAr,
                    mobNumber = s.Mob_Number,
                    ssn = s.SSN,
                    brandId = s.Brand_Id,
                    brandName = s.Brand.NameAr,
                    modelId = s.Model_Id,
                    modelName = s.Model.NameAr,
                    category = s.Category_Id,
                    catgoryName = s.CarsCategory.NameAr,
                    colorid = s.Color_Id,
                    colorName = s.Color.NameAr,
                    internalColor = s.Internal_Color,
                    carstatus = s.CarStatus,
                    price = s.Price,
                    haveInsurance = s.HaveInsurance,
                    insurcompany = s.InsurCom_Id,
                    insurcompanyName = s.InsuranceCompany.NameA,
                    totalPrice = s.Total_Price,
                    depoist = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA,
                    isApproval = s.IsApproval,
                    refusalReasons = s.RefusalReasons

                }).ToList();

                return purchaseorders;

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
        public dynamic GetSalesPurchaseOrdersAcceptedByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate && e.IsApproval == true).Select(s => new

                {
                    purchaseorderID = s.Id,
                    userID = s.User_id,
                    username = s.User.User_Name,
                    date = s.Date,
                    buyerName = s.Buyer_Name,
                    adress = s.Adress,
                    cityId = s.City_Id,
                    cityName = s.City.Name_A,
                    regionId = s.Region_Id,
                    regionName = s.Region.NameAr,
                    mobNumber = s.Mob_Number,
                    ssn = s.SSN,
                    brandId = s.Brand_Id,
                    brandName = s.Brand.NameAr,
                    modelId = s.Model_Id,
                    modelName = s.Model.NameAr,
                    category = s.Category_Id,
                    catgoryName = s.CarsCategory.NameAr,
                    colorid = s.Color_Id,
                    colorName = s.Color.NameAr,
                    internalColor = s.Internal_Color,
                    carstatus = s.CarStatus,
                    price = s.Price,
                    haveInsurance = s.HaveInsurance,
                    insurcompany = s.InsurCom_Id,
                    insurcompanyName = s.InsuranceCompany.NameA,
                    totalPrice = s.Total_Price,
                    depoist = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA

                }).ToList();

                return purchaseorders;


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
        public dynamic GetSalesPurchaseOrdersRefusedByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate && e.IsApproval == false).Select(s => new

                {
                    purchaseorderID = s.Id,
                    userID = s.User_id,
                    username = s.User.User_Name,
                    date = s.Date,
                    buyerName = s.Buyer_Name,
                    adress = s.Adress,
                    cityId = s.City_Id,
                    cityName = s.City.Name_A,
                    regionId = s.Region_Id,
                    regionName = s.Region.NameAr,
                    mobNumber = s.Mob_Number,
                    ssn = s.SSN,
                    brandId = s.Brand_Id,
                    brandName = s.Brand.NameAr,
                    modelId = s.Model_Id,
                    modelName = s.Model.NameAr,
                    category = s.Category_Id,
                    catgoryName = s.CarsCategory.NameAr,
                    colorid = s.Color_Id,
                    colorName = s.Color.NameAr,
                    internalColor = s.Internal_Color,
                    carstatus = s.CarStatus,
                    price = s.Price,
                    haveInsurance = s.HaveInsurance,
                    insurcompany = s.InsurCom_Id,
                    insurcompanyName = s.InsuranceCompany.NameA,
                    totalPrice = s.Total_Price,
                    depoist = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA

                }).ToList();

                return purchaseorders;


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

        public dynamic GetSalesPurchaseOrdersNotTakedActionsdByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate).Select(s => new

                {
                    purchaseorderID = s.Id,
                    userID = s.User_id,
                    username = s.User.User_Name,
                    date = s.Date,
                    buyerName = s.Buyer_Name,
                    adress = s.Adress,
                    cityId = s.City_Id,
                    cityName = s.City.Name_A,
                    regionId = s.Region_Id,
                    regionName = s.Region.NameAr,
                    mobNumber = s.Mob_Number,
                    ssn = s.SSN,
                    brandId = s.Brand_Id,
                    brandName = s.Brand.NameAr,
                    modelId = s.Model_Id,
                    modelName = s.Model.NameAr,
                    category = s.Category_Id,
                    catgoryName = s.CarsCategory.NameAr,
                    colorid = s.Color_Id,
                    colorName = s.Color.NameAr,
                    internalColor = s.Internal_Color,
                    carstatus = s.CarStatus,
                    price = s.Price,
                    haveInsurance = s.HaveInsurance,
                    insurcompany = s.InsurCom_Id,
                    insurcompanyName = s.InsuranceCompany.NameA,
                    totalPrice = s.Total_Price,
                    depoist = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA

                }).ToList();

                return purchaseorders;


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

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrderPaymentMethod(int purchaseOrderId, float totalPrice, float deposit,
            float remaining, bool paymentMethod, int bankId)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Find(purchaseOrderId);
            purchaseorder.Total_Price = totalPrice;
            purchaseorder.Deposit = deposit;
            purchaseorder.Remaining = remaining;
            purchaseorder.Payment_Method = paymentMethod;
            purchaseorder.Bank_Id = bankId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrderToAccepted(int purchaseorderId)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Find(purchaseorderId);
            purchaseorder.IsApproval = true;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };


        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSalesPurchaseOrderToRefused(int purchaseorderId, string refusalReasons)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Find(purchaseorderId);
            purchaseorder.IsApproval = false;
            purchaseorder.RefusalReasons = refusalReasons;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };


        }

    }
}
