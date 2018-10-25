using System;
using System.Collections.Generic;
using System.Linq;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.QuizBusiness
{
    public class QuizService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly IQuizApplication _IQuizApplication;
        private readonly IRellationshipQuizToAskApplication _IRellationshipQuizToAskApplication;
        private readonly IAskApplication _IAskApplication;
        private readonly IRellationshipAskToAnswerApplication _IRellationshipAskToAnswerApplication;
        private readonly IGroupAskApplication _IGroupAskApplication;
        private readonly IAnswerApplication _IAnswerApplication;

        #endregion

        #region # Constructor
        public QuizService(IQuizApplication quizApplication
            , IRellationshipQuizToAskApplication rellationshipQuizToAskApplication
            , IAskApplication askApplication
            , IRellationshipAskToAnswerApplication rellationshipAskToAnswerApplication
            , IGroupAskApplication groupAskApplication
            , IAnswerApplication answerApplication)
        {
            _IQuizApplication = quizApplication;
            _IRellationshipQuizToAskApplication = rellationshipQuizToAskApplication;
            _IAskApplication = askApplication;
            _IRellationshipAskToAnswerApplication = rellationshipAskToAnswerApplication;
            _IGroupAskApplication = groupAskApplication;
            _IAnswerApplication = answerApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Realiza a inclusão de uma Questões
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Quiz Incluir(Domain.Entities.Quiz Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var OriginalList = _IQuizApplication.GetAll().Where(m => m.Description.ToUpper() == Entity.Description.ToUpper()).ToList();
                if (OriginalList.Count == 0)
                {
                    _IQuizApplication.Add(Entity);
                    Mensagem = Entity.QuizId.ToString();
                }
                
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        /// <summary>
        /// Realiza a alteração de uma Questões
        /// </summary>
        /// <param name="QuizId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.Quiz Alterar(int QuizId,Domain.Entities.Quiz Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Original = _IQuizApplication.GetAll().Where(m => m.QuizId == QuizId).Single();
                if (Original != null)
                {
                    Entity.QuizId = QuizId;
                    _IQuizApplication.Update(Entity);
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
        /// Realiza a exclusão de um questões
        /// </summary>
        /// <param name="QuizId"></param>
        /// <param name="Mensagem"></param>
        public void Excluir(int QuizId, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var Orginal = _IQuizApplication.GetAll().Where(m => m.QuizId == QuizId).Single();
                _IQuizApplication.Remove(Orginal);
                Mensagem = "Done";
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
        }

        /// <summary>
        /// Realiza o retorno de uma questão
        /// </summary>
        /// <param name="QuizId"></param>
        /// <returns></returns>
        public Domain.Entities.Quiz Obter(int QuizId)
        {
            try
            {
                var Entity = _IQuizApplication.GetAll().Where(m => m.QuizId == QuizId).Single();
                if (Entity != null)
                {
                    foreach (var item in _IRellationshipQuizToAskApplication.GetAll().Where(m => m.QuizId == Entity.QuizId))
                    {
                        if (item.AskId > 0)
                        {
                            item.Ask = _IAskApplication.GetAll().Where(m => m.AskId == item.AskId).Single();
                            var listarespostas = _IRellationshipAskToAnswerApplication.GetAll().Where(m => m.AskId == item.AskId).ToList();
                            if(listarespostas.Count > 0)
                            {
                                foreach (var relacionamento in listarespostas)
                                {
                                    if (relacionamento.AnswerId > 0) {
                                        relacionamento.Answer = _IAnswerApplication.GetAll().Where(m => m.AnswerId == relacionamento.AnswerId).First();
                                    }
                                    item.Ask.RellationshipAskToAnswer.Add(relacionamento);
                                }
                            }
                            //item.Ask.RellationshipAskToAnswer = _IRellationshipAskToAnswerApplication.GetAll().Where(m => m.AskId == item.AskId).ToList();
                            if (item.GroupAskId.HasValue && item.GroupAskId > 0)
                            {
                                var GroupEntity = _IGroupAskApplication.GetAll().Where(m => m.GroupAskId == item.GroupAskId).ToList();
                                if (GroupEntity.Count > 0) {
                                    item.GroupAsk = GroupEntity[0];
                                }
                                 
                            }
                            
                        }
                        Entity.RellationshipQuizToAsk.Add(item);
                    }
                }
                return Entity;

            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// Realiza a busca de questões por descrição
        /// </summary>
        /// <param name="Description"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Quiz> ObterByDescription(string Description)
        {
            List<Domain.Entities.Quiz> lista = new List<Domain.Entities.Quiz>();
            foreach (var item in _IQuizApplication.GetAll().Where(m => m.Description.Contains(Description)).ToList())
            {
                lista.Add(this.Obter(item.QuizId));
            }
            return lista;
        }

        /// <summary>
        /// Obtem uma lista de todas as questões
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.Quiz> ObterTodos()
        {
            List<Domain.Entities.Quiz> lista = new List<Domain.Entities.Quiz>();
            foreach (var item in _IQuizApplication.GetAll())
            {
                lista.Add(this.Obter(item.QuizId));
            }
            return lista;
        }

        #endregion

    }
}
