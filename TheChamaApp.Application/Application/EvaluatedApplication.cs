using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class EvaluatedApplication : Base.AppServiceBase<Evaluated>, IEvaluatedApplication
    {
        private readonly IEvaluatedService _Service;

        public EvaluatedApplication(IEvaluatedService service) : base(service)
        {
            _Service = service;
        }
    }
}
