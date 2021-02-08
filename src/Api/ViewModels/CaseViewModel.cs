using System;
using System.ComponentModel.DataAnnotations;

namespace Api.ViewModels
{
    public class CaseViewModel
    {
        [Key]
        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(24, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 24)]
        public string CaseNumber { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(50, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string CourtName { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        [StringLength(50, ErrorMessage = "The {0} field must be between {2} and {1} characters", MinimumLength = 2)]
        public string NameResponsible { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public DateTime RegistrationDate { get; set; }



    }
}