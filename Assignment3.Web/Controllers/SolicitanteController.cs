using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment3.Web.Models;

namespace Assignment3.Web.Controllers
{
    public class SolicitanteController : ControllerBase
    {
        private ModeloDados db = new ModeloDados();

        // GET: Solicitante
        public ActionResult Index()
        {
            try
            {
                ValidateSessionActive();

                var solicitantes = db.Solicitantes.Include(s => s.Cliente);
                if (solicitantes != null && solicitantes.Count() > 0)
                    return View(solicitantes.Where(x => x.ClienteId == this.ClienteLogado.ClienteId).ToList());

                return View(solicitantes);
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                return RedirectToAction("Login", "Cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }            
        }

        // GET: Solicitante/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ValidateSessionActive();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Solicitante solicitante = db.Solicitantes.Find(id);
                if (solicitante == null)
                {
                    return HttpNotFound();
                }
                return View(solicitante);
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                return RedirectToAction("Login", "Cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        // GET: Solicitante/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
            return View();
        }

        // POST: Solicitante/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                solicitante.ClienteId = this.ClienteLogado.ClienteId;
                db.Solicitantes.Add(solicitante);
                db.SaveChanges();

                solicitante.ChaveIdentificacao = string.Format("{0}{1}",
                    DateTime.Now.ToString("yyyyMMdd_hhMMss"),
                    solicitante.SolicitanteId);
                db.Entry(solicitante).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", solicitante.ClienteId);
            return View(solicitante);
        }

        // GET: Solicitante/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                ValidateSessionActive();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Solicitante solicitante = db.Solicitantes.Find(id);
                if (solicitante == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", solicitante.ClienteId);
                return View(solicitante);
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                return RedirectToAction("Login", "Cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        // POST: Solicitante/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Solicitante solicitante)
        {
            if (ModelState.IsValid)
            {
                solicitante.ClienteId = this.ClienteLogado.ClienteId;
                db.Entry(solicitante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", solicitante.ClienteId);
            return View(solicitante);
        }

        // GET: Solicitante/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                ValidateSessionActive();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Solicitante solicitante = db.Solicitantes.Find(id);
                if (solicitante == null)
                {
                    return HttpNotFound();
                }
                return View(solicitante);
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                return RedirectToAction("Login", "Cliente");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        // POST: Solicitante/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Solicitante solicitante = db.Solicitantes.Find(id);
            db.Solicitantes.Remove(solicitante);
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
