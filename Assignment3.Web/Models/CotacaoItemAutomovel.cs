using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment3.Web.Models
{
    [Table("CotacaoItemAutomovel")]
    public class CotacaoItemAutomovel
    {
        public int CotacaoItemAutomovelId { get; set; }

        [Display(Name = "Dados da Cotação")]
        public int CotacaoId { get; set; }

        public Cotacao Cotacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Seguradora")]
        [StringLength(500)]
        public string NomeSeguradora { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Valor da Franquia")]
        public decimal ValorFranquia { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Valor do Prêmio")]
        public decimal ValorPremio { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Link da Cotação (Google Drive, OnDrive, ...)")]
        public string LinkCotacao { get; set; }

        [Display(Name = "Comentários")]
        public string Comentarios { get; set; }
        
    }
}