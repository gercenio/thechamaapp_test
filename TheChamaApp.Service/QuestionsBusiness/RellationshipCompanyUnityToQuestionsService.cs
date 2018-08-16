using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Service.QuestionsBusiness
{
    public class RellationshipCompanyUnityToQuestionsService : Base.ServiceBase
    {
        #region # Propriedades
        private readonly IRellationshipCompanyUnityToQuestionsApplication _IRellationshipCompanyUnityToQuestionsApplication;
        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuestionsService(IRellationshipCompanyUnityToQuestionsApplication rellationshipCompanyUnityToQuestionsApplication)
        {
            _IRellationshipCompanyUnityToQuestionsApplication = rellationshipCompanyUnityToQuestionsApplication;
        }
        #endregion

    }
}
