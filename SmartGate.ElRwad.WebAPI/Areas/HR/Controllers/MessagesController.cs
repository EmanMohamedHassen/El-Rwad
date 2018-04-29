using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class MessagesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic getAllMessages()
        {
            var messages = db.Messages.Select(s => new
            {
                messageId = s.Id,
                messageSubject = s.Subject,
                message = s.Message1,
                fromUserId = s.FromUserId,
                toUserId = s.ToUserId,
                filePath = s.FilePath

            }).ToList();
            return messages;
        }
        [HttpGet]
        public dynamic GetMessageById(int messageId)
        {
            try
            {
                var message = db.Messages.Where(e => e.Id == messageId).FirstOrDefault();
                if (message != null)
                {
                    return new
                    {
                        messageSubject = message.Subject,
                        message = message.Message1,
                        fromUserId = message.FromUserId,
                        toUserId = message.ToUserId,
                        filePath = message.FilePath
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

        [HttpPost]

        public dynamic PostMessage(string messageSubject, string message, int fromUserId, int toUserId, string filePath)
        {
            var messagee = db.Messages.Add(new Message
            {
                Subject = messageSubject,
                Message1 = message,
                FromUserId = fromUserId,
                ToUserId = toUserId,
                FilePath = filePath
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                messageId = messagee.Id
            };
        }


        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutMessage(int messageId, string messageSubject, string message, int fromUserId, int toUserId, string filePath)
        {
            var messagee = db.Messages.Find(messageId);
            messagee.Subject = messageSubject;
            messagee.Message1 = message;
            messagee.FromUserId = fromUserId;
            messagee.ToUserId = toUserId;
            messagee.FilePath = filePath;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteMessage(int messageId)
        {
            var message = db.Messages.Where(s => s.Id == messageId).FirstOrDefault();
            db.Messages.Remove(message);

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

    }
}
