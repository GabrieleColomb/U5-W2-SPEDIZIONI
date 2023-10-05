using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U5_W2_SPEDIZIONI.Models;

namespace U5_W2_SPEDIZIONI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CercaSpedizione()
        {
            return View();
        }

        public ActionResult DettagliSpedizione(string NumeroSpedizione)
        {
            Spedizione spedizione = Spedizione.FindSpedizione(NumeroSpedizione);

            return PartialView("_DettagliSpedizione", spedizione);
        }
    }
}