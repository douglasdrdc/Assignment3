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
    public class CotacaoController : ControllerBase
    {
        private ModeloDados db = new ModeloDados();

        // GET: Cotacao
        public ActionResult Index()
        {
            try
            {
                ValidateSessionActive();

                var cotacao = db.Cotacao.Include(c => c.Cliente).Include(c => c.Solicitante);
                if (cotacao != null && cotacao.Count() > 0)
                    return View(cotacao.Where(x => x.ClienteId == this.ClienteLogado.ClienteId).ToList());

                return View(cotacao);
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

        // GET: Cotacao/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                ValidateSessionActive();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cotacao cotacao = db.Cotacao.Include(c => c.Cliente).Include(c => c.Solicitante).Where(x => x.CotacaoId == id).FirstOrDefault();
                if (cotacao == null)
                {
                    return HttpNotFound();
                }

                switch (cotacao.TipoCotacao)
                {
                    case TipoCotacao.CotacaoAutomovel:
                        cotacao.ItensAutomovel = db.CotacaoItemAutomovels.Where(x => x.CotacaoId == cotacao.CotacaoId).ToList();
                        break;
                    case TipoCotacao.CotacaoImovel:
                        cotacao.ItensImovel = db.CotacaoItemImovels.Where(x => x.CotacaoId == cotacao.CotacaoId).ToList();
                        break;                    
                }

                return View(cotacao);
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

        // GET: Cotacao/Create
        public ActionResult Create()
        {
            try
            {
                ValidateSessionActive();

                Cotacao cotacao = new Cotacao();
                cotacao.ClienteId = this.ClienteLogado.ClienteId;
                cotacao.DataSolicitacao = DateTime.Now;
                cotacao.DataValidade = DateTime.Now.AddDays(10);

                var solicitantes = db.Solicitantes.Where(x => x.ClienteId == this.ClienteLogado.ClienteId).ToList();
                if (solicitantes != null && solicitantes.Count() > 0)
                    ViewBag.Solicitantes = solicitantes;
                else
                    ViewBag.MensagemValidacao = "É necessário realizar o cadastro do cliente antes de criar a cotação.";

                return View(cotacao);
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

        // POST: Cotacao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                cotacao.ClienteId = this.ClienteLogado.ClienteId;
                cotacao.DataSolicitacao = DateTime.Now;
                cotacao.DataValidade = DateTime.Now.AddDays(10);

                db.Cotacao.Add(cotacao);
                db.SaveChanges();

                switch (cotacao.TipoCotacao)
                {
                    case TipoCotacao.CotacaoAutomovel:
                        return RedirectToAction("Create", "CotacaoItemAutomovel", new { id = cotacao.CotacaoId });
                    case TipoCotacao.CotacaoImovel:
                        return RedirectToAction("Create", "CotacaoItemImovel", new { id = cotacao.CotacaoId });
                }

                
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", cotacao.ClienteId);
            ViewBag.SolicitanteId = new SelectList(db.Solicitantes, "SolicitanteId", "Nome", cotacao.SolicitanteId);
            return View(cotacao);
        }

        // GET: Cotacao/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                ValidateSessionActive();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cotacao cotacao = db.Cotacao.Find(id);
                if (cotacao == null)
                {
                    return HttpNotFound();
                }
                ViewBag.ClienteId = new SelectList(db.Cliente, "ClienteId", "Nome", cotacao.ClienteId);
                ViewBag.SolicitanteId = new SelectList(db.Solicitantes, "SolicitanteId", "Nome", cotacao.SolicitanteId);
                return View(cotacao);
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

        // POST: Cotacao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cotacao cotacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cotacao).State = EntityState.Modified;
                db.SaveChanges();

                switch (cotacao.TipoCotacao)
                {
                    case TipoCotacao.CotacaoAutomovel:
                        return RedirectToAction("Create", "CotacaoItemAutomovel", new { id = cotacao.CotacaoId });                        
                    case TipoCotacao.CotacaoImovel:
                        return RedirectToAction("Create", "CotacaoItemImovel", new { id = cotacao.CotacaoId });                    
                }                                
            }
                        
            return View(cotacao);
        }

        // GET: Cotacao/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                ValidateSessionActive();

                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Cotacao cotacao = db.Cotacao.Find(id);
                if (cotacao == null)
                {
                    return HttpNotFound();
                }
                return View(cotacao);
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

        // POST: Cotacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cotacao cotacao = db.Cotacao.Find(id);
            db.Cotacao.Remove(cotacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ConsultaCotacao(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    ViewBag.MensagemStatus = "Desculpe mas não encontramos nenhum dado para esta cotação. Verifique com seu corretor se o link informado está correto.";
                    return View();
                }
                                
                var solicitante = db.Solicitantes.Where(x => x.ChaveIdentificacao == id).FirstOrDefault();
                if (solicitante == null)
                {
                    ViewBag.MensagemStatus = "Desculpe mas não encontramos nenhum dado para esta cotação. Verifique com seu corretor se o link informado está correto.";
                    return View();
                }

                Cotacao cotacao = db.Cotacao.Include(c => c.Cliente).Include(c => c.Solicitante).Where(x => x.SolicitanteId == solicitante.SolicitanteId).FirstOrDefault();
                if (cotacao == null)
                {
                    ViewBag.MensagemStatus = "Desculpe mas não encontramos nenhum dado para esta cotação. Verifique com seu corretor se o link informado está correto.";
                    return View();
                }

                switch (cotacao.TipoCotacao)
                {
                    case TipoCotacao.CotacaoAutomovel:
                        cotacao.ItensAutomovel = db.CotacaoItemAutomovels.Where(x => x.CotacaoId == cotacao.CotacaoId).ToList();
                        break;
                    case TipoCotacao.CotacaoImovel:
                        cotacao.ItensImovel = db.CotacaoItemImovels.Where(x => x.CotacaoId == cotacao.CotacaoId).ToList();
                        break;                    
                }

                return View(cotacao);
            }
            catch (System.Security.Authentication.AuthenticationException)
            {
                ViewBag.MensagemStatus = "Desculpe mas não encontramos nenhum dado para esta cotação. Verifique com seu corretor se o link informado está correto.";
                return View();
            }
            catch (Exception)
            {
                ViewBag.MensagemStatus = "Desculpe mas não encontramos nenhum dado para esta cotação. Verifique com seu corretor se o link informado está correto.";
                return View();
            }

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
