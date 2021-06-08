using MagniFinance.Data.Context;
using MagniFinance.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using MagniFinance.Domain.Interfaces;
using System.Threading.Tasks;

namespace MagniFinance.Data.Repository
{
    public class CourseRepository : BaseRepository<Course>, ICourseRepository
    {
        public CourseRepository(ConnectionContext conection) : base(conection)
        {
        }

        public async Task<IEnumerable<Course>> SelectAllWithIncludes()
        {
            return await _connection.Courses.Include(i => i.Subjects).ToListAsync();
        }
    }
}
