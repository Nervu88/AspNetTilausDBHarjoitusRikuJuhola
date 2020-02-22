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
    public class HenkilotsController : Controller
    {
        private TilausDBEntities1 db = new TilausDBEntities1();

        // GET: Henkilots
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
                var henkilots = db.Henkilots.Include(h => h.Postitoimipaikat).Include(h => h.Esimiehet);
                return View(henkilots.ToList());
            }
        }

        // GET: Henkilots/Details/5
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
            Henkilot henkilot = db.Henkilots.Find(id);
            if (henkilot == null)
            {
                return HttpNotFound();
            }
            return View(henkilot);
        }

        // GET: Henkilots/Create
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

            List<SelectListItem> esimiesnum = new List<SelectListItem>();
            foreach (Esimiehet esinum in db.Esimiehets)
            {
                esimiesnum.Add(new SelectListItem
                {
                    Value = esinum.EsimiesID.ToString(),
                    Text = esinum.EsimiesID.ToString() + "  " + esinum.Etunimi
                });;
            }

            ViewBag.Postinumero = new SelectList(postnumerot, "Value", "Text");
            ViewBag.Esimies = new SelectList(esimiesnum, "Value", "Text");
            return View();
        }

        // POST: Henkilots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Henkilo_id,Etunimi,Sukunimi,Osoite,Esimies,Sahkoposti,Postinumero")] Henkilot henkilot)
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
                db.Henkilots.Add(henkilot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Postinumero = new SelectList(db.Postitoimipaikats, "Postinumero", "Postitoimipaikka", henkilot.Postinumero);
            ViewBag.Esimies = new SelectList(db.Esimiehets, "EsimiesID", "Etunimi", henkilot.Esimies);
            return View(henkilot);
        }

        // GET: Henkilots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Henkilot henkilot = db.Henkilots.Find(id);
            if (henkilot == null)
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

            List<SelectListItem> esimiesnum = new List<SelectListItem>();
            foreach (Esimiehet esinum in db.Esimiehets)
            {
                esimiesnum.Add(new SelectListItem
                {
                    Value = esinum.EsimiesID.ToString(),
                    Text = esinum.EsimiesID.ToString() + "  " + esinum.Etunimi
                });
            }

            ViewBag.Postinumero = new SelectList(postnumerot, "Value", "Text", henkilot.Postinumero);
            ViewBag.Esimies = new SelectList(esimiesnum, "Value", "Text", henkilot.Esimies);

            return View(henkilot);
        }

        // POST: Henkilots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Henkilo_id,Etunimi,Sukunimi,Osoite,Esimies,Sahkoposti,Postinumero")] Henkilot henkilot)
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
                db.Entry(henkilot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Postinumero = new SelectList(db.Postitoimipaikats, "Postinumero", "Postitoimipaikka", henkilot.Postinumero);
            ViewBag.Esimies = new SelectList(db.Esimiehets, "EsimiesID", "Etunimi", henkilot.Esimies);
            return View(henkilot);
        }

        // GET: Henkilots/Delete/5
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
            Henkilot henkilot = db.Henkilots.Find(id);
            if (henkilot == null)
            {
                return HttpNotFound();
            }
            return View(henkilot);
        }

        // POST: Henkilots/Delete/5
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

            Henkilot henkilot = db.Henkilots.Find(id);
            db.Henkilots.Remove(henkilot);
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
