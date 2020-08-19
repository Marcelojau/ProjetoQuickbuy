using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.dominio.Contratos
{
    public interface IBaseRepositorio<TEntity>: IDisposable where TEntity: class
    {
        void Adicionar(TEntity entity);

        TEntity OberPorId(int id);

        IEnumerable<TEntity> ObterTodos();

        void Atualizar(TEntity entity);

        void Remover(TEntity entity);

        
    }
}
