using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FocusedFrontendSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult StrongPassword()
        {
            return View();
        }

        public ActionResult AjaxImageUploader ()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult CustomCssHeader()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

    }
}