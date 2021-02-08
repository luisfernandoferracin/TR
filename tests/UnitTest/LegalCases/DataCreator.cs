using System.Threading.Tasks;

namespace UnitTest.LegalCases
{
    public static class DataCreator
    {
        public static Business.Models.Case ValuesValid()
        {
            return new Business.Models.Case()
            {
                CaseNumber = "123456789.1234.1.12.1214",
                CourtName = "Court Name",
                NameResponsible = "Name Responsible"
            };
        }

        public static Business.Models.Case InvalidSize()
        {
            return new Business.Models.Case()
            {
                CaseNumber = "123456789.1234.1.12.121",
                CourtName = "123456789012345678901234567890123456789012345678901",
                NameResponsible = "123456789012345678901234567890123456789012345678901"
            };
        }

        public static Business.Models.Case EmptyField()
        {
            return new Business.Models.Case()
            {
                CaseNumber = "123456789.1234.1.12.1214",
            };
        }

        public static Business.Models.Case CaseNumberInvalidFormat()
        {
            return new Business.Models.Case()
            {
                CaseNumber = "123456789.1234.1212.1214",
                CourtName = "Court Name",
                NameResponsible = "Name Responsible"
            };
        }

        public static Business.Models.Case CaseNumberInvalidSizeNumbers()
        {
            return new Business.Models.Case()
            {
                CaseNumber = "123456789.1234.1.12.121A",
                CourtName = "Court Name",
                NameResponsible = "Name Responsible"
            };
        }

        public static Task<Business.Models.Case> TaskValuesValid()
        {
            return Task.FromResult(new Business.Models.Case()
            {
                CaseNumber = "123456789.1234.1.12.1214",
                CourtName = "Court Name",
                NameResponsible = "Name Responsible"
            });
        }


    }
}
