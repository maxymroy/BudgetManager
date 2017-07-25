using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManagementApp.Controllers
{
    public class SuitsController : Controller
    {
        // GET: Suit
        public ActionResult Index()
        {
            return View();
        }
    }
}