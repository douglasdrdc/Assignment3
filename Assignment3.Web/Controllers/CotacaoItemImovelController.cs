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
    public class CotacaoItemImovelController : ControllerBase
    {
        private ModeloDados db = new ModeloDados();
        
        // GET: CotacaoItemImovel/Create
        public ActionResult Create(int id)
        {
            CotacaoItemImovel item = new CotacaoItemImovel();
            item.Cotacao = db.Cotacao.Include(c => c.Cliente).Include(c => c.Solicitante).Where(x => x.CotacaoId == id).FirstOrDefault();
            item.CotacaoId = item.Cotacao.CotacaoId;
            item.Cotacao.ItensImovel = db.CotacaoItemImovels.Where(x => x.CotacaoId == id).ToList();
            return View(item);
        }

        // POST: CotacaoItemImovel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CotacaoItemImovel cotacaoItemImovel)
        {
            if (ModelState.IsValid)
            {
                db.CotacaoItemImovels.Add(cotacaoItemImovel);
                db.SaveChanges();

                return RedirectToAction("Create", new { id = cotacaoItemImovel.CotacaoId });
            }
            else
                return View(cotacaoItemImovel);
        }
        
        // GET: CotacaoItemImovel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CotacaoItemImovel cotacaoItemImovel = db.CotacaoItemImovels.Find(id);
            db.CotacaoItemImovels.Remove(cotacaoItemImovel);
            db.SaveChanges();
            return RedirectToAction("Create", "CotacaoItemImovel", new { id = cotacaoItemImovel.CotacaoId });
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
