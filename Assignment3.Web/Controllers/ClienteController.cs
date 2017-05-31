using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment3.Web.Models;
using System.Security.Authentication;

namespace Assignment3.Web.Controllers
{
    public class ClienteController : ControllerBase
    {
        private ModeloDados db = new ModeloDados();

        // GET: Cliente
        public ActionResult Index()
        {
            return View(db.Cliente.ToList());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Email = cliente.Email.ToLower();

                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("RealizarPagamento", "Pagamento", cliente);
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.Email = cliente.Email.ToLower();

                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("RealizarPagamento", "Pagamento", cliente);
            }
            return View(cliente);
        }

        
        public ActionResult Login()
        {            
            return View(new Cliente());
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Cliente cliente)
        {
            if (!string.IsNullOrEmpty(cliente.Email) && !string.IsNullOrEmpty(cliente.Senha))
            {
                string senhaInformada = cliente.Senha;
                cliente.Email = cliente.Email.ToLower();

                cliente = db.Cliente.Where(x => x.Email == cliente.Email).FirstOrDefault();
                if (cliente != null && cliente.ClienteId != 0)
                {
                    if (cliente.Senha != senhaInformada)
                        ViewBag.MensagemValidacao = "E-mail ou senha incorretos";
                    else
                    {
                        InitializeSession(cliente);
                        return RedirectToAction("HomePortal", "Cliente");
                    }
                }
                else
                {
                    ViewBag.MensagemValidacao = "E-mail ou senha incorretos";
                }                
            }
            return View(cliente);
        }
        
        public ActionResult HomePortal()
        {
            try
            {
                ValidateSessionActive();
                                
                Cliente cliente = this.ClienteLogado;

                cliente.Cotacoes = db.Cotacao.Where(x => x.ClienteId == cliente.ClienteId && x.DataValidade >= DateTime.Now).ToList();

                return View(cliente);
            }
            catch (AuthenticationException)
            {
                return RedirectToAction("Login", "Cliente");
            }
            catch (Exception ex)
            {                
                throw ex;
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
