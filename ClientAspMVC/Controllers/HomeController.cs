using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientAspMVC.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Test()
        {

            return new JsonResult();
        }
        
        public ActionResult Index()
        {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
