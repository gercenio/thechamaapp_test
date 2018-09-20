using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using System.Linq;

namespace TheChamaApp.Service.EvaluatedBusiness
{
    public class RellationshipEvaluatedToUpEvaluatedService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _IRellationshipEvaluatedToUpEvaluatedApplication;
        #endregion

        #region # Constructor
        public RellationshipEvaluatedToUpEvaluatedService(IRellationshipEvaluatedToUpEvaluatedApplication rellationshipEvaluatedToUpEvaluatedApplication)
        {
            _IRellationshipEvaluatedToUpEvaluatedApplication = rellationshipEvaluatedToUpEvaluatedApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um relacionamento
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public RellationshipEvaluatedToUpEvaluated Incluir(RellationshipEvaluatedToUpEvaluated Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var EntityChk = _IRellationshipEvaluatedToUpEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == Entity.EvaluatedId && m.UpEvaluatedId == Entity.UpEvaluatedId).ToList();
                if (EntityChk.Count == 0)
                {
                    _IRellationshipEvaluatedToUpEvaluatedApplication.Add(Entity);
                    Mensagem = Entity.RellationshipEvaluatedToUpEvaluatedId.ToString();
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a exclusão de um objeto
        /// </summary>
        /// <param name="RellationshipEvaluatedToUpEvaluatedId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int RellationshipEvaluatedToUpEvaluatedId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IRellationshipEvaluatedToUpEvaluatedApplication.GetAll().Where(m => m.RellationshipEvaluatedToUpEvaluatedId == RellationshipEvaluatedToUpEvaluatedId).Single();
                if(Original != null)
                {
                    _IRellationshipEvaluatedToUpEvaluatedApplication.Remove(Original);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista de superior do subordinado
        /// </summary>
        /// <param name="EvaluatedId"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.RellationshipEvaluatedToUpEvaluated> ObterByEvaluatedId(int EvaluatedId)
        {
            return _IRellationshipEvaluatedToUpEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).ToList();
        }

        /// <summary>
        /// Realiza a alteração de dados
        /// </summary>
        /// <param name="RellationshipEvaluatedToUpEvaluatedId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipEvaluatedToUpEvaluated Alterar(int RellationshipEvaluatedToUpEvaluatedId
            , Domain.Entities.RellationshipEvaluatedToUpEvaluated Entity
            , out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var OriginalList = _IRellationshipEvaluatedToUpEvaluatedApplication.GetAll().Where(m => m.RellationshipEvaluatedToUpEvaluatedId == RellationshipEvaluatedToUpEvaluatedId).ToList();
                if (OriginalList.Count > 0)
                {
                    Entity.RellationshipEvaluatedToUpEvaluatedId = RellationshipEvaluatedToUpEvaluatedId;
                    _IRellationshipEvaluatedToUpEvaluatedApplication.Update(Entity);
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
            return Entity;
        }

        #endregion
    }
}
