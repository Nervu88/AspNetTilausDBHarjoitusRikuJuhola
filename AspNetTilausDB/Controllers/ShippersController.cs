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
    public class ShippersController : Controller
    {
        private TilausDBEntities1 db = new TilausDBEntities1();

        // GET: Shippers
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("login", "home");
            }            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
                var shippers = db.Shippers.Include(s => s.Postitoimipaikat);
                return View(shippers.ToList());
            }
        }

        // GET: Shippers/Details/5
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
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // GET: Shippers/Create
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
            List<SelectListItem> shippernums = new List<SelectListItem>();
            foreach (Postitoimipaikat shipnum in db.Postitoimipaikats)
            {
                shippernums.Add(new SelectListItem
                {
                    Value = shipnum.Postinumero,
                    Text = shipnum.Postinumero + "  " + shipnum.Postitoimipaikka
                });
            }
            ViewBag.Postinumero = new SelectList(shippernums, "Value", "Text");
            return View();
        }

        // POST: Shippers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShipperID,Nimi,Osoite,Postinumero")] Shipper shipper)
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
                db.Shippers.Add(shipper);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Postinumero = new SelectList(db.Postitoimipaikats, "Postinumero", "Postitoimipaikka", shipper.Postinumero);
            return View(shipper);
        }

        // GET: Shippers/Edit/5
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
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> shippernums = new List<SelectListItem>();
            foreach (Postitoimipaikat shipnum in db.Postitoimipaikats)
            {
                shippernums.Add(new SelectListItem
                {
                    Value = shipnum.Postinumero,
                    Text = shipnum.Postinumero + "  " + shipnum.Postitoimipaikka
                });
            }
            ViewBag.Postinumero = new SelectList(shippernums, "Value", "Text");
            return View(shipper);
        }

        // POST: Shippers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShipperID,Nimi,Osoite,Postinumero")] Shipper shipper)
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
                db.Entry(shipper).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Postinumero = new SelectList(db.Postitoimipaikats, "Postinumero", "Postitoimipaikka", shipper.Postinumero);
            return View(shipper);
        }

        // GET: Shippers/Delete/5
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
            Shipper shipper = db.Shippers.Find(id);
            if (shipper == null)
            {
                return HttpNotFound();
            }
            return View(shipper);
        }

        // POST: Shippers/Delete/5
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

            Shipper shipper = db.Shippers.Find(id);
            db.Shippers.Remove(shipper);
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
