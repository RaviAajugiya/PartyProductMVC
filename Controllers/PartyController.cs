using PartyProductMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PartyProductMVC.Controllers
{
    public class PartyController : Controller
    {
        //private ApplicationDbContext Db;

        //public PartyController()
        //{
        //    Db = new ApplicationDbContext();
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    Db.Dispose();
        //}

        // GET: Party
        public ActionResult Index()
        {

            //var party = Db.Party;
            return View();
        }
    }
}