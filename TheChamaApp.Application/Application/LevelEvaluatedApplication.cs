using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class LevelEvaluatedApplication : Base.AppServiceBase<LevelEvaluated>, ILevelEvaluatedApplication
    {
        private readonly ILevelEvaluatedService _Service;

        public LevelEvaluatedApplication(ILevelEvaluatedService service) : base(service)
        {
            _Service = service;
        }
    }
}
