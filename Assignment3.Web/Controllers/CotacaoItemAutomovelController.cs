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
    public class CotacaoItemAutomovelController : ControllerBase
    {
        private ModeloDados db = new ModeloDados();
        
        // GET: CotacaoItemAutomovel/Create
        public ActionResult Create(int id)
        {
            CotacaoItemAutomovel item = new CotacaoItemAutomovel();
            item.Cotacao = db.Cotacao.Include(c => c.Cliente).Include(c => c.Solicitante).Where(x => x.CotacaoId == id).FirstOrDefault();
            item.CotacaoId = item.Cotacao.CotacaoId;
            item.Cotacao.ItensAutomovel = db.CotacaoItemAutomovels.Where(x => x.CotacaoId == id).ToList();
            return View(item);
        }

        // POST: CotacaoItemAutomovel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CotacaoItemAutomovel cotacaoItemAutomovel)
        {
            if (ModelState.IsValid)
            {
                db.CotacaoItemAutomovels.Add(cotacaoItemAutomovel);
                db.SaveChanges();

                return RedirectToAction("Create", new { id = cotacaoItemAutomovel.CotacaoId } );
            }
            else
                return View(cotacaoItemAutomovel);
        }
                        
        // GET: CotacaoItemAutomovel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotacaoItemAutomovel cotacaoItemAutomovel = db.CotacaoItemAutomovels.Find(id);
            db.CotacaoItemAutomovels.Remove(cotacaoItemAutomovel);
            db.SaveChanges();
            return RedirectToAction("Create", "CotacaoItemAutomovel", new { id = cotacaoItemAutomovel.CotacaoId });
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
