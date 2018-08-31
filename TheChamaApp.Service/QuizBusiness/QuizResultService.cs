using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.QuizBusiness
{
    public class QuizResultService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly IQuizResultApplication _IQuizResultApplication;
        private readonly IAskApplication _IAskApplication;
        private readonly IAnswerApplication _IAnswerApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly IQuizApplication _IQuizApplication;

        #endregion

        #region # Constructor

        public QuizResultService(IQuizResultApplication quizResultApplication
            , IAskApplication askApplication
            , IAnswerApplication answerApplication
            , IEvaluatedApplication evaluatedApplication
            , IQuizApplication quizApplication)
        {
            _IQuizResultApplication = quizResultApplication;
            _IAskApplication = askApplication;
            _IAnswerApplication = answerApplication;
            _IEvaluatedApplication = evaluatedApplication;
            _IQuizApplication = quizApplication;
        }

        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um resultado
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.QuizResult Incluir(Domain.Entities.QuizResult Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                _IQuizResultApplication.Add(Entity);
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a alteração de uma resultado
        /// </summary>
        /// <param name="QuizResultId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.QuizResult Alterar(int QuizResultId, Domain.Entities.QuizResult Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IQuizResultApplication.GetAll().Where(m => m.QuizResultId == QuizResultId).Single();
                if (Original != null)
                {
                    Entity.QuizResultId = QuizResultId;
                    _IQuizResultApplication.Update(Entity);
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a exclusão
        /// </summary>
        /// <param name="QuizResultId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int QuizResultId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IQuizResultApplication.GetAll().Where(m => m.QuizResultId == QuizResultId).Single();
                _IQuizResultApplication.Remove(Original);
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obter um resultado das pesquisas
        /// </summary>
        /// <param name="QuizResultId"></param>
        /// <returns></returns>
        public Domain.Entities.QuizResult Obter(int QuizResultId)
        {
            try
            {
                var Original = _IQuizResultApplication.GetAll().Where(m => m.QuizResultId == QuizResultId).Single();
                if (Original.QuizId > 0)
                {
                    Original.Quiz = _IQuizApplication.GetAll().Where(m => m.QuizId == Original.QuizId).Single();
                }
                if (Original.AskId > 0)
                {
                    Original.Ask = _IAskApplication.GetAll().Where(m => m.AskId == Original.AskId).Single();
                }
                if (Original.AnswerId > 0)
                {
                    Original.Answer = _IAnswerApplication.GetAll().Where(m => m.AnswerId == Original.AnswerId).Single();
                }
                if (Original.EvaluatedId.HasValue)
                {
                    if (Original.EvaluatedId.Value > 0)
                    {
                        Original.Evaluated = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == Original.EvaluatedId).Single();
                    }
                }
                return Original;
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// Obtem os dados resposta
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.QuizResult> ObterTodos()
        {
            List<Domain.Entities.QuizResult> lista = new List<Domain.Entities.QuizResult>();
            foreach (var item in _IQuizResultApplication.GetAll())
            {
                lista.Add(this.Obter(item.QuizResultId));
            }
            return lista;
        }

        #endregion
    }
}
