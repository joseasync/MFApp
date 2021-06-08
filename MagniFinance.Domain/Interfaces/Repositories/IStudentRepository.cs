using MagniFinance.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Domain.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        Task<IEnumerable<Student>> SelectAllWithIncludes();
    }
}
