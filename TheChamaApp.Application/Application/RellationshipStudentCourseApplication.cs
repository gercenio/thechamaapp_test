using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipStudentCourseApplication : Base.AppServiceBase<RellationshipStudentCourse>, IRellationshipStudentCourseApplication
    {
        private readonly IRellationshipStudentCourseService _Service;

        public RellationshipStudentCourseApplication(IRellationshipStudentCourseService service) : base(service)
        {
            _Service = service;
        }
    }
}
