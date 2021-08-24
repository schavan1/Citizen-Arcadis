using CitizenArcadis.Client.UI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace CitizenArcadis.Client.UI.Models.DataContext
{
    public class CitizenArcadisDBContext : DbContext
    {
        public DbSet<EmployeeDTO> Employees { get; set; }
        public CitizenArcadisDBContext(DbContextOptions<CitizenArcadisDBContext> dboptions) : base(dboptions)
        {

        }
    }
}
