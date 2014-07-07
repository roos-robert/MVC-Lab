using NextBirthday.Models;
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
        //
        // GET: /Birthday/Index
        public ActionResult Index()
        {
            var path = Server.MapPath("~/App_Data/birthdates.xml");
            var doc = XDocument.Load(path);
            var model = (from birthdate in doc.Descendants("birthdate")
                         select new Birthday
                         {
                             Name = birthdate.Element("name").Value,
                             Birthdate = DateTime.Parse(birthdate.Element("date").Value)
                         }).ToList();

            return View("Index", model);
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
                var path = Server.MapPath("~/App_Data/birthdates.xml");
                var doc = XDocument.Load(path);

                // Creating the new element to be inserted to the XML-file.
                var element = new XElement("birthdate",
                    new XElement("name", birthday.Name),
                    new XElement("date", birthday.Birthdate));

                // Adding to structure (end of), and saving to file.
                doc.Root.Add(element);
                doc.Save(path);

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("Birthdate", "Your birthdate can't possibly be a date that has not passed!");
            return View("Create", birthday);
        }
	}
}