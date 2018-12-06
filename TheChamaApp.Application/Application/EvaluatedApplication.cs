using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Application.Application
{
    public class EvaluatedApplication : Base.AppServiceBase<Evaluated>, IEvaluatedApplication
    {
        #region # Propriedades
        private readonly IEvaluatedService _Service;
        #endregion

        #region # Constructor
        public EvaluatedApplication(IEvaluatedService service) : base(service)
        {
            _Service = service;
        }
        #endregion

        #region # Methods
        public IndividualGraficEvaluatedHeader GetIndividualGrafic(int EvaluatedId)
        {
            return _Service.GetIndividualGrafic(EvaluatedId);
        }
        #endregion
    }
}
