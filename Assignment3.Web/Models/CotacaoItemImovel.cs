using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Assignment3.Web.Models
{
    public class CotacaoItemImovel
    {
        public int SolicitanteId { get; set; }
        public Solicitante Solicitante { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Metragem { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string QuantidadeQuartos { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public double Valor { get; set; }
        



        [Required(ErrorMessage = "Campo obrigatório")]
        public string LinkCotacao { get; set; }


        public string Comentarios { get; set; }


//Tipo Imóvel(casa, apartamento)


    }
}