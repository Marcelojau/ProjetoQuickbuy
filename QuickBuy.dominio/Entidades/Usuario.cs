using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.dominio.Entidades
{
    public class Usuario : Entidade
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public bool EhAdministrador { get; set; }
        //Um usuario pode ter nenhum ou varios pedidos
        //Precisa fazer dessa forma por causa do iof core
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrWhiteSpace(Email))
                AdicionarMensagemCritica("Crítica - Email não foi informado");

            if (string.IsNullOrWhiteSpace(Senha))
                AdicionarMensagemCritica("Crítica - Senha não informada");
        }
    }
}
