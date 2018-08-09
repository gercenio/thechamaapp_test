using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.AnswerBusiness
{
    public class AnswerService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IAnswerApplication _IAnswerService;
        #endregion

        #region # Constructor
        public AnswerService(IAnswerApplication answerService)
        {
            _IAnswerService = answerService;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Realiza a inclusão de uma resposta
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Answer Incluir(Domain.Entities.Answer Entity, out string Mensagem)
        {
            try
            {
                _IAnswerService.Add(Entity);
                Mensagem = Entity.AnswerId.ToString();
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Atualiza os dados de uma Resposta
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Answer Alterar(int AnswerId,Domain.Entities.Answer Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IAnswerService.GetAll().Where(m => m.AnswerId == AnswerId).ToList();
                if (Original.Count > 0)
                {
                    _IAnswerService.Update(Entity);
                    Mensagem = "Done";
                }
                
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        public void Deletar(int AnswerId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Entity = _IAnswerService.GetAll().Where(m => m.AnswerId == AnswerId).Single();
                if (Entity != null) {
                    _IAnswerService.Remove(Entity);
                    Mensagem = "Done";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Obtem uma Respsta
        /// </summary>
        /// <param name="AnswerId"></param>
        /// <returns></returns>
        public Domain.Entities.Answer Obter(int AnswerId)
        {
            var Entity = new Domain.Entities.Answer();
            try
            {
                Entity = _IAnswerService.GetAll().Where(m => m.AnswerId == AnswerId).Single();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Obter todas as respostas
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Answer> ObterTodos()
        {
            try
            {
                return _IAnswerService.GetAll();
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        #endregion

    }
}
