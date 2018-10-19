using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.AskBusiness
{
    public class GroupAskBusiness: Base.ServiceBase
    {
        #region # Propriedades

        private readonly IGroupAskApplication _IGroupAskApplication;
        private readonly IRellationshipQuizToAskApplication _IRellationshipQuizToAskApplication;

        #endregion

        #region # Constructor
        public GroupAskBusiness(IGroupAskApplication groupAskApplication
            , IRellationshipQuizToAskApplication rellationshipQuizToAskApplication)
        {
            _IGroupAskApplication = groupAskApplication;
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um registro
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.GroupAsk Incluir(Domain.Entities.GroupAsk Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                _IGroupAskApplication.Add(Entity);
                Mensagem = Entity.GroupAskId.ToString();
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a alteração
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.GroupAsk Alterar(int GroupAskId,Domain.Entities.GroupAsk Entity, out string Mensagem) {
            Mensagem = string.Empty;
            try
            {
                var GroupList = _IGroupAskApplication.GetAll().Where(m => m.GroupAskId == GroupAskId).ToList();
                if (GroupList.Count > 0) {
                    Entity.GroupAskId = GroupAskId;
                    _IGroupAskApplication.Update(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a exclusão
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int GroupAskId, out string Mensagem)
        {
            try
            {
                var RellationshipList = _IRellationshipQuizToAskApplication.GetAll().Where(m => m.GroupAskId == GroupAskId).ToList();
                if (RellationshipList.Count == 0)
                {
                    var Entity = _IGroupAskApplication.GetAll().Where(m => m.GroupAskId == GroupAskId).Single();
                    _IGroupAskApplication.Remove(Entity);
                    Mensagem = "Done";
                }
                else {
                    Mensagem = "Existe um relacionamento, valido primeiro apague o relacionamento e apois isso realize a exclusão novamente!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma lista de todos os grupos
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.GroupAsk> ObtemTodos()
        {
            return _IGroupAskApplication.GetAll();
        }

        /// <summary>
        /// Obtem um grupo
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <returns></returns>
        public Domain.Entities.GroupAsk Obter(int GroupAskId)
        {
            return _IGroupAskApplication.GetAll().Where(m => m.GroupAskId == GroupAskId).Single();
        }

        #endregion
    }
}
