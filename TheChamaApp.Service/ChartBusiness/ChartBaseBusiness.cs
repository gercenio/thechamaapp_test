using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using System.Linq;

namespace TheChamaApp.Service.ChartBusiness
{
    public class ChartBaseBusiness : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IEvaluatedApplication _IEvaluatedApplication;
        private readonly IQuizResultApplication _IQuizResultApplication;
        private readonly IAnswerApplication _IAnswerApplication;
        private readonly IAskApplication _IAskApplication;
        private readonly IRellationshipCompanyUnityToQuizApplication _IRellationshipCompanyUnityToQuizApplication;
        private readonly IRellationshipEvaluatedToUpEvaluatedApplication _IRellationshipEvaluatedToUpEvaluatedApplication;
        #endregion

        #region # Constructor
        public ChartBaseBusiness(IEvaluatedApplication evaluatedApplication
            , IQuizResultApplication quizResultApplication
            , IRellationshipCompanyUnityToQuizApplication rellationshipCompanyUnityToQuizApplication
            , IRellationshipEvaluatedToUpEvaluatedApplication evaluatedToUpEvaluatedApplication
            , IAskApplication askApplication
            , IAnswerApplication answerApplication)
        {
            _IEvaluatedApplication = evaluatedApplication;
            _IQuizResultApplication = quizResultApplication;
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
            _IRellationshipEvaluatedToUpEvaluatedApplication = evaluatedToUpEvaluatedApplication;
            _IAnswerApplication = answerApplication;
            _IAskApplication = askApplication;
        }
        #endregion

        #region # Methods
        public Infra.CrossCutting.ViewModel.ChartIndividualViewModel ObterGraficoIndividual(int EvaluatedId)
        {
            var Result = new Infra.CrossCutting.ViewModel.ChartIndividualViewModel();
            try
            {
                var Evaluated = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).Single();
                if (Evaluated != null)
                {
                    var RelSuperior = _IRellationshipEvaluatedToUpEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId).Single();
                    Result.Avaliado = Evaluated;
                    if(RelSuperior != null)
                    {
                        Result.Superior = _IEvaluatedApplication.GetAll().Where(m => m.EvaluatedId == RelSuperior.UpEvaluatedId).Single();
                    }
                    var Rel = _IRellationshipCompanyUnityToQuizApplication.GetAll().Where(m => m.Enable == true
                    && m.CompanyUnityId == Evaluated.CompanyUnityId
                    && m.StartDate <= DateTime.Now && m.FinishDate >= DateTime.Now).ToList();
                    if (Rel != null)
                    {
                        List<Domain.Entities.QuizResult> listResultados = new List<Domain.Entities.QuizResult>();
                        foreach (var relacionamento in Rel)
                        {
                            foreach (var item in _IQuizResultApplication.GetAll().Where(m => m.EvaluatedId == EvaluatedId && m.QuizId == relacionamento.QuizId))
                            {
                                item.Answer = _IAnswerApplication.GetAll().Where(m => m.AnswerId == item.AnswerId).Single();
                                item.Ask = _IAskApplication.GetAll().Where(m => m.AskId == item.AskId).Single();
                                listResultados.Add(item);
                            }
                        }

                        Result.ListQuizResult = listResultados;
                    }
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
            return Result;
        }
        #endregion
    }
}
