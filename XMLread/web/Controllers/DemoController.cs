using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clibrary;
namespace web.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index_Message()
        {
            var lib_database = new Database();
            var libs = lib_database.ReadLibrary();
            var message = string.Format("已收到{0}筆圖書館的資料<br/><br/>", libs.Count);
            libs.ForEach(x =>
            {
                message += string.Format("圖書館名：{0}<br/>住址:{1}<br/>開館時間：{2}<br/>聯絡電話:{3}<br/>傳真:{4}<br/><br/>", x.name, x.address,x.openTime,x.phone,x.fax);
            });
            return Content(message);
        }
        public ActionResult Index()
        {
            var lib_database = new Database();
            var libs = lib_database.ReadLibrary();
            //var message = string.Format("已收到{0}筆圖書館的資料<br/><br/>", libs.Count);
            //libs.ForEach(x =>
            //{
            //    message += string.Format("圖書館名：{0}<br/>住址:{1}<br/>開館時間：{2}<br/>聯絡電話:{3}<br/>傳真:{4}<br/><br/>", x.name, x.address, x.openTime, x.phone, x.fax);
            //});
            ViewBag.UserName = "Lin";
            ViewBag.libs = libs;
            return View(libs);
        }

    }
}