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
        private IRepository _repository;

        public BirthdayController()
            : this(new EFRepository())
        {
            // This should be empty.
        }

        public BirthdayController(IRepository repository)
        {
            _repository = repository;
        }

        //
        // GET: /Birthday/
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

        // GET: /Birthday/Edit
        public ActionResult Edit(int Id = 0)
        {
            var birthday = _repository.GetBirthdayById(Id);
            if (birthday == null)
            {
                return View("NotFound");
            }

            return View("Edit", birthday);
        }

        // POST: /Birthday/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Birthday birthday)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repository.UpdateBirthday(birthday);
                    _repository.Save();

                    return View("Saved", birthday);
                }
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "An error occured when trying to update the birthday.");
            }

            return View("Edit", birthday);
        }

        protected override void Dispose(bool disposing)
        {
            _repository.Dispose();
            base.Dispose(disposing);
        }
	}
}