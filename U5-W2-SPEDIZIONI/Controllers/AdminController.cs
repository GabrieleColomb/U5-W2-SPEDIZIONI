using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U5_W2_SPEDIZIONI.Models;

namespace U5_W2_SPEDIZIONI.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ClientiPrivati()
        {
            return View(ClientePrivato.GetClienti());
        }

        [HttpGet]
        public ActionResult CreaClientePrivati()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreaClientePrivati(ClientePrivato cliente)
        {
            if (ModelState.IsValid)
            {
                ClientePrivato.CreaClienti(cliente);
                ClientePrivato.GetClienti().Add(cliente);
                return RedirectToAction("ClientiPrivati");
            }
            else
            {
                return View();
            }
        }

        public ActionResult ClienteAziende()
        {
            return View(ClienteAzienda.GetAziende());
        }

        [HttpGet]
        public ActionResult CreaClienteAziende()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreaClienteAziende(ClienteAzienda azienda)
        {
            if (ModelState.IsValid)
            {
                ClienteAzienda.CreaAzienda(azienda);
                ClienteAzienda.GetAziende().Add(azienda);
                return RedirectToAction("ClienteAziende");
            }
            else
            {
                return View();
            }
        }
    }
}