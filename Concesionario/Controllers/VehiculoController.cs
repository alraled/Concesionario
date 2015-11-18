using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Concesionario.Models;

namespace Concesionario.Controllers
{
    public class VehiculoController : Controller
    {

        private ConcesionarioEntities db = new ConcesionarioEntities();

        public ActionResult Index(int id)
        {
            var data = db.Vehiculo.Where(o=>o.idTipo == id);

            return View(data);
        }

        //public ActionResult Detalle(String nombre) // ESTO ES PARA CAMBIAR EL NOMBRE DE LA URL //s
        //{
        //    var nom = nombre.Replace("_", " ");

        //    var data = db.Vehiculo.FirstOrDefault(o => o.marca == nom);
        //    if (data == null)
        //        return RedirectToAction("Index");
        //    return View(data);
        //}

        // GET: Producto
        public ActionResult Alta()
        {
            return View(new Vehiculo());
        }

        [HttpPost]
        public ActionResult Alta(Vehiculo model)
        {

            if (ModelState.IsValid)
            {
                db.Vehiculo.Add(model);
                db.SaveChanges();
                return View(new Vehiculo());
            }

            return View(model);
        }
    }
}