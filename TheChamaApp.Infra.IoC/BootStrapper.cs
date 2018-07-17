using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.Application;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;
using TheChamaApp.Domain.Services;
using TheChamaApp.Infra.Data.Contexto;
using TheChamaApp.Infra.Data.Interfaces;
using TheChamaApp.Infra.Data.Interfaces.Contexto;
using TheChamaApp.Infra.Data.Repository;

namespace TheChamaApp.Infra.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            //register module User
            container.Register<IUserApplication, UserApplication>(Lifestyle.Scoped);
            container.Register<IUserService, UserService>(Lifestyle.Scoped);
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            //Company
            container.Register<ICompanyApplication, CompanyApplication>(Lifestyle.Scoped);
            container.Register<ICompanyService, CompanyService>(Lifestyle.Scoped);
            container.Register<ICompanyRepository, CompanyRepository>(Lifestyle.Scoped);

            //Student
            container.Register<IStudentApplication, StudentApplication>(Lifestyle.Scoped);
            container.Register<IStudentService, StudentService>(Lifestyle.Scoped);
            container.Register<IStudentRepository, StudentRepository>(Lifestyle.Scoped);
            //Course
            container.Register<ICourseApplication, CourseApplication>(Lifestyle.Scoped);
            container.Register<ICourseService, CourseService>(Lifestyle.Scoped);
            container.Register<ICourseRepository, CourseRepository>(Lifestyle.Scoped);
            //Teacher
            container.Register<ITeacherApplication, TeacherApplication>(Lifestyle.Scoped);
            container.Register<ITeacherService, TeacherService>(Lifestyle.Scoped);
            container.Register<ITeacherRepository, TeacherRepository>(Lifestyle.Scoped);
            //RellationshipCourseTeacher
            container.Register<IRellationshipCourseTeacherApplication, RellationshipCourseTeacherApplication>(Lifestyle.Scoped);
            container.Register<IRellationshipCourseTeacherService, RellationshipCourseTeacherService>(Lifestyle.Scoped);
            container.Register<IRellationshipCourseTeacherRepository, RellationshipCourseTeacherRepository>(Lifestyle.Scoped);
            //RellationshipStudentCourse
            container.Register<IRellationshipStudentCourseApplication, RellationshipStudentCourseApplication>(Lifestyle.Scoped);
            container.Register<IRellationshipStudentCourseService, RellationshipStudentCourseService>(Lifestyle.Scoped);
            container.Register<IRellationshipStudentCourseRepository, RellationshipStudentCourseRepository>(Lifestyle.Scoped);

            container.Register<IDapperContexto, DapperContexto>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

        }
    }
}
