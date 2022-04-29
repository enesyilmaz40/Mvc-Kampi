using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class MessageController : Controller
    {
        MessageValidator messagevalidator = new MessageValidator();
        MessageManager mm = new MessageManager(new EfMessageDal());

        [Authorize]
        public ActionResult Inbox(string p)
        {

            var messageListIn = mm.GetListInbox(p);

            return View(messageListIn);
        }
        public ActionResult SendBox(string p)
        {
            var messageListSend = mm.GetListSendBox(p);
            return View(messageListSend);
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
            ValidationResult results = messagevalidator.Validate(p);

            if (results.IsValid)
            {
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
        public ActionResult Draft()
        {
            var result = mm.IsDraft();
            return View(result);
        }
        public ActionResult GetDraftDetails(int id)
        {
            var result = mm.GetByID(id);
            return View(result);
        }
    }
}