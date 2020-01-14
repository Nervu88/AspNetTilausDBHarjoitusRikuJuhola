using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetTilausDB;

namespace AspNetTilausDB.Controllers
{
    public class TuotteetsController : Controller
    {
        private TilausDBEntities1 db = new TilausDBEntities1();

        // GET: Tuotteets
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
                var tuotteets = db.Tuotteets.Include(t => t.Region);
                return View(tuotteets.ToList());
            }
        }

        // GET: Tuotteets/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuotteet tuotteet = db.Tuotteets.Find(id);
            if (tuotteet == null)
            {
                return HttpNotFound();
            }
            return View(tuotteet);
        }

        // GET: Tuotteets/Create
        public ActionResult Create()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
            }

            List<SelectListItem> regions = new List<SelectListItem>();
            foreach (Region regionid in db.Regions)
            {
                regions.Add(new SelectListItem
                {
                    Value = regionid.RegionShort,
                    Text = regionid.RegionLong + "  " + regionid.RegionShort
                });
            }
            ViewBag.AlkuperaMaa = new SelectList(regions, "Value", "Text");
            return View();
        }

        // POST: Tuotteets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TuoteID,Nimi,Ahinta,ImageLink,VarastoSaldo,AlkuperaMaa")] Tuotteet tuotteet)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
            }

            if (ModelState.IsValid)
            {
                db.Tuotteets.Add(tuotteet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlkuperaMaa = new SelectList(db.Regions, "RegionShort", "RegionLong", tuotteet.AlkuperaMaa);
            return View(tuotteet);
        }

        // GET: Tuotteets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuotteet tuotteet = db.Tuotteets.Find(id);
            if (tuotteet == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> regions = new List<SelectListItem>();
            foreach (Region regionid in db.Regions)
            {
                regions.Add(new SelectListItem
                {
                    Value = regionid.RegionShort,
                    Text = regionid.RegionLong + "  " + regionid.RegionShort
                });
            }
            ViewBag.AlkuperaMaa = new SelectList(regions, "Value", "Text");
            return View(tuotteet);
        }

        // POST: Tuotteets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TuoteID,Nimi,Ahinta,ImageLink,VarastoSaldo,AlkuperaMaa")] Tuotteet tuotteet)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
            }

            if (ModelState.IsValid)
            {
                db.Entry(tuotteet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlkuperaMaa = new SelectList(db.Regions, "RegionShort", "RegionLong", tuotteet.AlkuperaMaa);
            return View(tuotteet);
        }

        // GET: Tuotteets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
            }

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tuotteet tuotteet = db.Tuotteets.Find(id);
            if (tuotteet == null)
            {
                return HttpNotFound();
            }
            return View(tuotteet);
        }

        // POST: Tuotteets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
            }

            Tuotteet tuotteet = db.Tuotteets.Find(id);
            db.Tuotteets.Remove(tuotteet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
