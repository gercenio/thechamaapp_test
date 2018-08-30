using System;
using System.Linq;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.QuizBusiness
{
    public class RellationshipQuizToAskService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IRellationshipQuizToAskApplication _IRellationshipQuizToAskApplication;
        #endregion

        #region # Constructor
        public RellationshipQuizToAskService(IRellationshipQuizToAskApplication rellationshipQuizToAskApplication)
        {
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de uma relacionamento
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipQuizToAsk Incluir(Domain.Entities.RellationshipQuizToAsk Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var OriginalList = _IRellationshipQuizToAskApplication.GetAll().Where(m => m.AskId == Entity.AskId && m.QuizId == Entity.QuizId).ToList();
                if (OriginalList.Count == 0)
                {
                    _IRellationshipQuizToAskApplication.Add(Entity);
                    Mensagem = Entity.RellationshipQuizToAskId.ToString();
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a exclusão de um relacionamento
        /// </summary>
        /// <param name="RellationshipQuizToAskId"></param>
        public void Excluir(int RellationshipQuizToAskId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IRellationshipQuizToAskApplication.GetAll().Where(m => m.RellationshipQuizToAskId == RellationshipQuizToAskId).Single();
                if (Original != null)
                {
                    _IRellationshipQuizToAskApplication.Remove(Original);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        #endregion

    }
}
