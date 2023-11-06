using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class PartyController : Controller
    {
        // GET: Party
        public ActionResult Index()
        {
            return View();
        }
    }
}