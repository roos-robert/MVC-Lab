using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject2.Models;

namespace TestProject2.Controllers
{
    public class JsonController : Controller
    {
        //
        // GET: /Json/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getJson()
        {
            Customer obj = new Customer();
            obj.CustomerCode = "c001";
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
	}
}