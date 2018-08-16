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
        #endregion

        #region # Constructor
        public ResultQuestionsService(IResultQuestionsApplication resultQuestionsApplication)
        {
            _IResultQuestionsApplication = resultQuestionsApplication;
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

        #endregion
    }
}
