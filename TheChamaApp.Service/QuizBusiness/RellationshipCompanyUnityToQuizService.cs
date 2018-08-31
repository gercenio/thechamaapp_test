using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.QuizBusiness
{
    public class RellationshipCompanyUnityToQuizService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IRellationshipCompanyUnityToQuizApplication _IRellationshipCompanyUnityToQuizApplication;
        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuizService(IRellationshipCompanyUnityToQuizApplication rellationshipCompanyUnityToQuizApplication)
        {
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza inclusão de dados
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipCompanyUnityToQuiz Incluir(Domain.Entities.RellationshipCompanyUnityToQuiz Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                _IRellationshipCompanyUnityToQuizApplication.Add(Entity);
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;

        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuizId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int RellationshipCompanyUnityToQuizId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Entity = _IRellationshipCompanyUnityToQuizApplication.GetAll().Where(m => m.RellationshipCompanyUnityToQuizId == RellationshipCompanyUnityToQuizId).Single();
                _IRellationshipCompanyUnityToQuizApplication.Remove(Entity);
                Mensagem = "Done";
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }
        

        #endregion

    }
}
