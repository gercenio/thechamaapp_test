using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service.Base;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Domain.Interfaces.Service
{
    public interface IEvaluatedService : IService<Evaluated>
    {
        IndividualGraficEvaluatedHeader GetIndividualGrafic(int EvaluatedId);
    }
}
