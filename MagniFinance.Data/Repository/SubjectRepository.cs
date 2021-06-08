using MagniFinance.Data.Context;
using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace MagniFinance.Data.Repository
{
    public class SubjectRepository : BaseRepository<Subject>, ISubjectRepository
    {
        public SubjectRepository(ConnectionContext conection) : base(conection)
        {
        }

        public async Task<IEnumerable<Subject>> SelectAllWithIncludes()
        {
            return await _connection.Subjects.Include(i => i.Teacher).Include(i => i.Grades).ToListAsync();
        }
    }
}
