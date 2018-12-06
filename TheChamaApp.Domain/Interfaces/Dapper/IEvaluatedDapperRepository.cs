using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Domain.Interfaces.Dapper
{
    public interface IEvaluatedDapperRepository
    {
        IEnumerable<IndividualGraficEvaluatedBody> GetBodyReport(int EvaluatedId);
    }
}
