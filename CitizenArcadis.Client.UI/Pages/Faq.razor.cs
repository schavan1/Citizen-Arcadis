using System.Collections.Generic;

namespace CitizenArcadis.Client.UI.Pages
{
    public partial class Faq : FormBasic<object>
    {

        protected override void OnInitialized()
        {
            _FormStages = new List<string>() { "Basic", "Intermediate", "Advance", "Complete" };
            base.OnInitialized();
        }
    }
}
