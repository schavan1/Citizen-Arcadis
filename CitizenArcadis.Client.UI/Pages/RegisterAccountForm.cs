using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace CitizenArcadis.Client.UI.Pages
{
    public class RegisterAccountForm
    {
        private string availableProjects;
        public Guid ID { get; set; } = Guid.NewGuid();

        [Required]
        [Display(Name = "Name Of Project")]
        [StringLength(maximumLength: 10, ErrorMessage = "Name Of Project length can't be more than 10 and less than 2.", MinimumLength = 3)]
        public string NameOfProject { get; set; }

        [Display(Name = "cehcek i n citizen if  its  laredy exists")]
        public string AvailableProjects
        {
            get
            {
                if (this.IsUnAvailable)
                {
                    return null;
                }
                else
                {
                    return this.availableProjects;
                }
            }
            set
            {
                this.availableProjects = value;
            }
        }

        [Display(Name = "cehcek i n citizen if  its  laredy exists")]
        [Required]
        public bool IsUnAvailable { get; set; }

        [Display(Name = "oes your soltuin utilize your these platfor")]
        public string Platform { get; set; }
    }
}
