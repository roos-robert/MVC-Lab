using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloAjax.Controllers
{
    public class HelloController : Controller
    {
        //
        // GET: /Hello/
        public ActionResult Index()
        {
            return View("Index");
        }

        //// POST: /Hello/
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Index(string greeting)
        //{
        //    ViewData.Model = greeting;
        //    return View("Index");
        //}

        // POST: /HelloAjax/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HelloAjax(string greeting)
        {
            if(Request.IsAjaxRequest())
            {
                return Content("Your greeting: " + greeting);
            }

            return View("Index", greeting);
        }
	}
}