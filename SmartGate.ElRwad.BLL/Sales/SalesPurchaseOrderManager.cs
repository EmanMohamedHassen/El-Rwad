using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.BLL.Sales
{
    public class SalesPurchaseOrderManager
    {
        private static SalesPurchaseOrderManager instance;
        public static SalesPurchaseOrderManager Instance { get { return instance; } }

        static SalesPurchaseOrderManager()
        {
            instance = new SalesPurchaseOrderManager();
        }
        private elRwadEntities db = new elRwadEntities();
        public dynamic GetAllSalesPurchaseOrders()
        {
            try
            {
                var purchaseorder1 = db.Sales_PurchaseOrder.Select(purchaseorder => new SalesPurchaseOrderVM
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
                    deposit = purchaseorder.Deposit,
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
                return ex.Message;
            }
        }
        public dynamic GetSalesPurchaseOrderById(int purchaseorderId)
        {
            try
            {
                var purchaseorder1 = db.Sales_PurchaseOrder.Where(e => e.Id == purchaseorderId).Select(purchaseorder => new SalesPurchaseOrderVM
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
                    deposit = purchaseorder.Deposit,
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
                return ex.Message;
            }
        }

        public dynamic PostSalesPurchaseOrder(PostSalesPurchaseOrderVM p)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Add(new Sales_PurchaseOrder
            {
                User_id = p.userID,
                Date = p.date,
                Buyer_Name = p.buyerName,
                Adress = p.adress,
                City_Id = p.cityId,
                Region_Id = p.regionId,
                Mob_Number = p.mobNumber,
                SSN = p.ssn,
                Brand_Id = p.brandId,
                Model_Id = p.modelId,
                Category_Id = p.category,
                Color_Id = p.colorid,
                Internal_Color = p.internalColor,
                CarStatus = p.carstatus,
                Price = p.price,
                HaveInsurance = p.haveInsurance,
                InsurCom_Id = p.insurcompany,
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

        
        public dynamic PutSalesPurchaseOrder(postSalesPurchaseOrderVM p)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Find(p.purchaseorderID);
            purchaseorder.User_id = p.userID;
            purchaseorder.Date = p.date;
            purchaseorder.Buyer_Name = p.buyerName;
            purchaseorder.Adress = p.adress;
            purchaseorder.City_Id = p.cityId;
            purchaseorder.Region_Id = p.regionId;
            purchaseorder.Mob_Number = p.mobNumber;
            purchaseorder.SSN = p.ssn;
            purchaseorder.Payment_Method = p.paymentMethod;
            purchaseorder.Bank_Id = p.bankId;
            purchaseorder.IsApproval = null;
            purchaseorder.RefusalReasons = null;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        
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
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate).Select(s => new SalesPurchaseOrderVM

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
                    deposit = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA

                }).ToList();

                return purchaseorders;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public dynamic GetSalesPurchaseOrdersByDateTakedAction(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate && e.IsApproval != null).Select(s => new SalesPurchaseOrderVM

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
                    deposit = s.Deposit,
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
                return ex.Message;
            }
        }

        public dynamic GetSalesPurchaseOrdersBySalesEmployeeAndDateTakedAction(DateTime fromDate, DateTime toDate, int empId)
        {
            try
            {

                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.User_id == empId && e.Date >= fromDate && e.Date <= toDate && e.IsApproval != null).Select(s => new SalesPurchaseOrderVM
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
                    deposit = s.Deposit,
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
                return ex.Message;
            }

        }
        public dynamic GetSalesPurchaseOrdersAcceptedByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate && e.IsApproval == true).Select(s => new SalesPurchaseOrderVM
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
                    deposit = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA

                }).ToList();
                return purchaseorders;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        public dynamic GetSalesPurchaseOrdersRefusedByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate && e.IsApproval == false).Select(s => new SalesPurchaseOrderVM
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
                    deposit = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA
                }).ToList();

                return purchaseorders;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public dynamic GetSalesPurchaseOrdersNotTakedActionsdByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var purchaseorders = db.Sales_PurchaseOrder.Where(e => e.Date >= fromDate && e.Date <= toDate).Select(s => new SalesPurchaseOrderVM
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
                    deposit = s.Deposit,
                    remaining = s.Remaining,
                    paymentMethod = s.Payment_Method,
                    bankId = s.Bank_Id,
                    bankName = s.Bank.NameA

                }).ToList();
                return purchaseorders;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public dynamic PutSalesPurchaseOrderPaymentMethod(PutSalesPurchaseOrderVM p)
        {
            var purchaseorder = db.Sales_PurchaseOrder.Find(p.purchaseorderID);
            purchaseorder.Total_Price = p.totalPrice;
            purchaseorder.Deposit = p.deposit;
            purchaseorder.Remaining = p.remaining;
            purchaseorder.Payment_Method = p.paymentMethod;
            purchaseorder.Bank_Id = p.bankId;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

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
