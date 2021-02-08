using Business.Models.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public class Case : Entity
    {
        [Required]
        public string CourtName { get; set; }
        [Required]
        public string NameResponsible { get; set; }
        [Required]
        public DateTime RegistrationDate { get; set; }

        public FluentValidation.Results.ValidationResult Validate()
        {
            return new CaseValidation().Validate(this);
        }
    }
}