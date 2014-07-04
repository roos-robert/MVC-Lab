using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult FillCustomer()
        {
            return View();
        }

        public ActionResult DisplayCustomer()
        {
            Customer customer = new Customer();
            customer.Id = Convert.ToInt16(Request.Form["CustomerId"]);
            customer.CustomerCode = Request.Form["CustomerCode"];
            customer.Amount = Convert.ToDouble(Request.Form["Amount"]);
            return View(customer);
        }
	}
}