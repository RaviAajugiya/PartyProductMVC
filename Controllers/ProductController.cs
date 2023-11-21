using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        protected override void Dispose(bool disposing)
        {
            Db.Dispose();
        }


        public ActionResult Index()
        {
            var Product = Db.Product;
            return View(Product);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ProductAdd()
        {
            return View("ProductAddEdit", new Product { ProductId = 0 });
        }

        [Authorize(Roles = "Admin")]
        public ActionResult ProductEdit(int? id)
        {
            var ProductEdit = Db.Product.Single(e => e.ProductId == id);
            return View("ProductAddEdit", ProductEdit);
        }

        [HttpPost]

        public ActionResult SaveProduct([Bind(Include = "ProductName,ProductId")] Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (product.ProductId == 0)
                    {
                        Db.Product.Add(product);
                    }
                    else
                    {
                        var ProductEdit = Db.Product.SingleOrDefault(p => p.ProductId == product.ProductId);
                        ProductEdit.ProductName = product.ProductName;
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
            return View("ProductAddEdit");
        }

        public ActionResult Delete(int id)
        {
            Db.Product.Remove(Db.Product.Find(id));
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}