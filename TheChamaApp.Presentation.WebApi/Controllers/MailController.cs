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
        
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<IActionResult>  Enviar([FromBody]TheChamaApp.Infra.CrossCutting.ViewModel.EmailViewModel Model)
        {
            if (ModelState.IsValid)
            {
                using (TheChamaApp.Service.EmailBusiness.EmailService EmailBO = new Service.EmailBusiness.EmailService(Model.EmailTo, Model.EmailSubject, Model.EmailBody))
                {
                    await EmailBO.EnviarAsync();   
                }
            }
            return Ok(Mensagem);

        }

       
    }
}