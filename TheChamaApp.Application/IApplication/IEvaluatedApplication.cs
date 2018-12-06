using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Application.IApplication
{
    public interface IEvaluatedApplication : Base.IAppServiceBase<Evaluated>
    {
        IndividualGraficEvaluatedHeader GetIndividualGrafic(int EvaluatedId);
    }
}
