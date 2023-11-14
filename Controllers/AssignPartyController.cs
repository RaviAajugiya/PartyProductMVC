using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class AssignPartyController : Controller
    {
        // GET: AssignParty
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AssignAddEdit()
        {
            return View();
        }
    }
}