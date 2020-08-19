using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.dominio.Entidades
{
    public class ItemPedido : Entidade
    {
        public int Id { get; set; }
        public string ProdutoId { get; set; }
        public int Quantidade { get; set; }

        public override void Validate()
        {
            if (ProdutoId.ToString() == "0")
                AdicionarMensagemCritica("Crítica - Não foi identificado nenhum produto referenciado no item pedido");

            if (Quantidade == 0)
                AdicionarMensagemCritica("Crítica - Quantidade não foi informada");
        }
    }
}
