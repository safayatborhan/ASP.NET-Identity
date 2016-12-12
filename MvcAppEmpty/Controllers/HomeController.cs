using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppEmpty.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            string name = User.Identity.Name;    //From that name claims, we have added in AuthContoller Login method
            var browser = Request.Browser;
            ViewBag.message = "Hello " + name + ". You have requested from " + browser.Browser;
            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}