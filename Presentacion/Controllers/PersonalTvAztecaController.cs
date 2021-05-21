using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;
using System.Data;
using System.Data.Entity;
using System.Net;


namespace Presentacion.Controllers
{
    public class PersonalTvAztecaController : Controller
    {
        NegocioPersonal NP = new NegocioPersonal();
        // GET: PersonalTvAzteca
        public ActionResult Index()
        {
            List<PersonalTvAzteca> ListPersonal = NP.ConsulPersonal();

            return View(ListPersonal);

        }
        public ActionResult Create()
        {
            PersonalTvAzteca personal = new PersonalTvAzteca();
            return View(personal);
        }

        // POST: Personal/Crear
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPersonal,Nombre,PApellido,SApellido")] PersonalTvAzteca personal)
        {
            if (ModelState.IsValid)
            {
                NP.AgregarPersonal(personal);
            }
            return View(personal);


        }

        public ActionResult Consultar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalTvAzteca personal = NP.ConslPersonalId(id);
            if (personal == null)
            {
                return HttpNotFound();
            }

            return View(personal);
        }
        
        public ActionResult Actualizar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalTvAzteca personal = NP.ConslPersonalId(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Actualizar([Bind(Include = "IdPersonal,Nombre,PApellido,SApellido")] PersonalTvAzteca personal)
        {

            if (ModelState.IsValid)
            {
                NP.EditarPersonal(personal);
                return RedirectToAction("Index");
            }
            return View(personal);

        }
        public ActionResult Eliminar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonalTvAzteca personal = NP.ConslPersonalId(id);
            if (personal == null)
            {
                return HttpNotFound();
            }
            return View(personal);

        }
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public ActionResult EliminarConfirmar(int id)
        {
            PersonalTvAzteca personal = NP.ConslPersonalId(id);
            NP.EliminarPersonal(personal);
            return RedirectToAction("Index");
        }

    }
}