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
        private readonly IRellationshipAskToAnswerApplication _IRellationshipAskToAnswerApplication;
        private readonly IAnswerApplication _IAnswerApplication;
        #endregion

        #region # Constructor
        public AskService(IAskApplication askApplication
            , IRellationshipAskToAnswerApplication rellationshipAskToAnswerApplication
            , IAnswerApplication answerApplication)
        {
            _IAskApplication = askApplication;
            _IRellationshipAskToAnswerApplication = rellationshipAskToAnswerApplication;
            _IAnswerApplication = answerApplication;
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
            var Entity = _IAskApplication.GetAll().Where(m => m.AskId == AskId).Single();
            if (Entity != null)
            {
                foreach (var Rellation in _IRellationshipAskToAnswerApplication.GetAll().Where(m => m.AskId == Entity.AskId).ToList())
                {
                    Rellation.Answer = _IAnswerApplication.GetAll().Where(m => m.AnswerId == Rellation.AnswerId).Single();
                    Entity.RellationshipAskToAnswer.Add(Rellation);
                }
                
            }
            return Entity;
        }

        /// <summary>
        /// Obtem uma lista de perguntas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Ask> ObterTodos()
        {
            List<Domain.Entities.Ask> lista = new List<Domain.Entities.Ask>();
            foreach (var ask in _IAskApplication.GetAll())
            {
                lista.Add(this.Obter(ask.AskId));
            }
            return lista;
        }

        #endregion
    }
}
