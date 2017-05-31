namespace Assignment3.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(500)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo sobrenome é obrigatório")]
        [StringLength(500)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo e-mail é obrigatório")]
        [StringLength(500)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo CPF/CNPJ é obrigatório")]
        [StringLength(100)]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Campo telefone é obrigatório")]
        [StringLength(50)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo senha é obrigatório")]
        [StringLength(30, MinimumLength = 4)]
        public string Senha { get; set; }

        public List<Cotacao> Cotacoes { get; set; }
    }
}
