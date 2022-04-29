using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetAllRead()
        {
            return _messageDal.List(m => m.ReceiverMail == "admin@gmail.com").Where(m => m.IsRead == false).ToList();
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "gizem@gmail.com");
        }

        public List<Message> GetListInbox(string receiver)
        {
            return _messageDal.List(m => m.ReceiverMail == receiver);
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "gizem@gmail.com");
        }

        public List<Message> GetListSendBox(string sender)
        {
            return _messageDal.List(x => x.SenderMail == sender);
        }

        public List<Message> IsDraft()
        {
            return _messageDal.List(m => m.IsDraft == true);
        }

        public void MessageAddBL(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message p)
        {
            _messageDal.Delete(p);
        }

        public void MessageUpdate(Message p)
        {
            _messageDal.Update(p);
        }

    }
}
