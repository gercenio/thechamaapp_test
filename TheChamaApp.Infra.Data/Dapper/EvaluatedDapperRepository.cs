using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Infra.Data.Dapper
{
    public class EvaluatedDapperRepository : Base.DapperRepository, Domain.Interfaces.Dapper.IEvaluatedDapperRepository
    {
        /// <summary>
        /// Obtem uma lista de detalhes do grafico individual
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        public IEnumerable<IndividualGraficEvaluatedBody> GetBodyReport(int EvaluatedId)
        {
            return ExecuteSelect<IndividualGraficEvaluatedBody>("sp_getindidualgraficbyevaluated", new { EvaluatedId = EvaluatedId });
        }
    }
}
