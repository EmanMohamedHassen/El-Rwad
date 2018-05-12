using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL
{
   public class BankManager
    {
        private static BankManager instance;
        public static BankManager Instance { get { return instance; } }

        static BankManager()
        {
            instance = new BankManager();
        }
        private elRwadEntities db = new elRwadEntities();


        public dynamic GetAllBanks()
        {
            List<BankVM> banks = db.Banks.Select(s => new BankVM
            {
                Id = s.Id,
                NameA = s.NameA,
                NameE = s.NameE
            }).ToList();
            return banks;
        }

        public dynamic GetBankById(int bankId)
        {
            try
            {
                var bank = db.Banks.Where(e => e.Id == bankId).FirstOrDefault();
                if (bank != null)
                {
                    return new BankVM
                    {
                        NameA = bank.NameA,
                        NameE = bank.NameE
                    };
                }
                else
                {
                    return new BankVM
                    {
                        Id = 0

                    };
                }
            }
            catch (Exception ex)
            {
                return new
                {
                    Message = ex.Message
                };
            }
        }

        public dynamic PostBank(BankVM B)
        {
            db.Banks.Add(new Bank
            {
                NameA = B.NameA ,
                NameE = B.NameE

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        public dynamic PutBank(BankVM B)
        {
            var bank = db.Banks.Find(B.Id);

            bank.NameA = B.NameA;
            bank.NameE = B.NameA;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        public dynamic DeleteBank(int bankId)
        {
            var bank = db.Banks.Where(s => s.Id == bankId).FirstOrDefault();
            db.Banks.Remove(bank);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
    }
}
