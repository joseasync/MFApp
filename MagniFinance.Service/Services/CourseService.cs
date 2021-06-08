using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Service.Services
{
    public class CourseService : BaseService<Course>, ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository repository) : base(repository)
        {
            _courseRepository = repository;
        }

        public override async Task<IEnumerable<Course>> GetAll()
        {
            return await _courseRepository.SelectAllWithIncludes();
        }

    }
}
