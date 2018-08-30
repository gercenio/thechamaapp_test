using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    
    [Route("api/[controller]")]
    public class RellationshipCompanyUnityToQuizController : BaseController
    {
        #region # Propriedades
        private readonly IRellationshipCompanyUnityToQuizApplication _IRellationshipCompanyUnityToQuizApplication;
        #endregion

        #region # Constructor
        public RellationshipCompanyUnityToQuizController(IRellationshipCompanyUnityToQuizApplication rellationshipCompanyUnityToQuizApplication)
        {
            _IRellationshipCompanyUnityToQuizApplication = rellationshipCompanyUnityToQuizApplication;
        }
        #endregion

        #region # Actions

        #endregion
    }
}