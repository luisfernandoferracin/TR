using System;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface ILegalCasesService : IDisposable
    {
        Task<bool> Create(Case legalCases);
        Task<bool> Update(string id, Case legalCases);
        Task<bool> Delete(string id);
    }
}