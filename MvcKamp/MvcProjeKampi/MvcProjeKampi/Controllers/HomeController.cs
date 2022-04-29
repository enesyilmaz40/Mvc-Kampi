using BusinessLayer.Concrete;
using DataAccessLayer;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    
    public class HomeController : Controller
    {
        Context c = new Context();
      
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
          var headingCount = c.Headings.Count(x=>x.HeadingStatus==true);
            var writerCount = c.Writers.Count(x=>x.WriterStatus==true);
            var contentCount = c.Contents.Count(x=>x.ContentStatus==true);

            ViewBag.HeadingCount = headingCount;
            ViewBag.WriterCount = writerCount;
            ViewBag.ContentCount = contentCount;
            return View();
        }
    }
}