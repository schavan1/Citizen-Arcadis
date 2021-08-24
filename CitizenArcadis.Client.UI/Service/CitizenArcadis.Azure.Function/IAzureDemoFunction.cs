using CitizenArcadis.Client.UI.Models.Response;
using System.Threading.Tasks;

namespace CitizenArcadis.Client.UI.Service
{
    public interface IAzureDemoFunction
    {
        Task<FunctionResponse<T>> OnPostAsync<T>(T employee);
    }
}