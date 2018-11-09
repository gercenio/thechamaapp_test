using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;
using TheChamaApp.Service.EvaluatedBusiness;

namespace TheChamaApp.Service.QuizBusiness
{
    public class RellationshipCompanyUnityToQuizService : Base.ServiceBase
    {
        #region # Propriedades

        private readonly IRellationshipCompanyUnityToQuizApplication _IRellationshipCompanyUnityToQuizApplication;
        private readonly IQuizApplication _IQuizApplication;
        private readonly IRellationshipQuizToEvaluatedApplication _IRellationshipQuizToEvaluatedApplication;
        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _IRellationshipEvaluatedToUpEvaluatedApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;

        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuizService(IRellationshipCompanyUnityToQuizApplication rellationshipCompanyUnityToQuizApplication
            , IQuizApplication quizApplication
            , IRellationshipQuizToEvaluatedApplication rellationshipQuizToEvaluatedApplication
            , IRellationshipEvaluatedToUpEvaluatedApplication rellationshipEvaluatedToUpEvaluatedApplication
            , IEvaluatedApplication evaluatedApplication)
        {
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
            _IQuizApplication = quizApplication;
            _IRellationshipQuizToEvaluatedApplication = rellationshipQuizToEvaluatedApplication;
            _IRellationshipEvaluatedToUpEvaluatedApplication = rellationshipEvaluatedToUpEvaluatedApplication;
            _IEvaluatedApplication = evaluatedApplication;
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
                //adicionando relacionamentos
                if (Entity.RellationshipCompanyUnityToQuizId > 0) {
                    using (var RelacionamentoServiceBO = new RellationshipQuizToEvaluatedService(_IRellationshipQuizToEvaluatedApplication, _IRellationshipEvaluatedToUpEvaluatedApplication, _IEvaluatedApplication, _IQuizApplication)) {
                        RelacionamentoServiceBO.IncluirByRellationshipCompanyUnityToQuiz(Entity, out Mensagem);
                    }
                }
                Mensagem = Entity.RellationshipCompanyUnityToQuizId.ToString();
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
        
        /// <summary>
        /// Obtem um relacionamento
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuiz"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipCompanyUnityToQuiz Obter(int RellationshipCompanyUnityToQuizId)
        {
            var Original = new Domain.Entities.RellationshipCompanyUnityToQuiz();
            try
            {
                Original = _IRellationshipCompanyUnityToQuizApplication.GetAll().Where(m => m.RellationshipCompanyUnityToQuizId == RellationshipCompanyUnityToQuizId).Single();
                if (Original != null)
                {
                    if (Original.QuizId > 0)
                    {
                        Original.Quiz = _IQuizApplication.GetAll().Where(m => m.QuizId == Original.QuizId).Single();
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Original;
        }

        /// <summary>
        /// Obtem uma lista de relacionamentos
        /// </summary>
        /// <param name="CompanyUnityId"></param>
        /// <returns></returns>
        public IEnumerable<Domain.Entities.RellationshipCompanyUnityToQuiz> ObterByCompanyUnityId(int CompanyUnityId)
        {
            List<Domain.Entities.RellationshipCompanyUnityToQuiz> lista = new List<Domain.Entities.RellationshipCompanyUnityToQuiz>();
            foreach (var item in _IRellationshipCompanyUnityToQuizApplication.GetAll().Where(m => m.CompanyUnityId == CompanyUnityId))
            {
                lista.Add(this.Obter(item.RellationshipCompanyUnityToQuizId));
            }
            return lista;
        }

        /// <summary>
        /// Realiza a alteração
        /// </summary>
        /// <param name="RellationshipCompanyUnityToQuizId"></param>
        /// <param name="Entity"></param>
        /// <param name="Mensagem"></param>
        /// <returns></returns>
        public Domain.Entities.RellationshipCompanyUnityToQuiz Alterar(int RellationshipCompanyUnityToQuizId, Domain.Entities.RellationshipCompanyUnityToQuiz Entity, out string Mensagem)
        {
            Mensagem = string.Empty;
            try
            {
                var OrginalList = _IRellationshipCompanyUnityToQuizApplication.GetAll().Where(m => m.RellationshipCompanyUnityToQuizId == RellationshipCompanyUnityToQuizId).ToList();
                if (OrginalList.Count > 0)
                {
                    Entity.RellationshipCompanyUnityToQuizId = RellationshipCompanyUnityToQuizId;
                    _IRellationshipCompanyUnityToQuizApplication.Update(Entity);
                    Mensagem = "Done";
                }
                else
                {
                    Mensagem = "Data is valid!!";
                }
            }
            catch (Exception Ex)
            {
                Mensagem = string.Format("Error:{0}", Ex.Message);
            }
            return Entity;
        }

        #endregion

    }
}
