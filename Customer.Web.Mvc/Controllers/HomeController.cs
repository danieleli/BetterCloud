using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Customer.Web.Mvc.Models;

namespace Customer.Web.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var db = new CustomerDb();
            var models = db.Customers;
            return View(models);
        }
    }
}