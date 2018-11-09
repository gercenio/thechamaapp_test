using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.EvaluatedBusiness
{
    public class RellationshipQuizToEvaluatedService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly IRellationshipQuizToEvaluatedApplication _IRellationshipQuizToEvaluatedApplication;
        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _IRellationshipEvaluatedToUpEvaluatedApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly IQuizApplication _IQuizApplication;

        #endregion

        #region # Constructor
        public RellationshipQuizToEvaluatedService(IRellationshipQuizToEvaluatedApplication rellationshipQuizToEvaluatedApplication
            , IRellationshipEvaluatedToUpEvaluatedApplication rellationshipEvaluatedToUpEvaluatedApplication
            , IEvaluatedApplication evaluatedApplication
            , IQuizApplication quizApplication)
        {
            _IRellationshipQuizToEvaluatedApplication = rellationshipQuizToEvaluatedApplication;
            _IRellationshipEvaluatedToUpEvaluatedApplication = rellationshipEvaluatedToUpEvaluatedApplication;
            _IEvaluatedApplication = evaluatedApplication;
            _IQuizApplication = quizApplication;
        }
        #endregion

        #region # Methods

        public void Incluir(int CompanyUnityId)
        {

        }

        /// <summary>
        /// Retorna uma lista de formularios passando o Id do avaliado
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.RellationshipQuizToEvaluated> ObterTodos(int EvaluatedId)
        {
            List<Domain.Entities.RellationshipQuizToEvaluated> lista = new List<Domain.Entities.RellationshipQuizToEvaluated>();
            try
            {
                foreach (var item in _IRellationshipQuizToEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).ToList())
                {
                    if (item.QuizId > 0) {
                        item.Quiz = _IQuizApplication.GetAll().Where(m => m.QuizId == item.QuizId).Single();
                    }
                    if (item.SubordinatedId > 0) {
                        item.Subordinated = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == item.SubordinatedId).Single();
                    }
                    lista.Add(item);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return lista;
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="RellationshipQuizToEvaluatedId"></param>
        public void Excluir(int RellationshipQuizToEvaluatedId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IRellationshipQuizToEvaluatedApplication.GetAll().Where(m => m.RellationshipQuizToEvaluatedId == RellationshipQuizToEvaluatedId).Single();
                if (Original != null) {
                    _IRellationshipQuizToEvaluatedApplication.Remove(Original);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        #endregion

    }
}
