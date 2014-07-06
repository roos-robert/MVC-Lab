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
        // GET: /Birthday/
        public ActionResult Index()
        {
            return View("Index");
        }

        [HttpPost, ActionName("Index")]
        public ActionResult Index_POST()
        {
            var model = new Birthday
            {
                Name = Request.Form["name"],
                Birthdate = DateTime.Parse(Request.Form["birthdate"])
            };

            return View("UpcomingBirthday", model);
        }
	}
}