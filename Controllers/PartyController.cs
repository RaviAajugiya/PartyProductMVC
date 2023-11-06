using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class PartyController : Controller
    {
        private ApplicationDbContext Db;

        public PartyController()
        {
            Db = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
        }

        // GET: Party
        public ActionResult Index()
        {
            var party = Db.Party;
            return View(party);
        }

        [Route]
        public ActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var partyEdit = Db.Party.Find(Id);
            if (partyEdit == null)
            {
                return HttpNotFound();
            }
            return View(partyEdit);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}