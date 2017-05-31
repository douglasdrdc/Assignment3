using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Assignment3.Web.Models
{
    public enum TipoCotacao
    {
        [Description("Cotação Automóvel")]
        CotacaoAutomovel = 0,
        [Description("Cotação Imóvel")]
        CotacaoImovel = 1,
        [Description("Cotação Saúde")]
        CotacaoSaude = 2
    }
}