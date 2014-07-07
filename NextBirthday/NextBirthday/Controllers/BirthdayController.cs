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
            throw new NotImplementedException();
        }

        // GET: /Birthday/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: /Birthday/Create
        [HttpPost]
        public ActionResult Create(Birthday birthday)
        {
            // Checking that correct values has been entered, and that the birthdate acctually is in the past.
            if (ModelState.IsValid && birthday.Birthdate < DateTime.Today)
            {
                return View("Create", birthday);
            }

            ModelState.AddModelError("Birthdate", "Your birthdate can't possibly be a date that has not passed!");
            return View("Index", birthday);
        }
	}
}