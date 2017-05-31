using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Web.Models
{
    public class CotacaoItemAutomovel
    {
        public int SolicitanteId { get; set; }
        public Solicitante Solicitante { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double ValorFranquia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double ValorPremio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string LinkCotacao { get; set; }


        public string Comentarios { get; set; }
        
    }
}