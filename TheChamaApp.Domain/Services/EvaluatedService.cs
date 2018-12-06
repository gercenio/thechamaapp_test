using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Dapper;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class EvaluatedService : Base.Service<Evaluated>, IEvaluatedService
    {
        #region # Propriedades
        private readonly IEvaluatedRepository _Repository;
        private readonly IEvaluatedDapperRepository _Dapper;
        #endregion

        #region # Constructor
        public EvaluatedService(IEvaluatedRepository repository,
            IEvaluatedDapperRepository dapper) : base(repository)
        {
            _Repository = repository;
            _Dapper = dapper;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Obtem o grafico individual
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        public ViewModel.IndividualGraficEvaluatedHeader GetIndividualGrafic(int EvaluatedId)
        {
            var retorno = new ViewModel.IndividualGraficEvaluatedHeader() {
                Header = _Repository.GetAll().Where(m => m.EvaluatedId == EvaluatedId).Single(),
                Body = _Dapper.GetBodyReport(EvaluatedId).ToList()

            };
            return retorno;
        }

        #endregion
    }
}
