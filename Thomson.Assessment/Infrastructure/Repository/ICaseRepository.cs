using System.Collections.Generic;
using System.Threading.Tasks;
using Thomson.Assessment.Model;

namespace Thomson.Assessment.Infrastructure.DAL
{
    public interface ICaseRepository
    {
        Task<IEnumerable<Case>> GetAll();
        Task<Case> Get(string caseNumber);

        Task<bool> Create(Case myCase);

        Task<bool> Update(Case myCase);

        Task<bool> Delete(string caseNumber);
    }
}