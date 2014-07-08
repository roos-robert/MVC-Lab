using NextBirthday.Models;
using NextBirthday.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace NextBirthday.Controllers
{
    public class BirthdayController : Controller
    {
        private XMLRepository _repository = new XMLRepository();

        //
        // GET: /Birthday/Index
        public ActionResult Index()
        {
            return View("Index", _repository.GetBirthdays());
        }

        // GET: /Birthday/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: /Birthday/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Birthday birthday)
        {
            // Checking that correct values has been entered, and that the birthdate acctually is in the past.
            if (ModelState.IsValid && birthday.Birthdate < DateTime.Today)
            {
                _repository.InsertBirthday(birthday);
                _repository.Save();
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("Birthdate", "Your birthdate can't possibly be a date that has not passed!");
            return View("Create", birthday);
        }
	}
}