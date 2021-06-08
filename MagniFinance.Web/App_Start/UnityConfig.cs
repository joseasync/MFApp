using MagniFinance.Data.Repository;
using MagniFinance.Domain.Interfaces;
using MagniFinance.Service.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MagniFinance.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            container.RegisterType(typeof(IBaseService<>), typeof(BaseService<>));
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<ICourseService, CourseService>();
            container.RegisterType<ISubjectService, SubjectService>();

            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<ICourseRepository, CourseRepository>();
            container.RegisterType<ISubjectRepository, SubjectRepository>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}