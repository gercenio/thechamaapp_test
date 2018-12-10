using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.Application;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Interfaces.Authorization;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;
using TheChamaApp.Domain.Services;
using TheChamaApp.Infra.Data.Contexto;
using TheChamaApp.Infra.Data.Interfaces;
using TheChamaApp.Infra.Data.Interfaces.Contexto;
using TheChamaApp.Infra.Data.Repository;
using MediatR;
using System.Reflection;
using System.Net.NetworkInformation;
using System.IO;
using System.Linq;
using MediatR.Pipeline;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using TheChamaApp.Infra.Data.Dapper;
using TheChamaApp.Domain.Interfaces.Dapper;

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
            container.Register<ICompanyAddressApplication, CompanyAddressApplication>(Lifestyle.Scoped);
            container.Register<ICompanyAddressService, CompanyAddressService>(Lifestyle.Scoped);
            container.Register<ICompanyAddressRepository, CompanyAddressRepository>(Lifestyle.Scoped);
            container.Register<ICompanyContactApplication, CompanyContactApplication>(Lifestyle.Scoped);
            container.Register<ICompanyContactService, CompanyContactService>(Lifestyle.Scoped);
            container.Register<ICompanyContactRepository, CompanyContactRepository>(Lifestyle.Scoped);
            container.Register<ICompanyUnityApplication, CompanyUnityApplication>(Lifestyle.Scoped);
            container.Register<ICompanyUnityService, CompanyUnityService>(Lifestyle.Scoped);
            container.Register<ICompanyUnityRepository, CompanyUnityRepository>(Lifestyle.Scoped);
            //state
            container.Register<IStateApplication, StateApplication>(Lifestyle.Scoped);
            container.Register<IStateService, StateService>(Lifestyle.Scoped);
            container.Register<IStateRepository, StateRepository>(Lifestyle.Scoped);
            
            //ask
            container.Register<IAskApplication, AskApplication>(Lifestyle.Scoped);
            container.Register<IAskService, AskService>(Lifestyle.Scoped);
            container.Register<IAskRepository, AskRepository>(Lifestyle.Scoped);

            //group ask
            container.Register<IGroupAskApplication, GroupAskApplication>(Lifestyle.Scoped);
            container.Register<IGroupAskService, GroupAskService>(Lifestyle.Scoped);
            container.Register<IGroupAskRepository, GroupAskRepository>(Lifestyle.Scoped);

            //company type
            container.Register<ICompanyTypeApplication, CompanyTypeApplication>(Lifestyle.Scoped);
            container.Register<ICompanyTypeService, CompanyTypeService>(Lifestyle.Scoped);
            container.Register<ICompanyTypeRepository, CompanyTypeRepository>(Lifestyle.Scoped);
            //answer
            container.Register<IAnswerApplication, AnswerApplication>(Lifestyle.Scoped);
            container.Register<IAnswerService, AnswerService>(Lifestyle.Scoped);
            container.Register<IAnswerRepository, AnswerRepository>(Lifestyle.Scoped);
            //evaluated
            container.Register<IEvaluatedApplication, EvaluatedApplication>(Lifestyle.Scoped);
            container.Register<IEvaluatedService, EvaluatedService>(Lifestyle.Scoped);
            container.Register<IEvaluatedRepository, EvaluatedRepository>(Lifestyle.Scoped);
            //rellationshipasktoanswer
            container.Register<IRellationshipAskToAnswerApplication, RellationshipAskToAnswerApplication>(Lifestyle.Scoped);
            container.Register<IRellationshipAskToAnswerService, RellationshipAskToAnswerService>(Lifestyle.Scoped);
            container.Register<IRellationshipAskToAnswerRepository, RellationshipAskToAnswerRepository>(Lifestyle.Scoped);
            //company image
            container.Register<ICompanyImageApplication, CompanyImageApplication>(Lifestyle.Scoped);
            container.Register<ICompanyImageService, CompanyImageService>(Lifestyle.Scoped);
            container.Register<ICompanyImageRepository, CompanyImageRepository>(Lifestyle.Scoped);
            // level evaluated
            container.Register<ILevelEvaluatedApplication, LevelEvaluatedApplication>(Lifestyle.Scoped);
            container.Register<ILevelEvaluatedService, LevelEvaluatedService>(Lifestyle.Scoped);
            container.Register<ILevelEvaluatedRepository, LevelEvaluatedRepository>(Lifestyle.Scoped);
            // login
            container.Register<ILoginApplication, LoginApplication>(Lifestyle.Scoped);
            container.Register<ILoginService, LoginService>(Lifestyle.Scoped);
            container.Register<ILoginRepository, LoginRepository>(Lifestyle.Scoped);
            
            // quiz
            container.Register<IQuizApplication, QuizApplication>(Lifestyle.Scoped);
            container.Register<IQuizService, QuizService>(Lifestyle.Scoped);
            container.Register<IQuizRepository, QuizRepository>(Lifestyle.Scoped);
            // rellationship quiz
            container.Register<IRellationshipQuizToAskApplication, RellationshipQuizToAskApplication>(Lifestyle.Scoped);
            container.Register<IRellationshipQuizToAskService, RellationshipQuizToAskService>(Lifestyle.Scoped);
            container.Register<IRellationshipQuizToAskRepository, RellationshipQuizToAskRepository>(Lifestyle.Scoped);
            //rellationship companyUnity to quiz service
            container.Register<IRellationshipCompanyUnityToQuizApplication, RellationshipCompanyUnityToQuizApplication>(Lifestyle.Scoped);
            container.Register<IRellationshipCompanyUnityToQuizService, RellationshipCompanyUnityToQuizService>(Lifestyle.Scoped);
            container.Register<IRellationshipCompanyUnityToQuizRepository, RellationshipCompanyUnityToQuizRepository>(Lifestyle.Scoped);
            // quiz result    
            container.Register<IQuizResultApplication, QuizResultApplication>(Lifestyle.Scoped);
            container.Register<IQuizResultService, QuizResultService>(Lifestyle.Scoped);
            container.Register<IQuizResultRepository, QuizResultRepository>(Lifestyle.Scoped);
            //IRellationshipEvaluatedToUpEvaluatedApplication
            container.Register<IRellationshipEvaluatedToUpEvaluatedApplication, RellationshipEvaluatedToUpEvaluatedApplication>(Lifestyle.Scoped);
            container.Register<IRellationshipEvaluatedToUpEvaluatedService, RellationshipEvaluatedToUpEvaluatedService>(Lifestyle.Scoped);
            container.Register<IRellationshipEvaluatedToUpEvaluatedRepository, RellationshipEvaluatedToUpEvaluatedRepository>(Lifestyle.Scoped);
            //ConfigurationSettings
            container.Register<IConfigurationSettingsApplication, ConfigurationSettingsApplication>(Lifestyle.Scoped);
            container.Register<IConfigurationSettingsService, ConfigurationSettingsService>(Lifestyle.Scoped);
            container.Register<IConfigurationSettingsRepository, ConfigurationSettingsRepository>(Lifestyle.Scoped);
            //RellationshipQuizToEvaluated
            container.Register<IRellationshipQuizToEvaluatedApplication, RellationshipQuizToEvaluatedApplication>(Lifestyle.Scoped);
            container.Register<IRellationshipQuizToEvaluatedService, RellationshipQuizToEvaluatedService>(Lifestyle.Scoped);
            container.Register<IRellationshipQuizToEvaluatedRepository, RellationshipQuizToEvaluatedRepository>(Lifestyle.Scoped);
            //Dapper
            container.Register<ICompanyDapperRepository, CompanyDapperRepository>(Lifestyle.Scoped);
            container.Register<IEvaluatedDapperRepository, EvaluatedDapperRepository>(Lifestyle.Scoped);
            //Identity - Provider
            //container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            //container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()));
            //container.RegisterPerWebRequest<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>());

            //container.Register<TheChamaApp.Infra.CrossCutting.Identity.Model. ApplicationRoleManager>(Lifestyle.Scoped);
            //container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            //container.Register<ApplicationSignInManager>(Lifestyle.Scoped);

            // Context
            container.Register<IDapperContexto, DapperContexto>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            

        }

        
    }
}
