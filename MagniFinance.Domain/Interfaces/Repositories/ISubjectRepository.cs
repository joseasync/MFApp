using MagniFinance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Domain.Interfaces
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        Task<IEnumerable<Subject>> SelectAllWithIncludes();
    }
}
