using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Assignment3.Web.Models
{
    public enum TipoImovel
    {
        [Description("Cotação Automóvel")]
        Casa = 0,
        [Description("Cotação Imóvel")]
        Apartamento = 1        
    }
}