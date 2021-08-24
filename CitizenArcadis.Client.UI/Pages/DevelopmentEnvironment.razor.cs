using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitizenArcadis.Client.UI.Pages
{
    public partial class DevelopmentEnvironment : FormBasic<RegisterAccountForm>
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }


        protected bool isCheckBoxEnabled()
        {
            model.IsUnAvailable = string.IsNullOrEmpty(this.model.AvailableProjects);
            return model.IsUnAvailable;
        }

        protected override void OnInitialized()
        {
            _FormStages = new List<string>() { "Name Of Project", "Check Existing Solutions", "Select A PlatForm", "Finish" };
            base.OnInitialized();
        }

        private string[] ExistingProjects =
        {
        "Adobe", "Excel", "Powerpoint",
         };

        private string[] databases =
        {
        "Power Business", "Python", "Power App",
         };

        public EditForm Form { get; set; }

        private async Task<IEnumerable<string>> Search1(string value)
        {
            // In real life use an asynchronous function for fetching data from an api.
            await Task.Delay(5);
            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(value))
            {
                return ExistingProjects;
            }

            return databases.Where(x => x.Contains(value, StringComparison.InvariantCultureIgnoreCase));
        }
        protected override void SetCurrent(int i)
        {
            if (Form.EditContext.Validate())
            {
                FormStages[this.CurrentFormStage].IsInvalid = false;
                base.SetCurrent(i);
            }
            else
            {
                FormStages[this.CurrentFormStage].IsInvalid = true;
            }

        }
        private void OnValidSubmit(EditContext context)
        {
            StateHasChanged();
        }


        protected override void Movenext()
        {
            if (Form.EditContext.Validate())
            {
                FormStages[this.CurrentFormStage].IsInvalid = false;
                base.Movenext();
            }
            else
            {
                FormStages[this.CurrentFormStage].IsInvalid = true;
            }
        }

        protected string getJson()
        {
            if (Form.EditContext.Validate())
            {
                var s = JsonConvert.SerializeObject(model, Formatting.Indented);
                return s;
            }
            else
            {
                return "Error Parsing the configuration Please Try again.";
            }
        }


        protected void Finish()
        {
            switch (this.CurrentFormStage)
            {
                case 1:
                    if (this.model.AvailableProjects != "" && !this.model.IsUnAvailable)
                    {
                        NavigationManager.NavigateTo("http://www.google.com");
                        break;
                    }
                    goto default;
                default:
                    if (Form.EditContext.Validate())
                    {
                        FormStages[this.CurrentFormStage].IsInvalid = false;
                        this.CurrentFormStage = this.FormStages.Count - 1;
                        //base.timeline.MoveTo(3);
                    }
                    else
                    {
                        FormStages[this.CurrentFormStage].IsInvalid = true;
                    }

                    break;
            }
        }
    }
}
