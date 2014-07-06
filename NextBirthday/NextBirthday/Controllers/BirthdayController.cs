using NextBirthday.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NextBirthday.Controllers
{
    public class BirthdayController : Controller
    {
        //
        // GET: /Birthday/Index
        public ActionResult Index()
        {
            return View("Index");
        }

        // POST: /Birthday/Index
        [HttpPost]
        public ActionResult Index(Birthday birthday)
        {
            if (ModelState.IsValid)
            {
                return View("UpcomingBirthday", birthday);
            }

            return View("Index", birthday);
        }
	}
}