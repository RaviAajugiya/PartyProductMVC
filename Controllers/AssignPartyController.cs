using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.Diagnostics;

namespace PartyProductMVC.Controllers
{
    public class AssignPartyController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
        }

        // GET: AssignParty
        public ActionResult index()
        {
            var data = Db.AssignParty.Include(p => p.Party).Include(p => p.Product).ToList();
            return View(data);
        }

        public ActionResult AssignAdd()
        {
            ViewBag.Parties = Db.Party;
            ViewBag.Products = Db.Product;
            return View("AssignAddEdit", new AssignParty { AssignId = 0 });
        }

        public ActionResult AssignEdit(int? Id)
        {
            ViewBag.Parties = Db.Party;
            ViewBag.Products = Db.Product;
            var assignEdit = Db.AssignParty.First(a => a.AssignId == Id);
            return View("AssignAddEdit", assignEdit);
        }

        public ActionResult AssignSave(AssignParty assignParty)
        {
            if (assignParty.AssignId == 0)
            {
                Db.AssignParty.Add(new AssignParty { PartyId = assignParty.Party.PartyId, ProductId = assignParty.Product.ProductId });
            }
            else
            {
                var assignEdit = Db.AssignParty.Single(a => a.AssignId == assignParty.AssignId);
                assignEdit.PartyId = assignParty.Party.PartyId;
                assignEdit.ProductId = assignParty.Product.ProductId;
            }
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AssignDelete(int Id)
        {
            Db.AssignParty.Remove(Db.AssignParty.Find(Id));
            Db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}