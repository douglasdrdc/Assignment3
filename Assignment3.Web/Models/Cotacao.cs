using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Web.Models
{
    [Table("Cotacao")]
    public class Cotacao
    {
        public int CotacaoId { get; set; }

        [Display(Name = "Corretor")]
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        [Display(Name = "Cliente")]
        public int SolicitanteId { get; set; }

        public Solicitante Solicitante { get; set; }
        
        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data da Solicitação")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataSolicitacao { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Data de Validade")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Detalhes da cotação")]
        public string DescricaoSolicitacao { get; set; }

        [Display(Name = "Comentários")]
        public string ComentariosGerais { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [Display(Name = "Tipo de Cotação")]
        public TipoCotacao TipoCotacao { get; set; }

        public List<CotacaoItemAutomovel> ItensAutomovel { get; set; }
        public List<CotacaoItemImovel> ItensImovel { get; set; }        

    }
}