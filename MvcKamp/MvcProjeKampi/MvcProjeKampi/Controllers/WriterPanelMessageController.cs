using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class WriterPanelMessageController : Controller
    {
      
        MessageValidator messagevalidator = new MessageValidator();
        ContactManager cm = new ContactManager(new EfContactDal());
        MessageManager mm = new MessageManager(new EfMessageDal());
    
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];
            var messageListIn = mm.GetListInbox();
            return View(messageListIn);
        }
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];
            var messageListSend = mm.GetListSendbox();
            return View(messageListSend);
        }
        public PartialViewResult MessageListMenu()
        {
            var contact = cm.GetList().Count();
            ViewBag.contact = contact;

            var sendMail = mm.GetListSendbox().Count();
            ViewBag.sendMail = sendMail;

            var receiverMail = mm.GetListInbox().Count();
            ViewBag.receiverMail = receiverMail;

            var draftMail = mm.GetListSendbox().Where(m => m.IsDraft == true).Count();
            ViewBag.draftMail = draftMail;

            var readMessage = mm.GetListInbox().Where(m => m.IsRead == true).Count();
            ViewBag.readMessage = readMessage;

            var unreadMessage = mm.GetAllRead().Count();
            ViewBag.unreadMessage = unreadMessage;
            return PartialView();
        }
        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        public ActionResult GetSendBoxMessageDetails(int id)
        {
            var values = mm.GetByID(id);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {

            return View();

        }
        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
              
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                mm.MessageAddBL(p);
                return RedirectToAction("SendBox");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}