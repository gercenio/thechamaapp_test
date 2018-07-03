using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class RellationshipCourseTeacherApplication : Base.AppServiceBase<RellationshipCourseTeacher>, IRellationshipCourseTeacherApplication
    {
        private readonly IRellationshipCourseTeacherService _Service;

        public RellationshipCourseTeacherApplication(IRellationshipCourseTeacherService service) : base(service)
        {
            _Service = service;
        }
    }
}
