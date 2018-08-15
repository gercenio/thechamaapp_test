using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;
using TheChamaApp.Domain.Entities;

namespace TheChamaApp.Service.AskBusiness
{
    public class RellationshipAskToAnswerService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IRellationshipAskToAnswerApplication _IRellationshipAskToAnswerApplication;
        #endregion

        #region # Constructor
        public RellationshipAskToAnswerService(IRellationshipAskToAnswerApplication rellationshipAskToAnswerApplication)
        {
            _IRellationshipAskToAnswerApplication = rellationshipAskToAnswerApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        public void Incluir(Domain.Entities.RellationshipAskToAnswer Entity, out string Mensagem)
        {
            try
            {
                var Orginal = _IRellationshipAskToAnswerApplication.GetAll().Where(m => m.AnswerId == Entity.AnswerId && m.AskId == Entity.AskId).ToList();
                if (Orginal.Count == 0)
                {
                    _IRellationshipAskToAnswerApplication.Add(Entity);
                    Mensagem = Entity.RellationshipAskToAnswerId.ToString();
                }
                else {
                    Mensagem = "Rellation existend into data base !!!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Realiza a exclusão de um registro
        /// </summary>
        /// <param name="RellationshipAskToAnswerId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int RellationshipAskToAnswerId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Orginal = _IRellationshipAskToAnswerApplication.GetAll().Where(m => m.RellationshipAskToAnswerId == RellationshipAskToAnswerId).Single();
                if (Orginal != null)
                {
                    _IRellationshipAskToAnswerApplication.Remove(Orginal);
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
