using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class ProductRateController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();
        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
        }
        // GET: ProductRate
        public ActionResult Index()
        {
            var Data = Db.ProductRate.Include(p => p.Product).ToList();
            return View(Data);
        }
        public ActionResult ProductRateAdd()
        {
            ViewBag.Products = Db.Product;
            return View("ProductRateAddEdit", new ProductRate { ProductRateId = 0 });
        }
        public ActionResult ProductRateEdit(int id)
        {
            ViewBag.Products = Db.Product;
            var ProductRateEdit = Db.ProductRate.First(r => r.ProductRateId == id);
            return View("ProductRateAddEdit", ProductRateEdit);
        }
        public ActionResult ProductRateDelete(int id)
        {
            Db.ProductRate.Remove(Db.ProductRate.Find(id));
            Db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult ProductRateSave(ProductRate productRate)
        {
            if (productRate.ProductRateId == 0)
            {
                Db.ProductRate.Add(new ProductRate { ProductId = productRate.Product.ProductId, Rate = productRate.Rate, DateOfRate = productRate.DateOfRate });
            }
            else
            {
                var rateEdit = Db.ProductRate.First(r => r.ProductRateId == productRate.ProductRateId);
                rateEdit.Rate = productRate.Rate;
                rateEdit.DateOfRate = productRate.DateOfRate;
            }
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}