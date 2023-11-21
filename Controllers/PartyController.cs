using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class PartyController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
        }

        // GET: Partys
        public ActionResult Index()
        {
            var party = Db.Party;
            return View(party);
        }


        [Authorize(Roles = "Admin")]
        public ActionResult PartyAdd()
        {
            return View("PartyAddEdit", new Party { PartyId = 0 });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult PartyEdit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var PartyEdit = Db.Party.First(e => e.PartyId == id);
            if (PartyEdit == null)
            {
                return HttpNotFound();
            }

            return View("PartyAddEdit", PartyEdit);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult SaveParty([Bind(Include = "PartyName,PartyId")] Party party)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (party.PartyId == 0)
                    {
                        Db.Party.Add(party);
                    }
                    else
                    {
                        var PartyEdit = Db.Party.SingleOrDefault(p => p.PartyId == party.PartyId);
                        PartyEdit.PartyName = party.PartyName;
                    }
                    Db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DbUpdateException ex)
                {
                    var sqlException = ex.GetBaseException() as SqlException;

                    if (sqlException != null && sqlException.Number == 2601)
                    {
                        ModelState.AddModelError("CustomErrorKey", "The value for PartyName must be unique.");
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return View("PartyAddEdit");
        }

        //[Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            Db.Party.Remove(Db.Party.Find(id));
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


