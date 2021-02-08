using System;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class CaseViewModel
    {
        [Key]
        [Required(ErrorMessage = "The {0} field is mandatory")]        
        [StringLength(24, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 24)]
        [Display(Name = "Case Number")]
        public string CaseNumber { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(50, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        [Display(Name = "Court Name")]
        public string CourtName { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(50, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        [Display(Name = "Name of the Responsible")]
        public string NameResponsible { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [Display(Name = "Registration Date")]
        public DateTime RegistrationDate { get; set; }
    }
}