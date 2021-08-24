using CitizenArcadis.Client.UI.Models.DataContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CitizenArcadis.Client.UI.DataAccess
{
    public abstract class BaseDBContext<T> : IBaseDBContext<T>
    {
        protected readonly CitizenArcadisDBContext dBContext;
        public BaseDBContext(CitizenArcadisDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public abstract Task<bool> Add(T entity);

        public abstract Task<bool> Delete(Guid ID);

        public abstract Task<T> Get(Guid ID);

        public abstract Task<IEnumerable<T>> GetAll();

        public abstract Task<bool> Update(T entity);

        public virtual async Task<bool> Save()
        {
            var result = await this.dBContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
