using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetListInbox();
        List<Message> GetListInbox(string receiver);
        List<Message> GetListSendbox();
        List<Message> GetListSendBox(string sender);

        void MessageAddBL(Message message);
        Message GetByID(int id);
        void MessageDelete(Message p);
        void MessageUpdate(Message p);
        List<Message> GetAllRead();
        List<Message> IsDraft();
        
    }
}
