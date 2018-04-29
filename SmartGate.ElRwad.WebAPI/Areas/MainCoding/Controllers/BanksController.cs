using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class BanksController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        public dynamic GetAllBanks()
        {
            var banks = db.Banks.Select(s => new
            {
                bankId = s.Id,
                bankNameA = s.NameA,
                bankNameE = s.NameE
            }).ToList();
            return banks;
        }

        [HttpGet]
        public dynamic GetBankById(int bankId)
        {
            try
            {
                var bank = db.Banks.Where(e => e.Id == bankId).FirstOrDefault();
                if (bank != null)
                {
                    return new
                    {
                        bankNameA = bank.NameA,
                        bankNameE = bank.NameE
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

        public dynamic PostBank(string bankNameA, string bankNameE)
        {
            db.Banks.Add(new Bank
            {
                NameA = bankNameA,
                NameE = bankNameE

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutBank(int bankId, string bankNameA, string bankNameE)
        {
            var bank = db.Banks.Find(bankId);

            bank.NameA = bankNameA;
            bank.NameE = bankNameE;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
