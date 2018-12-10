using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.ViewModel;
using TheChamaApp.Infra.CrossCutting.ViewModel;

namespace TheChamaApp.Infra.Data.Dapper
{
    public class CompanyDapperRepository : Base.DapperRepository , Domain.Interfaces.Dapper.ICompanyDapperRepository
    {
        /// <summary>
        /// Obtem uma lista de resultados
        /// </summary>
        /// <param name="CompanyId"></param>
        /// <returns></returns>
        public IEnumerable<CompanyQuizResultViewModel> GetAllQuizResult(int CompanyId, int CompanyUnityId ,int LevelEvaluatedId)
        {
            return ExecuteSelect<CompanyQuizResultViewModel>("sp_getallresultquiztocompanyunity", new { CompanyId = CompanyId, CompanyUnityId = CompanyUnityId, LevelEvaluatedId = LevelEvaluatedId });
        }
    }
}
