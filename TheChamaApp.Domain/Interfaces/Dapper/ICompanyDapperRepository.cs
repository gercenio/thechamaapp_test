using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Domain.Interfaces.Dapper
{
    public interface ICompanyDapperRepository
    {
        IEnumerable<CompanyQuizResultViewModel> GetAllQuizResult(int CompanyId, int CompanyUnityId, int LevelEvaluatedId);
    }
}
