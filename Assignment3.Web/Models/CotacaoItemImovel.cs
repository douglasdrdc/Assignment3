using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Assignment3.Web.Models
{
    [Table("CotacaoItemImovel")]
    public class CotacaoItemImovel
    {
        public int CotacaoItemImovelId { get; set; }

        [Display(Name = "Dados da Cotação")]
        public int CotacaoId { get; set; }

        public Cotacao Cotacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Tipo do Imóvel")]
        public TipoImovel TipoImovel { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Bairro")]
        [StringLength(500)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Cidade")]
        [StringLength(500)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Metragem")]
        [StringLength(500)]
        public string Metragem { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Quartos")]
        [StringLength(500)]
        public string QuantidadeQuartos { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Valor")]        
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Link da Cotação (Google Drive, OnDrive, ...)")]
        public string LinkCotacao { get; set; }

        [Display(Name = "Comentários")]
        public string Comentarios { get; set; }
                


    }
}