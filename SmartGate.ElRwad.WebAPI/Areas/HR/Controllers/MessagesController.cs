using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.BLL.HR;
namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class MessagesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic getAllMessages()
        {
            return MessageManager.Instance.getAllMessages();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetMessageById(int messageId)
        {
            return MessageManager.Instance.GetMessageById(messageId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageSubject"></param>
        /// <param name="message"></param>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [HttpPost]

        public dynamic PostMessage(MessageVM m)
        {
            return MessageManager.Instance.PostMessage(m);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <param name="messageSubject"></param>
        /// <param name="message"></param>
        /// <param name="fromUserId"></param>
        /// <param name="toUserId"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutMessage(MessageVM m)
        {
            return MessageManager.Instance.PutMessage(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="messageId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteMessage(int messageId)
        {
            return MessageManager.Instance.DeleteMessage(messageId);
        }

    }
}
