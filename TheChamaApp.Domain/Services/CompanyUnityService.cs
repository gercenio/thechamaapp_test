﻿using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class CompanyUnityService : Base.Service<CompanyUnity>, ICompanyUnityService
    {
        #region Propriedades
        private readonly ICompanyUnityRepository _Repository;
        #endregion

        #region # Constructor
        public CompanyUnityService(ICompanyUnityRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
