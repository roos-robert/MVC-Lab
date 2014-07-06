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
            // Checking that correct values has been entered, and that the birthdate acctually is in the past.
            if (ModelState.IsValid && birthday.Birthdate < DateTime.Today)
            {
                return View("UpcomingBirthday", birthday);
            }

            ModelState.AddModelError("Birthdate", "Your birthdate can't possibly be a date that has not passed!");
            return View("Index", birthday);
        }
	}
}