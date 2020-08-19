using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Quickbuy.Repositorio.Config;
using QuickBuy.dominio.Entidades;
using QuickBuy.dominio.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quickbuy.Repositorio.Contexto
{
    public class QuickBuyContexto: DbContext
    {
        

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<ItemPedido> ItensPedidos { get; set; }

        public DbSet<FormaPagamento> FormaPagamento { get; set; }

        public QuickBuyContexto(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Referência classes de mapeamento
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento() {
                  Id = 1,
                  Descricao = "Forma de pagamento boleto",
                  Nome = "Boleto"

            },
            new FormaPagamento()
            {
                Id = 2,
                Descricao = "Forma de pagamento cartão de crédito",
                Nome = "Cartão de crédito"
            },
            new FormaPagamento()
            {
                Id = 3,
                Descricao = "Forma de pagamento depósito",
                Nome = "Depósito"
            });
            base.OnModelCreating(modelBuilder);
        }

    }
}
