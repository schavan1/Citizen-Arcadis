using CitizenArcadis.Client.UI.Models.UI;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Collections.Generic;
using System.Linq;

namespace CitizenArcadis.Client.UI.Pages
{
    public class FormBasic<T> : ComponentBase where T : new()
    {
        protected T model = new T();

        protected List<FormStage> FormStages { get; set; }
        protected List<string> _FormStages { get; set; }

        //List<int> visited = new List<int>();

        public MudTimeline timeline { get; set; }

        protected override void OnInitialized()
        {
            FormStages = _FormStages.Select(a => new FormStage(a)).ToList();
            this.FormStages[this.CurrentFormStage].Color = Color.Success;
            this.FormStages[this.CurrentFormStage].Severity = Severity.Success;
            base.OnInitialized();
        }

        /// <summary>
        /// TODO : Replace this with timeLine Function & Props
        /// Get Selected Index && Setter :this.MoveTo()
        /// </summary>
        protected int CurrentFormStage { get; set; } = 0;

        protected virtual void MoveBack()
        {
            if (this.CurrentFormStage <= 0)
            {
                return;
            }
            this.FormStages[this.CurrentFormStage].Color = Color.Default;
            this.FormStages[this.CurrentFormStage].Severity = Severity.Normal;
            this.CurrentFormStage--;
            this.FormStages[this.CurrentFormStage].Color = Color.Success;
            this.FormStages[this.CurrentFormStage].Severity = Severity.Success;


        }

        protected virtual void SetCurrent(int i)
        {

            this.CurrentFormStage = i;

        }

        protected virtual void Movenext()
        {
            if (this.CurrentFormStage >= FormStages.Count - 1)
            {
                return;
            }
            this.CurrentFormStage++;
            this.FormStages[this.CurrentFormStage].Color = Color.Default;
            this.FormStages[this.CurrentFormStage].Color = Color.Default;
            this.FormStages[this.CurrentFormStage].Color = Color.Success;
            this.FormStages[this.CurrentFormStage].Severity = Severity.Success;
        }

    }
}
