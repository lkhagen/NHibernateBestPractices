using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DataObjects.Entities;

namespace ClientAspMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var session = MvcApplication.SessionFactory.GetCurrentSession();
            var customers = session.QueryOver<Customer>().List();

            return View(customers);
        }
    }
}
