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
        public ActionResult DisplayCustomer()
        {
            Customer customer = new Customer();
            customer.Id = 404;
            customer.CustomerCode = "AD";
            customer.Amount = 101.90;
            return View(customer);
        }
	}
}