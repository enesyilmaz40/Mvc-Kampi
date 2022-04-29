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
    public class IstatistikController : Controller
    {
        Context context = new Context();
        public ActionResult Index()
        {
            //Toplam Kategori Sayısı
            var result =context.Categories.Count();
            //Başlık tablosunda yazılım kategorisine ait başlık sayısı
            var baslikResult = context.Headings.Count(i => i.HeadingName == "Yazılım");
            //Yazar adında a harfi geçen
            var aHarfiResult = context.Writers.Count(i => i.WriterName.Contains("a"));
            //En fazla başlığa sahip kategori sayısı
            var maxHeadingResult = context.Headings.Max(i => i.Category.CategoryName);
            //Kategori tablosunda durumu true ve false olanların sayısal farkı
            var stateResultTrue =context.Categories.Count(i=>i.CategoryStatus==true);
            var stateResultFalse =context.Categories.Count(i=>i.CategoryStatus==false);

            ViewBag.result=result;
            ViewBag.Heading = baslikResult;
            ViewBag.Writer = aHarfiResult;
            ViewBag.HeadingMax = maxHeadingResult;
            ViewBag.StatusFark = (stateResultTrue - stateResultFalse);


            return View();
        }
   
    }
}