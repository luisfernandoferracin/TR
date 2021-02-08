using Business.Interfaces;
using Business.Models;
using Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace Business.Services
{
    public class LegalCasesService : BaseService, ILegalCasesService
    {
        private readonly ILegalCasesRepository _legalCasesRepository;

        public LegalCasesService(ILegalCasesRepository legalCasesRepository,
                                 INotifier notifier) : base(notifier)
        {
            _legalCasesRepository = legalCasesRepository;
        }

        public async Task<bool> Create(Case legalCases)
        {
            if (!RunValidation(new CaseValidation(), legalCases)) return false;

            var verify = await _legalCasesRepository.GetById(legalCases.CaseNumber);

            if (verify != null && !string.IsNullOrEmpty(verify.CaseNumber))
            {
                Notify($"There is already a registered record with the number {verify.CaseNumber}.");
                return false;
            }

            await _legalCasesRepository.Create(legalCases);
            return true;
        }

        public async Task<bool> Update(string id, Case legalCases)
        {
            if (id != legalCases.CaseNumber)
            {
                Notify("The given id is not the same as what was passed in the query.");
                return false;
            }

            if (!RunValidation(new CaseValidation(), legalCases)) return false;

            await _legalCasesRepository.Update(legalCases);
            return true;
        }

        public async Task<bool> Delete(string id)
        {
            await _legalCasesRepository.Delete(id);
            return true;
        }

        public void Dispose()
        {
            _legalCasesRepository?.Dispose();
        }
    }
}