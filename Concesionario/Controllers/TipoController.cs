using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario.Models;

namespace Concesionario.Controllers
{
    public class TipoController : Controller
    {
        ConcesionarioEntities db = new ConcesionarioEntities();
        // GET: Tipo
        public ActionResult Index()
        {
            var data = db.Tipo;
            return View(data);
        }

        public ActionResult Alta()
        {
            return View(new Tipo());
        }

        [HttpPost]
        public ActionResult Alta(Tipo model)
        {

            if (ModelState.IsValid)
            {
                db.Tipo.Add(model);
                db.SaveChanges();
                return View(new Tipo());
            }

            return View(model);
        }

        public ActionResult Detalle(int id)                   // ESTO ES PARA CAMBIAR EL NOMBRE DE LA URL //s
        {


            var data = db.Tipo.Find(id);
            if (data == null)
                return RedirectToAction("Index");
            return View(data);
        }

    }



}