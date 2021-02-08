using FluentValidation;
using System;
using System.Linq;

namespace Business.Models.Validations
{
    public class CaseValidation : AbstractValidator<Case>
    {
        public static string CaseNumberValidSizeMessage => $"The Case Number field must be {CaseNumberValidation.SizeCaseNumber} characters.";
        public static string CaseNumerValidateMessage => "The provided Case Number is invalid. Report in the format NNNNNNNNN.NNNN.N.NN.NNNN";
        public static string CourtNameValidEmptyField => "The Court Name field needs to be provided.";
        public static string CourtNameValidSizeMessage => "The Court Name field must be between 2 and 50 characters.";
        public static string NameResponsibleValidEmptyField => "The Name Responsible field needs to be provided.";
        public static string NameResponsibleValidSizeMessage => "The Name Responsible field must be between 2 and 50 characters.";

        public CaseValidation()
        {
            RuleFor(f => f.CaseNumber.Length).Equal(CaseNumberValidation.SizeCaseNumber)
                .WithMessage(CaseNumberValidSizeMessage);

            RuleFor(f => CaseNumberValidation.Validate(f.CaseNumber)).Equal(true)
                    .WithMessage(CaseNumerValidateMessage);

            RuleFor(f => f.CourtName)
                .NotEmpty().WithMessage(CourtNameValidEmptyField)
                .Length(2, 50)
                .WithMessage(CourtNameValidSizeMessage);

            RuleFor(f => f.NameResponsible)
                .NotEmpty().WithMessage(NameResponsibleValidEmptyField)
                .Length(2, 50)
                .WithMessage(NameResponsibleValidSizeMessage);
        }
    }

    public class CaseNumberValidation
    {
        public const int SizeCaseNumber = 24;

        public static bool Validate(string caseNumber)
        {
            if (!ValidSize(caseNumber)) return false;

            if (!ValidateFormat(caseNumber)) return false;

            if (!ValidateSizeNumbers(caseNumber)) return false;

            return true;
        }

        private static bool ValidSize(string valor)
        {
            return valor.Length == SizeCaseNumber;
        }

        private static bool ValidateSizeNumbers(string caseNumber)
        {
            var numbers = Utilities.OnlyNumbers(caseNumber);

            return numbers.Length == (SizeCaseNumber - 4);
        }

        private static bool ValidateFormat(string valor)
        {
            if (valor.Substring(9, 1) != ".")
                return false;

            if (valor.Substring(14, 1) != ".")
                return false;

            if (valor.Substring(16, 1) != ".")
                return false;

            if (valor.Substring(19, 1) != ".")
                return false;

            return true;
        }
    }

    public class Utilities
    {
        public static string OnlyNumbers(string value)
        {
            var onlyNumber = "";
            foreach (var s in value)
            {
                if (char.IsDigit(s))
                {
                    onlyNumber += s;
                }
            }
            return onlyNumber.Trim();
        }
    }
}