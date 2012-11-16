using System.Collections.Generic;

namespace Lampadas.Services.Interfaces
{
    public interface IEntityService<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetList();
        void SaveOrUpdate(TEntity entity);
        void Delete(int id);
    }
}
