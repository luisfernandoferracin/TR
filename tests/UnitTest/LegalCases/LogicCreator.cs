using Business.Interfaces;
using Business.Services;
using Moq;
using System.Threading.Tasks;

namespace UnitTest.LegalCases
{
    public class LogicCreator
    {
        public Mock<ILegalCasesRepository> _legalCasesRepository { get; }
        public Mock<INotifier> _notification { get; }

        public LogicCreator()
        {
            _legalCasesRepository = new Mock<ILegalCasesRepository>();
            _notification = new Mock<INotifier>();
        }

        public LegalCasesService Instanciar() => new LegalCasesService(_legalCasesRepository.Object, _notification.Object);

        public LogicCreator WithStubGetById(Task<Business.Models.Case> resultadoEsperado)
        {
            _legalCasesRepository.Setup(x => x.GetById(It.IsAny<string>())).Returns(resultadoEsperado);
            return this;
        }
    }
}
