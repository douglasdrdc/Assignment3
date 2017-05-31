using Assignment3.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Web;
using System.Web.Mvc;

namespace Assignment3.Web.Controllers
{
    public class ControllerBase : Controller
    {

        public Cliente ClienteLogado
        {
            get
            {
                ValidateSessionActive();
                return (Cliente)Session["ClienteLogado"];
            }
        }

        public void ValidateSessionActive()
        {
            try
            {
                if (Session["ClienteLogado"] == null)
                    throw new AuthenticationException("Cliente não autenticado");

                if (((Cliente)Session["ClienteLogado"]) == null)
                    throw new AuthenticationException("Cliente não autenticado");
            }
            catch (AuthenticationException ex)
            {
                throw ex;
            }
            catch (Exception)
            {
                throw new AuthenticationException("Cliente não autenticado");
            }
        }

        public void InitializeSession(Cliente cliente)
        {
            Session["ClienteLogado"] = cliente;
        }

        public void FinalizeSession()
        {
            if (Session["ClienteLogado"] != null)
                Session["ClienteLogado"] = null;
        }
    }
}