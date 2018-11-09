using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChamaApp.Application.IApplication;

namespace TheChamaApp.Presentation.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class MailController : BaseController
    {

        private readonly IConfigurationSettingsApplication _IConfigurationSettingsApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;
        private readonly IEvaluatedApplication _IEvaluatedApplication;

        public MailController(IConfigurationSettingsApplication configurationSettingsApplication
            , ICompanyUnityApplication companyUnityApplication
            , IEvaluatedApplication evaluatedApplication)
        {
            _IConfigurationSettingsApplication = configurationSettingsApplication;
            _ICompanyUnityApplication = companyUnityApplication;
            _IEvaluatedApplication = evaluatedApplication;
        }

        //[HttpPost]
        //[Authorize("Bearer")]
        //public async Task<IActionResult>  Enviar([FromBody]TheChamaApp.Infra.CrossCutting.ViewModel.EmailViewModel Model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (TheChamaApp.Service.EmailBusiness.EmailService EmailBO = new Service.EmailBusiness.EmailService(_IConfigurationSettingsApplication,_ICompanyUnityApplication,_IEvaluatedApplication,Model.EmailTo, Model.EmailSubject, Model.EmailBody))
        //        {
        //            await EmailBO.EnviarAsync();   
        //        }
        //    }
        //    return Ok(Mensagem);

        //}

        /// <summary>
        /// NOTIFICAÇÃO - Envia link do formulario de resposta
        /// </summary>
        /// <param name="Model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult> Post([FromBody]Infra.CrossCutting.ViewModel.NotificacaoVewModel Model)
        {
            if (ModelState.IsValid)
            {
                using (TheChamaApp.Service.EmailBusiness.EmailService EmailBO = new Service.EmailBusiness.EmailService(_IConfigurationSettingsApplication, _ICompanyUnityApplication, _IEvaluatedApplication))
                {
                    await EmailBO.NotificaQuestionario(Model);
                }
            }
            return Ok(Mensagem);
        }

       
    }
}