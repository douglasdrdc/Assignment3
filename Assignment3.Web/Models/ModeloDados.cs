namespace Assignment3.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloDados : DbContext
    {
        public ModeloDados()
            : base("name=ModeloDados")
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Pagamento> Pagamento { get; set; }
        public virtual DbSet<Cotacao> Cotacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Cliente

            modelBuilder.Entity<Cliente>()
                    .Property(e => e.Nome)
                    .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Sobrenome)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.CpfCnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Senha)
                .IsUnicode(false);

            #endregion

            #region Pagamento

            modelBuilder.Entity<Pagamento>()
                    .Property(e => e.ClienteId);

            modelBuilder.Entity<Pagamento>()
                .Property(e => e.DataPagamento);

            modelBuilder.Entity<Pagamento>()
                .Property(e => e.StatusPagamento)
                .IsUnicode(false);

            #endregion

            #region Solicitante

            modelBuilder.Entity<Solicitante>()
                    .Property(e => e.ClienteId);

            modelBuilder.Entity<Solicitante>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitante>()
                .Property(e => e.Sobrenome)
                .IsUnicode(false);

            modelBuilder.Entity<Solicitante>()
                .Property(e => e.ChaveIdentificacao)
                .IsUnicode(false);

            #endregion

            #region Cotação

            modelBuilder.Entity<Cotacao>()
                    .Property(e => e.ClienteId);

            modelBuilder.Entity<Cotacao>()
                    .Property(e => e.SolicitanteId);

            modelBuilder.Entity<Cotacao>()
                    .Property(e => e.DataSolicitacao);

            modelBuilder.Entity<Cotacao>()
                    .Property(e => e.DataValidade);

            modelBuilder.Entity<Cotacao>()
                .Property(e => e.DescricaoSolicitacao)
                .IsUnicode(false);

            modelBuilder.Entity<Cotacao>()
                .Property(e => e.ComentariosGerais)
                .IsUnicode(false);

            modelBuilder.Entity<Cotacao>()
                .Property(e => e.TipoCotacao);

            #endregion

            #region Cotação Item Automóvel

            modelBuilder.Entity<CotacaoItemAutomovel>()
                    .Property(e => e.CotacaoId);

            modelBuilder.Entity<CotacaoItemAutomovel>()
                .Property(e => e.NomeSeguradora)
                .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemAutomovel>()
                    .Property(e => e.ValorFranquia);

            modelBuilder.Entity<CotacaoItemAutomovel>()
                    .Property(e => e.ValorPremio);

            modelBuilder.Entity<CotacaoItemAutomovel>()
                .Property(e => e.LinkCotacao)
                .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemAutomovel>()
                .Property(e => e.Comentarios)
                .IsUnicode(false);

            #endregion

            #region Cotação Item Imóvel

            modelBuilder.Entity<CotacaoItemImovel>()
                    .Property(e => e.CotacaoId);

            modelBuilder.Entity<CotacaoItemImovel>()
                .Property(e => e.TipoImovel);

            modelBuilder.Entity<CotacaoItemImovel>()
                    .Property(e => e.Bairro)
                    .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemImovel>()
                    .Property(e => e.Cidade)
                    .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemImovel>()
                    .Property(e => e.Metragem)
                    .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemImovel>()
                    .Property(e => e.QuantidadeQuartos)
                    .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemImovel>()
                    .Property(e => e.Cidade)
                    .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemImovel>()
                    .Property(e => e.Valor  );

            modelBuilder.Entity<CotacaoItemImovel>()
                .Property(e => e.LinkCotacao)
                .IsUnicode(false);

            modelBuilder.Entity<CotacaoItemImovel>()
                .Property(e => e.Comentarios)
                .IsUnicode(false);

            #endregion

        }

        public System.Data.Entity.DbSet<Assignment3.Web.Models.Solicitante> Solicitantes { get; set; }

        public System.Data.Entity.DbSet<Assignment3.Web.Models.CotacaoItemAutomovel> CotacaoItemAutomovels { get; set; }

        public System.Data.Entity.DbSet<Assignment3.Web.Models.CotacaoItemImovel> CotacaoItemImovels { get; set; }
    }
}
