using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.EvaluatedBusiness
{
    public class LevelEvaluatedService : Base.ServiceBase
    {
        #region # Propriedades
        private ILevelEvaluatedApplication _ILevelEvaluatedApplication;
        #endregion

        #region # Constructor
        public LevelEvaluatedService(ILevelEvaluatedApplication levelEvaluatedApplication)
        {
            _ILevelEvaluatedApplication = levelEvaluatedApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de um nivel de avaliado
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.LevelEvaluated Incluir(Domain.Entities.LevelEvaluated Entity, out string Mensagem)
        {
            try
            {
                _ILevelEvaluatedApplication.Add(Entity);
                Mensagem = Entity.LevelEvaluatedId.ToString();
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Obtem um Nivel de avaliado
        /// </summary>
        /// <param name="LeveEvaluatedId"></param>
        /// <returns></returns>
        public Domain.Entities.LevelEvaluated Obter(int LeveEvaluatedId)
        {
            return _ILevelEvaluatedApplication.GetAll().Where(m => m.LevelEvaluatedId == LeveEvaluatedId).Single();
        }

        /// <summary>
        /// Obtem uma lista de todos os que já foram cadastrados
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.LevelEvaluated> ObterTodos()
        {
            return _ILevelEvaluatedApplication.GetAll();
        }

        /// <summary>
        /// Realiza a exclusão de um nivel de avaliado
        /// </summary>
        /// <param name="LeveEvaluatedId"></param>
        public void Excluir(int LeveEvaluatedId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _ILevelEvaluatedApplication.GetAll().Where(m => m.LevelEvaluatedId == LeveEvaluatedId).Single();
                if(Original != null)
                {
                    _ILevelEvaluatedApplication.Remove(Original);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Erro:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Atualiza o nivel de avaliado
        /// </summary>
        /// <param name="LeveEvaluatedId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.LevelEvaluated Alterar(int LeveEvaluatedId, Domain.Entities.LevelEvaluated Entity,out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Orginal = _ILevelEvaluatedApplication.GetAll().Where(m => m.LevelEvaluatedId == LeveEvaluatedId).Single();
                if (Orginal != null)
                {
                    Entity.LevelEvaluatedId = Orginal.LevelEvaluatedId;
                    _ILevelEvaluatedApplication.Update(Entity);
                    Mensagem = "Done";
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
