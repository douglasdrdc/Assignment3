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

        [Required(ErrorMessage = "Campo nome � obrigat�rio")]
        [StringLength(500)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo sobrenome � obrigat�rio")]
        [StringLength(500)]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Campo e-mail � obrigat�rio")]
        [StringLength(500)]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo CPF/CNPJ � obrigat�rio")]
        [StringLength(100)]
        [Display(Name = "CPF/CNPJ")]
        public string CpfCnpj { get; set; }

        [Required(ErrorMessage = "Campo telefone � obrigat�rio")]
        [StringLength(50)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Campo senha � obrigat�rio")]
        [StringLength(30, MinimumLength = 4)]
        public string Senha { get; set; }

        public List<Cotacao> Cotacoes { get; set; }
    }
}
