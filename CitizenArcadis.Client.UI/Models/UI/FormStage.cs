using MudBlazor;

namespace CitizenArcadis.Client.UI.Models.UI
{
    public class FormStage
    {
        public string Stage { get; set; }

        public bool isActive { get; set; }

        public Color Color { get; set; }

        public Severity Severity { get; set; }

        public Size DotSize { get; set; }

        public Color DotColor { get; set; }

        public Variant DotVariant { get; set; }

        public int DotElevation { get; set; } = 1;

        public bool HideDot { get; set; }


        public bool IsInvalid;

        public FormStage(string Stage)
        {
            this.Stage = Stage;
        }
    }
}
