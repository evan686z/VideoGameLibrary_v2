using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoGameLibrary_v2.CustomAttribute;

namespace VideoGameLibrary_v2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [AuthorizeOrRedirectAttribute(Roles = "Site Admin, Video Game Admin")]
        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}