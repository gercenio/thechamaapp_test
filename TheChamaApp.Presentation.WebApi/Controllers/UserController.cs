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
    public class UserController : BaseController
    {
        #region # Propriedades

        private readonly ILoginApplication _ILoginApplication;
        private readonly ICompanyUnityApplication _ICompanyUnityApplication;

        #endregion

        #region # Constructor
        public UserController(ILoginApplication loginApplication
            , ICompanyUnityApplication companyUnityApplication)
        {
            _ILoginApplication = loginApplication;
            _ICompanyUnityApplication = companyUnityApplication;
        }
        #endregion

        #region # Actions

        /// <summary>
        /// Cria um novo login na plataforma
        /// </summary>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize("Bearer")]
        public IActionResult Post([FromBody]Domain.Entities.Login Entity)
        {
            try
            {
                using (TheChamaApp.Service.AccessBusiness.LoginService LoginBO = new Service.AccessBusiness.LoginService(_ILoginApplication, _ICompanyUnityApplication))
                {
                    if (ModelState.IsValid)
                    {
                        LoginBO.Incluir(Entity, out Mensagem);
                    }
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Realiza a alteração de um login
        /// </summary>
        /// <param name="LoginId"></param>
        /// <param name="Entity"></param>
        /// <returns></returns>
        [HttpPut]
        [Authorize("Bearer")]
        public IActionResult Put(int LoginId, [FromBody]Domain.Entities.Login Entity)
        {
            try
            {
                using (TheChamaApp.Service.AccessBusiness.LoginService LoginBO = new Service.AccessBusiness.LoginService(_ILoginApplication, _ICompanyUnityApplication))
                {
                    LoginBO.Alterar(LoginId, Entity,out Mensagem);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Deleta um login
        /// </summary>
        /// <param name="LoginId"></param>
        [HttpDelete("{LoginId}")]
        [Authorize("Bearer")]
        public void Delete(int LoginId)
        {
            try
            {
                using (TheChamaApp.Service.AccessBusiness.LoginService LoginBO = new Service.AccessBusiness.LoginService(_ILoginApplication, _ICompanyUnityApplication))
                {
                    LoginBO.Excluir(LoginId, out Mensagem);
                }
            }
            catch (Exception Ex)
            {
                throw new Exception(Ex.Message);
            }
        }

        /// <summary>
        /// Obtem um login
        /// </summary>
        /// <param name="LoginId"></param>
        /// <returns></returns>
        [HttpGet("{LoginId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int LoginId)
        {
            try
            {
                using (TheChamaApp.Service.AccessBusiness.LoginService LoginBO = new Service.AccessBusiness.LoginService(_ILoginApplication, _ICompanyUnityApplication))
                {
                    LoginBO.Obter(LoginId);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest(Ex);
            }
            return Ok(Mensagem);
        }

        /// <summary>
        /// Retorna um lista
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            using (TheChamaApp.Service.AccessBusiness.LoginService LoginBO = new Service.AccessBusiness.LoginService(_ILoginApplication, _ICompanyUnityApplication))
            {
                return Ok(LoginBO.ObterTodos());
            }
        }

        #endregion

    }
}