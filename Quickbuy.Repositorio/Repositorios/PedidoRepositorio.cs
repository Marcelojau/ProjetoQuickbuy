using Quickbuy.Repositorio.Contexto;
using QuickBuy.dominio.Contratos;
using QuickBuy.dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quickbuy.Repositorio.Repositorios
{
    public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
    {
        public PedidoRepositorio(QuickBuyContexto contexto) : base(contexto)
        {
        }
    }
}
