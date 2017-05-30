using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Web.Models
{
    [Table("Pagamento")]
    public class Pagamento
    {
        public int PagamentoId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataPagamento { get; set; }
        public string StatusPagamento { get; set; }
    }
}

