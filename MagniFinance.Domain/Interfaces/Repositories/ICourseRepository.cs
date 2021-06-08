using MagniFinance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Domain.Interfaces
{
    public interface ICourseRepository : IBaseRepository<Course>
    {
        Task<IEnumerable<Course>> SelectAllWithIncludes();
    }
}
