using CitizenArcadis.Client.UI.Models.DTO;
using System;
using System.Collections.Generic;

namespace CitizenArcadis.Client.UI.Repository
{
    public interface IBaseRepository<T>
    {
        T Add(EmployeeDTO ID);

        T GetEmployee(Guid ID);

        IEnumerable<T> GetEmployees();

        T UpdateEmployee(Guid ID);

        bool DeleteEmployee(Guid ID);
    }
}
