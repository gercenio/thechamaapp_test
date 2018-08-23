using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.QuestionsBusiness
{
    public class ResultQuestionsService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly IResultQuestionsApplication _IResultQuestionsApplication;
        private readonly IAskApplication _IAskApplication;
        private readonly IAnswerApplication _IAnswerApplication;
        private readonly IQuestionsApplication _IQuestionsApplication;

        #endregion

        #region # Constructor
        public ResultQuestionsService(IResultQuestionsApplication resultQuestionsApplication
            , IAskApplication askApplication
            , IAnswerApplication answerApplication
            , IQuestionsApplication questionsApplication)
        {
            _IResultQuestionsApplication = resultQuestionsApplication;
            _IAskApplication = askApplication;
            _IAnswerApplication = answerApplication;
            _IQuestionsApplication = questionsApplication;

        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de uma resposta de questionario
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.ResultQuestions Incluir(Domain.Entities.ResultQuestions Entity, out string Mensagem)
        {
            try
            {
                _IResultQuestionsApplication.Add(Entity);
                Mensagem = Entity.ResultQuestionsId.ToString();
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Alterar os dados
        /// </summary>
        /// <param name="ResultQuestionsId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.ResultQuestions Alterar(int ResultQuestionsId, Domain.Entities.ResultQuestions Entity, out string Mensagem)
        {
            try
            {
                var Original = _IResultQuestionsApplication.GetAll().Where(m => m.ResultQuestionsId == ResultQuestionsId).Single();
                if (Original != null)
                {
                    Entity.ResultQuestionsId = Original.ResultQuestionsId;
                    _IResultQuestionsApplication.Update(Entity);
                    Mensagem = "Done";
                }
                else {
                    Mensagem = "Invalid data !!!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Deleta um registro
        /// </summary>
        /// <param name="ResultQuestionsId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int ResultQuestionsId, out string Mensagem)
        {
            try
            {
                var Orginal = _IResultQuestionsApplication.GetAll().Where(m => m.ResultQuestionsId == ResultQuestionsId).Single();
                if (Orginal != null)
                {
                    _IResultQuestionsApplication.Remove(Orginal);
                    Mensagem = "Done";
                }
                else {
                    Mensagem = "Invalid data !!!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista de Resultados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.ResultQuestions> ObterTodos()
        {
            return _IResultQuestionsApplication.GetAll();
        }

        /// <summary>
        /// Obtem um questionario
        /// </summary>
        /// <param name="ResultQuestionsId"></param>
        /// <returns></returns>
        public Domain.Entities.ResultQuestions Obter(int ResultQuestionsId)
        {
            var Entity = _IResultQuestionsApplication.GetAll().Where(m => m.ResultQuestionsId == ResultQuestionsId).Single();
            Entity.Answer = _IAnswerApplication.GetAll().Where(m => m.AnswerId == Entity.AnswerId).Single();
            Entity.Ask = _IAskApplication.GetAll().Where(m => m.AskId == Entity.AskId).Single();
            Entity.Questions = _IQuestionsApplication.GetAll().Where(m => m.QuestionsId == Entity.QuestionsId).Single();

            return Entity;
        }

        #endregion
    }
}
