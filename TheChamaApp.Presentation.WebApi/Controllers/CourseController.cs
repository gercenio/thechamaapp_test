using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Infra.CrossCutting.ViewModel;

namespace TheChamaApp.Presentation.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Course")]
    public class CourseController : Controller
    {
        #region # Propriedades

        private readonly ICourseApplication _CourseApplication;

        #endregion

        #region # Constructor
        public CourseController(ICourseApplication courseApp)
        {
            _CourseApplication = courseApp;
        }
        #endregion

        #region Actions

        [Authorize("Bearer")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ICollection<CourseViewModel>))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Task.Run(() => _CourseApplication.GetAll()));
        }
        #endregion
    }
}