using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class CourseApplication : Base.AppServiceBase<Course>, ICourseApplication
    {
        private readonly ICourseService _Service;

        public CourseApplication(ICourseService service) : base(service)
        {
            _Service = service;
        }
    }
}
