using Business.Interfaces;
using Business.Models;
using Data.Context;

namespace Data.Repository
{
    public class LegalCasesRepository : Repository<Case>, ILegalCasesRepository
    {
        public LegalCasesRepository(MyDbContext context) : base(context) { }        
    }
}