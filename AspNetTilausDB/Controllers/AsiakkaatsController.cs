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
    public class AsiakkaatsController : Controller
    {
        private TilausDBEntities1 db = new TilausDBEntities1();

        // GET: Asiakkaats
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
                var asiakkaats = db.Asiakkaats.Include(a => a.Postitoimipaikat);
                return View(asiakkaats.ToList());
            }
        }

        // GET: Asiakkaats/Details/5
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
            Asiakkaat asiakkaat = db.Asiakkaats.Find(id);
            if (asiakkaat == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaat);
        }

        // GET: Asiakkaats/Create
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

            List<SelectListItem> postnumerot = new List<SelectListItem>();
            foreach (Postitoimipaikat postnum in db.Postitoimipaikats)
            {
                postnumerot.Add(new SelectListItem
                {
                    Value = postnum.Postinumero,
                    Text = postnum.Postinumero + "  " + postnum.Postitoimipaikka
                });
            }
                       
            ViewBag.Postinumero = new SelectList(postnumerot, "Value", "Text");
            return View();
        }

        // POST: Asiakkaats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AsiakasID,Nimi,Osoite,Postinumero")] Asiakkaat asiakkaat)
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
                db.Asiakkaats.Add(asiakkaat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Postinumero = new SelectList(db.Postitoimipaikats, "Postinumero", "Postitoimipaikka", asiakkaat.Postinumero);
            return View(asiakkaat);
        }

        // GET: Asiakkaats/Edit/5
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
            Asiakkaat asiakkaat = db.Asiakkaats.Find(id);
            if (asiakkaat == null)
            {
                return HttpNotFound();
            }
            List<SelectListItem> postnumerot = new List<SelectListItem>();
            foreach (Postitoimipaikat postnum in db.Postitoimipaikats)
            {
                postnumerot.Add(new SelectListItem
                {
                    Value = postnum.Postinumero,
                    Text = postnum.Postinumero + "  " + postnum.Postitoimipaikka
                });
            }
            ViewBag.Postinumero = new SelectList(postnumerot, "Value", "Text");
            return View(asiakkaat);
        }

        // POST: Asiakkaats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AsiakasID,Nimi,Osoite,Postinumero")] Asiakkaat asiakkaat)
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
                db.Entry(asiakkaat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Postinumero = new SelectList(db.Postitoimipaikats, "Postinumero", "Postitoimipaikka", asiakkaat.Postinumero);
            return View(asiakkaat);
        }

        // GET: Asiakkaats/Delete/5
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
            Asiakkaat asiakkaat = db.Asiakkaats.Find(id);
            if (asiakkaat == null)
            {
                return HttpNotFound();
            }
            return View(asiakkaat);
        }

        // POST: Asiakkaats/Delete/5
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

            Asiakkaat asiakkaat = db.Asiakkaats.Find(id);
            db.Asiakkaats.Remove(asiakkaat);
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
