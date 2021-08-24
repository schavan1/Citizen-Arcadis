using CitizenArcadis.Client.UI.Models.Response;
using CitizenArcadis.Client.UI.Service;
using Microsoft.AspNetCore.Components;
using System;

namespace CitizenArcadis.Client.UI.Pages.Home
{
    public partial class AppTitle
    {
        [Inject]
        public IAzureDemoFunction AzureDemoFunction { get; set; }

        public string Information { get; set; }
        public AppTitle()
        {

        }
        public void GetInfo()
        {
            var model = new EmployeeModel() { Group = "groupE", ID = Guid.NewGuid().ToString(), Name = "zzzz" };
            var f = AzureDemoFunction.OnPostAsync<EmployeeModel>(model).GetAwaiter().GetResult();
            Console.WriteLine(f.Information);
            Information = f.Information;
        }
    }
}
