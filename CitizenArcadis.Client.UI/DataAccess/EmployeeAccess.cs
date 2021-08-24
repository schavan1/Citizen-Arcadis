using CitizenArcadis.Client.UI.Models.DataContext;
using CitizenArcadis.Client.UI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenArcadis.Client.UI.DataAccess
{
    public class EmployeeAccess : BaseDBContext<EmployeeDTO>, IBaseDBContext<EmployeeDTO>
    {
        public EmployeeAccess(CitizenArcadisDBContext dBContext) : base(dBContext)
        {

        }

        public async override Task<bool> Add(EmployeeDTO entity)
        {
            await dBContext.Employees.AddAsync(entity);
            return await Save();
        }

        public override async Task<bool> Delete(Guid ID)
        {
            dBContext.Employees.Remove(await Get(ID));
            return await Save();
        }

        public async override Task<EmployeeDTO> Get(Guid ID)
        {
            return await dBContext.Employees.FindAsync(ID);
        }

        public override async Task<IEnumerable<EmployeeDTO>> GetAll()
        {
            return await Task.Run(() =>
           {
               return dBContext.Employees.AsEnumerable();
           });
        }

        public override async Task<bool> Update(EmployeeDTO entity)
        {
            var e = await Get(entity.ID);
            if (e != null)
            {
                var updatedEmployee = dBContext.Employees.Attach(entity);
                updatedEmployee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                return await Save();
            }
            return false;
        }
    }

}
