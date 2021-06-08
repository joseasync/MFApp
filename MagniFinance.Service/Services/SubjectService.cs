using MagniFinance.Domain.Entities;
using MagniFinance.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MagniFinance.Service.Services
{
    public class SubjectService : BaseService<Subject>, ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectService(ISubjectRepository repository) : base(repository)
        {
            _subjectRepository = repository;
        }

        public override async Task<IEnumerable<Subject>> GetAll()
        {
            return  await _subjectRepository.SelectAllWithIncludes();
        }

    }
}
