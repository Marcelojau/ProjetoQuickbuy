﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quickbuy.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                .Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .Property(p => p.Preco)
                .HasColumnType("decimal(19,4)")
                .IsRequired();
                
        }
    }
}
