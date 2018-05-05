using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.BLL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class BanksController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        public dynamic GetAllBanks()
        {
            return BankManager.Instance.GetAllBanks();
        }

        [HttpGet]
        public dynamic GetBankById(int bankId)
        {
            return BankManager.Instance.GetBankById(bankId);
        }

        public dynamic PostBank(string bankNameA, string bankNameE)
        {
            BankVM B = new BankVM();
            B.NameA = bankNameA;
            B.NameE = bankNameE;
        
            return BankManager.Instance.PostBank(B);
        }


        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutBank(int bankId, string bankNameA, string bankNameE)
        {
            BankVM B = new BankVM();
            B.Id = bankId;
            B.NameA = bankNameA;
            B.NameE = bankNameE;
            return BankManager.Instance.PutBank(B);
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteBank(int bankId)
        {
            return BankManager.Instance.DeleteBank(bankId);
        }

    }
}
