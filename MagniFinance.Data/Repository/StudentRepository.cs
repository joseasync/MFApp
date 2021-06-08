using MagniFinance.Data.Context;
using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MagniFinance.Data.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(ConnectionContext conection) : base(conection)
        {
        }

        public async Task<IEnumerable<Student>> SelectAllWithIncludes()
        {
            return await _connection.Students.Include(i => i.Grades.Select(x => x.Subject)).ToListAsync();
        }
    }
}
