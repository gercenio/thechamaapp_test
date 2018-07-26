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
            //questions
            container.Register<IQuestionsApplication, QuestionsApplication>(Lifestyle.Scoped);
            container.Register<IQuestionsService, QuestionsService>(Lifestyle.Scoped);
            container.Register<IQuestionsRepository, QuestionsRepository>(Lifestyle.Scoped);
            //ask
            container.Register<IAskApplication, AskApplication>(Lifestyle.Scoped);
            container.Register<IAskService, AskService>(Lifestyle.Scoped);
            container.Register<IAskRepository, AskRepository>(Lifestyle.Scoped);

            container.Register<IDapperContexto, DapperContexto>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

        }
    }
}
