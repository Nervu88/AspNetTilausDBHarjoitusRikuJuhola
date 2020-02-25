using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetTilausDB.Controllers
{
    public class HomeController : Controller
    {
        TilausDBEntities1 db = new TilausDBEntities1();
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                ViewBag.LoggedStatus = "Offline";
                ViewBag.LoggausOsoite = "/Home/Login";
                ViewBag.Loggaus = "Login";
                ViewBag.frontTeksti = "Kirjaudu sisään järjestelmään...";
            }
            else
            {
                ViewBag.LoggausOsoite = "/Home/LogOut";
                ViewBag.Loggaus = "Log Out";
                ViewBag.LoggedStatus = "Online";
                ViewBag.frontTeksti = "Tervetuloa " + Session["UserName"];
            }
            return View();

        }

        public ActionResult About()
        {
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
                    ViewBag.Message = "Tässä sivussa tulee tietoja";
                ViewBag.Herja = "Ole huolellinen, niin ei tule virhettä";
                return View();
            }
        }

        public ActionResult Contact()
            {
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
                ViewBag.Message = "Ota yhteyttä";
                    return View();
            }
        }

        public ActionResult Login()
        {
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
                return View();
            }
        }
        [HttpPost]
        public ActionResult Authorize(Login LoginModel)
        {
            //Haetaan käyttäjän/Loginin tiedot annetuilla tunnustiedoilla tietokannasta LINQ -kyselyllä
            var LoggedUser = db.Logins.SingleOrDefault(x => x.UserName == LoginModel.UserName && x.PassWord == LoginModel.PassWord);
            if (LoggedUser != null)
            {
                ViewBag.LoginMessage = "Onnistunut kirjautuminen";
                ViewBag.LoggedStatus = "Online";
                Session["ryhma"] = LoggedUser.ryhma;
                Session["UserName"] = LoggedUser.UserName;
                return RedirectToAction("Index", "Home"); //Tässä määritellään mihin onnistunut kirjautuminen johtaa --> Home/Index
            }
            else
            {
                ViewBag.LoginMessage = "Kirjautuminen epäonnistui";
                ViewBag.LoggedStatus = "Offline";     
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana.";
                return View("Login", LoginModel);
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            ViewBag.LoggedStatus = "Offline";
            return RedirectToAction("Index", "Home"); //Uloskirjautumisen jälkeen pääsivulle
        }
    }
}