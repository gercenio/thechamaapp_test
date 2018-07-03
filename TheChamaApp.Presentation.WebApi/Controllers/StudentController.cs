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
    [Route("api/Student")]
    public class StudentController : Controller
    {
        #region # Propriedades

        private readonly IStudentApplication _StudentApplication;
        private readonly ICourseApplication _CourseApplication;
        private readonly IRellationshipStudentCourseApplication _RellationshipStudentCourseApplication;

        #endregion

        #region # Constructor

        public StudentController(IStudentApplication studentApplication
            , ICourseApplication courseApplication
            , IRellationshipStudentCourseApplication rellationStudentCourseApp)
        {
            _CourseApplication = courseApplication;
            _StudentApplication = studentApplication;
            _RellationshipStudentCourseApplication = rellationStudentCourseApp;
        }

        #endregion

        #region # Methods
        [Authorize("Bearer")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(StudentViewModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult>  Created([FromBody] Infra.CrossCutting.ViewModel.StudentViewModel Entity)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            using (var StudentService = new TheChamaApp.Service.StudentBusiness.StudentService(_StudentApplication,_CourseApplication, _RellationshipStudentCourseApplication))
            {
                var EntityResult = await Task.Run(() => StudentService.CreatedStudentAndRellationCourse(Entity));
                return Ok(EntityResult);
            }
                
        }

        [Authorize("Bearer")]
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(StudentViewModel))]
        [ProducesResponseType(400)]
        public IActionResult GetAverageOfAge()
        {
            using(var StudentService = new TheChamaApp.Service.StudentBusiness.StudentService(_StudentApplication, _CourseApplication, _RellationshipStudentCourseApplication))
            {
                  return Ok(StudentService.CalcMediaAgeStudent());
            }
        }


        #endregion

    }
}