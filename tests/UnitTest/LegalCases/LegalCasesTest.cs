using Business.Services;
using Business.Notifications;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;
using Business.Models.Validations;
using System.Linq;

namespace UnitTest.LegalCases
{
    public class LegalCasesTest
    {  
        [Fact(DisplayName = "Validate With Valid Values")]
        [Trait("Legal Case", "Validate - Legal Case")]
        public void LegalCase_ValidValues_MustBeValid()
        {
            // Arrange
            var legalCase = DataCreator.ValuesValid();

            // Act
            var result = legalCase.Validate();

            // Assert
            Assert.True(result.IsValid);
        }

        [Fact(DisplayName = "Validate Field Size")]
        [Trait("Legal Case", "Validate - Legal Case")]
        public void LegalCase_ValidSize_MustBeInvalid()
        {
            // Arrange
            var legalCase = DataCreator.InvalidSize();

            // Act
            var result = legalCase.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(4, result.Errors.Count);
            Assert.Contains(CaseValidation.CaseNumberValidSizeMessage, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(CaseValidation.CaseNumerValidateMessage, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(CaseValidation.CourtNameValidSizeMessage, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(CaseValidation.NameResponsibleValidSizeMessage, result.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Validate Empty Field")]
        [Trait("Legal Case", "Validate - Legal Case")]
        public void LegalCase_ValidEmpty_MustBeInvalid()
        {
            // Arrange
            var legalCase = DataCreator.EmptyField();

            // Act
            var result = legalCase.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(2, result.Errors.Count);
            Assert.Contains(CaseValidation.CourtNameValidEmptyField, result.Errors.Select(c => c.ErrorMessage));
            Assert.Contains(CaseValidation.NameResponsibleValidEmptyField, result.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Validate Case Number Format")]
        [Trait("Legal Case", "Validate - Legal Case")]
        public void LegalCase_CaseNumberInvalidFormat_MustBeInvalid()
        {
            // Arrange
            var legalCase = DataCreator.CaseNumberInvalidFormat();

            // Act
            var result = legalCase.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(CaseValidation.CaseNumerValidateMessage, result.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Validate Case Number with Numbers Only")]
        [Trait("Legal Case", "Validate - Legal Case")]
        public void LegalCase_ValidateNumbersOnly_MustBeInvalid()
        {
            // Arrange
            var legalCase = DataCreator.CaseNumberInvalidSizeNumbers();

            // Act
            var result = legalCase.Validate();

            // Assert
            Assert.False(result.IsValid);
            Assert.Equal(1, result.Errors.Count);
            Assert.Contains(CaseValidation.CaseNumerValidateMessage, result.Errors.Select(c => c.ErrorMessage));
        }

        [Fact(DisplayName = "Validate Update with different supplied Id")]
        [Trait("Legal Case", "Validate - Legal Case")]
        public void LegalCase_DifferentProvidedId_MustBeInvalid()
        {
            // Arrange
            var legalCase = DataCreator.ValuesValid();
            var caseNumberDifferent = "223456789.1234.1.12.1214";

            // Act
            LogicCreator Creator = new LogicCreator();

            LegalCasesService Logic = Creator.Instanciar();

            var result = Logic.Update(caseNumberDifferent, legalCase);

            // Assert
            Assert.False(result.Result);
        }

        [Fact(DisplayName = "Validate Create Id Already Registered")]
        [Trait("Legal Case", "Validate - Legal Case")]
        public void LegalCase_IdAlreadyExists_MustBeInvalid()
        {
            // Arrange
            var legalCaseTask = DataCreator.TaskValuesValid();
            var legalCase = DataCreator.ValuesValid();

            // Act
            LogicCreator Creator = new LogicCreator()
                .WithStubGetById(legalCaseTask);

            LegalCasesService Logic = Creator.Instanciar();

            var result = Logic.Create(legalCase);

            // Assert
            Assert.False(result.Result);
        }

        [Fact(DisplayName = "Insert Record With Valid Data")]
        [Trait("Legal Case", "Create - Legal Case")]
        public void LegalCase_CreateWithValidData_InsertRecord()
        {
            // Arrange
            var legalCaseTask = Task.FromResult(new Business.Models.Case());
            var legalCase = DataCreator.ValuesValid();

            // Act
            LogicCreator Creator = new LogicCreator()
                .WithStubGetById(legalCaseTask);

            LegalCasesService Logic = Creator.Instanciar();

            var result = Logic.Create(legalCase);

            // Assert
            Assert.True(result.Result);
        }

        [Fact(DisplayName = "Update Record With Valid Data")]
        [Trait("Legal Case", "Update - Legal Case")]
        public void LegalCase_UpdateWithValidData_UpdateRecord()
        {
            // Arrange
            var id = DataCreator.ValuesValid().CaseNumber;
            var legalCase = DataCreator.ValuesValid();

            // Act
            LogicCreator Creator = new LogicCreator();

            LegalCasesService Logic = Creator.Instanciar();

            var result = Logic.Update(id, legalCase);

            // Assert
            Assert.True(result.Result);
        }

        [Fact(DisplayName = "Delete Record With Valid Id")]
        [Trait("Legal Case", "Delete - Legal Case")]
        public void LegalCase_DeleteWithValidData_DeleteRecord()
        {
            // Arrange
            var id = DataCreator.ValuesValid().CaseNumber;
            var legalCaseTask = DataCreator.TaskValuesValid();

            // Act
            LogicCreator Creator = new LogicCreator()
                .WithStubGetById(legalCaseTask);

            LegalCasesService Logic = Creator.Instanciar();

            var result = Logic.Delete(id);

            // Assert
            Assert.True(result.Result);
        }

    }
}
