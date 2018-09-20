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
    public class GroupAskController : BaseController
    {
        #region # Prorpriedades
        private readonly IGroupAskApplication _IGroupAskApplication;
        #endregion

        #region # Constructor
        public GroupAskController(IGroupAskApplication groupAskApplication)
        {
            _IGroupAskApplication = groupAskApplication;
        }
        #endregion

        #region # Methods

        /// <summary>
        /// Obtem uma lista de todos os grupos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("Bearer")]
        public IActionResult Get()
        {
            using (TheChamaApp.Service.AskBusiness.GroupAskBusiness GroupBO = new Service.AskBusiness.GroupAskBusiness(_IGroupAskApplication))
            {
                try
                {
                    return Ok(GroupBO.ObtemTodos());
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        /// <summary>
        /// Obtem um passando o ID
        /// </summary>
        /// <param name="GroupAskId"></param>
        /// <returns></returns>
        [HttpGet("{GroupAskId}")]
        [Authorize("Bearer")]
        public IActionResult Get(int GroupAskId)
        {

            using (TheChamaApp.Service.AskBusiness.GroupAskBusiness GroupBO = new Service.AskBusiness.GroupAskBusiness(_IGroupAskApplication))
            {
                try
                {
                    return Ok(GroupBO.Obter(GroupAskId));
                }
                catch (Exception Ex)
                {
                    return BadRequest(Ex);
                }
            }
        }

        #endregion

    }
}