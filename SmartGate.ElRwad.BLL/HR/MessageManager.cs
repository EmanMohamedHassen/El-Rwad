using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL.HR
{
   public class MessageManager
    {
        private static MessageManager instance;
        public static MessageManager Instance { get { return instance; } }
        static MessageManager()
        {
            instance = new MessageManager();
        }

             private elRwadEntities db = new elRwadEntities();

            public dynamic getAllMessages()
            {
                List<MessageVM> messages = db.Messages.Select(s => new MessageVM
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
            public dynamic GetMessageById(int messageId)
            {
                try
                {
                    var message = db.Messages.Where(e => e.Id == messageId).FirstOrDefault();
                    if (message != null)
                    {
                        return new MessageVM
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
                return ex.Message;
                }
            }

            public dynamic PostMessage(MessageVM m)
            {
                var messagee = db.Messages.Add(new Message
                {
                    Subject = m.messageSubject,
                    Message1 = m.message,
                    FromUserId = m.fromUserId,
                    ToUserId = m.toUserId,
                    FilePath = m.filePath
                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    messageId = messagee.Id
                };
            }
            public dynamic PutMessage(MessageVM m)
            {
                var messagee = db.Messages.Find(m.messageId);
                messagee.Subject = m.messageSubject;
                messagee.Message1 = m.message;
                messagee.FromUserId = m.fromUserId;
                messagee.ToUserId = m.toUserId;
                messagee.FilePath = m.filePath;
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
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
