using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Web.Models
{
    [Table("Cotacao")]
    public class Cotacao
    {
        public int CotacaoId { get; set; }

        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public int SolicitanteId { get; set; }

        public Solicitante Solicitante { get; set; }
        
        [Required(ErrorMessage = "Campo nome é obrigatório")]        
        public DateTime DataSolicitacao { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]        
        public DateTime DataValidade { get; set; }
    }
}