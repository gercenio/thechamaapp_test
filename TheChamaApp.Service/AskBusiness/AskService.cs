using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.AskBusiness
{
    public class AskService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IAskApplication _IAskApplication;
        #endregion

        #region # Constructor
        public AskService(IAskApplication askApplication)
        {
            _IAskApplication = askApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza uma inclusão ou alteração
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Ask IncluirOuAlterar(Domain.Entities.Ask Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                if (Entity.AskId > 0)
                {
                    _IAskApplication.Update(Entity);
                }
                else {
                    _IAskApplication.Add(Entity);
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a exclusão de uma resposta
        /// </summary>
        /// <param name="AskId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int AskId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var AskEntity = _IAskApplication.GetAll().Where(m => m.AskId == AskId).Single();
                _IAskApplication.Remove(AskEntity);
                Mensagem = "Done";
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obter uma resposta
        /// </summary>
        /// <param name="AskId"></param>
        /// <returns></returns>
        public Domain.Entities.Ask Obter(int AskId)
        {
            return _IAskApplication.GetAll().Where(m => m.AskId == AskId).Single();
        }

        #endregion
    }
}
