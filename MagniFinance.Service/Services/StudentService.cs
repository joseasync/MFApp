using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Service.Services
{
    public class StudentService : BaseService<Student>, IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository repository) : base(repository)
        {
            _studentRepository = repository;
        }

        public override async Task<IEnumerable<Student>> GetAll()
        {
            return  await _studentRepository.SelectAllWithIncludes();
        }

    }
}
