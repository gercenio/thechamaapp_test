using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.QuestionsBusiness
{
    public class RellationshipCompanyUnityToQuestionsService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IRellationshipCompanyUnityToQuestionsApplication _IRellationshipCompanyUnityToQuestionsApplication;
        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuestionsService(IRellationshipCompanyUnityToQuestionsApplication rellationshipCompanyUnityToQuestionsApplication)
        {
            _IRellationshipCompanyUnityToQuestionsApplication = rellationshipCompanyUnityToQuestionsApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de uma novo relacionamento
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipCompanyUnityToQuestions Incluir(Domain.Entities.RellationshipCompanyUnityToQuestions Entity
            , out string Mensagem)
        {
            try
            {
                var Chk = _IRellationshipCompanyUnityToQuestionsApplication.GetAll().Where(m => m.CompanyUnityId == Entity.CompanyUnityId && m.QuestionsId == Entity.QuestionsId).ToList();
                if (Chk.Count == 0)
                {
                    _IRellationshipCompanyUnityToQuestionsApplication.Add(Entity);
                    Mensagem = Entity.RellationshipCompanyUnityToQuestionsId.ToString();
                }
                else {
                    Mensagem = "Existed rellation !!!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Atualiza os dados
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuestionsId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipCompanyUnityToQuestions Alterar(int RellationshipCompanyUnityToQuestionsId
            ,Domain.Entities.RellationshipCompanyUnityToQuestions Entity
            ,out string Mensagem)
        {
            try
            {
                var Original = _IRellationshipCompanyUnityToQuestionsApplication.GetAll().Where(m => m.RellationshipCompanyUnityToQuestionsId == RellationshipCompanyUnityToQuestionsId).Single();
                if (Original != null)
                {
                    _IRellationshipCompanyUnityToQuestionsApplication.Update(Entity);
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
        /// Obtem um relacionamento
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuestionsId"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipCompanyUnityToQuestions Obter(int RellationshipCompanyUnityToQuestionsId)
        {
            return _IRellationshipCompanyUnityToQuestionsApplication.GetAll().Where(m => m.RellationshipCompanyUnityToQuestionsId == RellationshipCompanyUnityToQuestionsId).Single();
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuestionsId"></param>
        public void Excluir(int RellationshipCompanyUnityToQuestionsId)
        {
            try
            {
                var Entity = _IRellationshipCompanyUnityToQuestionsApplication.GetAll().Where(m => m.RellationshipCompanyUnityToQuestionsId == RellationshipCompanyUnityToQuestionsId).Single();
                if(Entity != null)
                {
                    _IRellationshipCompanyUnityToQuestionsApplication.Remove(Entity);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        #endregion

    }
}
