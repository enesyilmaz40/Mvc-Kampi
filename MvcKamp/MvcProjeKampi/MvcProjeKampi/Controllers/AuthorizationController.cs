using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: Authorization

        AdminManager am = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = am.GetList();
            return View(adminValues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAddBL(p);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateAdmin(int id)
        {
            var adminValue = am.GetByID(id);
            return View(adminValue);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}