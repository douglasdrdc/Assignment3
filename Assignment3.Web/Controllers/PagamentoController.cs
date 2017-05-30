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
    public class PagamentoController : Controller
    {
        private ModeloDados db = new ModeloDados();

        // GET: Pagamento
        public ActionResult Index()
        {
            var pagamento = db.Pagamento.Include(p => p.Cliente);
            return View(pagamento.ToList());
        }

        public ActionResult RealizarPagamento(Cliente cliente)
        {
            return View(cliente);
        }

        public ActionResult PagamentoConfirmado()
        {
            return View();
        }

        public ActionResult PagamentoEmProcessamento()
        {
            return View();
        }


        // GET: Pagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pagamento pagamento = db.Pagamento.Find(id);
            if (pagamento == null)
            {
                return HttpNotFound();
            }
            return View(pagamento);
        }
        
        //// GET: Pagamento/Create
        //public ActionResult Create()
        //{
        //    ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome");
        //    return View();
        //}

        //// POST: Pagamento/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "PagamentoId,ClienteId,DataPagamento,StatusPagamento")] Pagamento pagamento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Pagamento.Add(pagamento);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", pagamento.ClienteId);
        //    return View(pagamento);
        //}

        //// GET: Pagamento/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pagamento pagamento = db.Pagamento.Find(id);
        //    if (pagamento == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", pagamento.ClienteId);
        //    return View(pagamento);
        //}

        //// POST: Pagamento/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "PagamentoId,ClienteId,DataPagamento,StatusPagamento")] Pagamento pagamento)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(pagamento).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", pagamento.ClienteId);
        //    return View(pagamento);
        //}

        //// GET: Pagamento/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Pagamento pagamento = db.Pagamento.Find(id);
        //    if (pagamento == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(pagamento);
        //}

        //// POST: Pagamento/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    Pagamento pagamento = db.Pagamento.Find(id);
        //    db.Pagamento.Remove(pagamento);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
