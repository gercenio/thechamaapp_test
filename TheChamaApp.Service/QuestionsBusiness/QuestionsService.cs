using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.QuestionsBusiness
{
    public class QuestionsService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IQuestionsApplication _IQuestionsApplication;
        #endregion

        #region # Constructor
        public QuestionsService(IQuestionsApplication questionsApplication)
        {
            _IQuestionsApplication = questionsApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de uma nova pergunta
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Questions IncluirOuAlterar(Domain.Entities.Questions Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                if (Entity.QuestionsId > 0)
                {
                    _IQuestionsApplication.Update(Entity);
                }
                else
                {
                    _IQuestionsApplication.Add(Entity);
                }
                Mensagem = "Done";
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}",Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Exclui uma pergunta
        /// </summary>
        /// <param name="QuestionsId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int QuestionsId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var QuestionsEntity = _IQuestionsApplication.GetAll().Where(m => m.QuestionsId == QuestionsId).Single();
                _IQuestionsApplication.Remove(QuestionsEntity);
                Mensagem = "Done";
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}",Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma perguntas
        /// </summary>
        /// <param name="QuestionId"></param>
        /// <returns></returns>
        public Domain.Entities.Questions Obter(int QuestionId)
        {
            return _IQuestionsApplication.GetAll().Where(m => m.QuestionsId == QuestionId).Single();
        }

        /// <summary>
        /// Realiza a alteração de uma questionario
        /// </summary>
        /// <param name="QuestionsId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Questions Alterar(int QuestionsId, Domain.Entities.Questions Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var OrginalList = _IQuestionsApplication.GetAll().Where(m => m.QuestionsId == QuestionsId).ToList();
                if (OrginalList.Count > 0)
                {
                    Entity.QuestionsId = OrginalList[0].QuestionsId;
                    _IQuestionsApplication.Update(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }


        #endregion
    }
}
