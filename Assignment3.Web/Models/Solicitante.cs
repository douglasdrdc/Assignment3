using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment3.Web.Models
{
    [Table("Solicitante")]
    public class Solicitante
    {
        public int SolicitanteId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(500)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(500)]
        public string Sobrenome { get; set; }

        public string ChaveIdentificacao { get; set; }
    }
}