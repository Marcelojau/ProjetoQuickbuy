using QuickBuy.dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.dominio.Contratos
{
    public interface IUsuarioRepositorio: IBaseRepositorio<Usuario>
    {
        Usuario Obter(string email, string senha);
        Usuario Obter(string email);
    }
}
