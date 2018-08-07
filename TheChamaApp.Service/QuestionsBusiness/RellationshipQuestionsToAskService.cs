using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.QuestionsBusiness
{
    public class RellationshipQuestionsToAskService : Base.ServiceBase
    {
        private readonly IRellationshipQuestionsToAskApplication _IRellationshipQuestionsToAskApplication;

        public RellationshipQuestionsToAskService(IRellationshipQuestionsToAskApplication rellationshipQuestionsToAskApplication)
        {
            _IRellationshipQuestionsToAskApplication = rellationshipQuestionsToAskApplication;
        }

        /// <summary>
        /// Realiza a inclusão de um registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void Incluir(Domain.Entities.RellationshipQuestionsToAsk Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IRellationshipQuestionsToAskApplication.GetAll().Where(m => m.AskId == Entity.AskId && m.QuestionsId == Entity.QuestionsId).ToList();
                if (Original.Count == 0)
                {
                    _IRellationshipQuestionsToAskApplication.Add(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Atualiza as informações
        /// </summary>
        /// <param name="RellationshipId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void Alterar(int RellationshipId, Domain.Entities.RellationshipQuestionsToAsk Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IRellationshipQuestionsToAskApplication.GetAll().Where(m => m.RellationshipQuestionsToAskId == RellationshipId).ToList();
                if (Original.Count > 0)
                {
                    Entity.RellationshipQuestionsToAskId = RellationshipId;
                    _IRellationshipQuestionsToAskApplication.Update(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Detela um relacionamento
        /// </summary>
        /// <param name="RellationId"></param>
        /// <param name="Mensagem"></param>
        public void Delete(int RellationId,out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Entity = _IRellationshipQuestionsToAskApplication.GetAll().Where(m => m.RellationshipQuestionsToAskId == RellationId).ToList();
                if (Entity.Count > 0)
                {
                    _IRellationshipQuestionsToAskApplication.Remove(Entity[0]);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }
        

    }
}
