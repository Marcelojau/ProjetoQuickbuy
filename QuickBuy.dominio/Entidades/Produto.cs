using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.dominio.Entidades
{
    public class Produto : Entidade
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string NomeArquivo { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Nome))
                AdicionarMensagemCritica("Crítica - Nome do produto precisa ser cadastrado");

            if (Preco == 0)
                AdicionarMensagemCritica("Crítica - Você precisa cadastrar um preço para o produto");


        }
    }
}
