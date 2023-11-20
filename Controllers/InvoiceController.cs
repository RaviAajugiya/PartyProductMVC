using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{

    public class InvoiceController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        // GET: Invoice
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            ViewBag.PartyName = (from assignParty in Db.AssignParty
                                 join party in Db.Party on assignParty.PartyId equals party.PartyId
                                 select new
                                 {
                                     partyName = party.PartyName
                                 }).Distinct();
            return View();
        }

        public ActionResult GetProduct(string partyName)
        {
            var products = (
                from assignParty in Db.AssignParty
                join product in Db.Product on assignParty.ProductId equals product.ProductId
                join party in Db.Party on assignParty.PartyId equals party.PartyId
                join productRate in Db.ProductRate on assignParty.ProductId equals productRate.ProductId
                where party.PartyName == partyName
                select new SelectListItem()
                {
                    Value = product.ProductName,
                    Text = product.ProductName
                }
            ).ToList();

            return Json(products, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetProductRate(string productName)
        {
            var Rate = (
                from productRate in Db.ProductRate
                join product in Db.Product on productRate.ProductId equals product.ProductId
                where product.ProductName == productName
                orderby productRate.DateOfRate descending
                select new
                {
                    Rate = productRate.Rate
                }
                ).First();

            return Json(Rate, JsonRequestBehavior.AllowGet);

        }

        public ActionResult AddInvoice(Invoice invoice)
        {
            Db.Invoice.Add(invoice);
            Db.SaveChanges();
            return Json(new { });
        }
    }
}
