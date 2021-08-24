using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitizenArcadis.Client.UI.DataAccess
{
    public interface IBaseDBContext<T>
    {
        abstract Task<bool> Add(T entity);

        abstract Task<bool> Delete(Guid ID);

        abstract Task<T> Get(Guid ID);

        abstract Task<IEnumerable<T>> GetAll();

        abstract Task<bool> Update(T entity);
    }
}
