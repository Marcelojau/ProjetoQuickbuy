using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quickbuy.Repositorio.Config
{
    public class UsuarioConfiguration: IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);
            
            //Builder utilizar o padrão fluent

            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100)
                ;

            builder
                .Property(u => u.Senha)
                .IsRequired()
                .HasMaxLength(400);

            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(u => u.SobreNome)
                .IsRequired()
                .HasMaxLength(100);

            builder
                //withone tenho acesso a classe de pedidos
                .HasMany(u => u.Pedidos)
                .WithOne(p => p.Usuario);

                
                

        }
    }
}
