using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class TeacherApplication : Base.AppServiceBase<Teacher>, ITeacherApplication
    {
        private readonly ITeacherService _Service;

        public TeacherApplication(ITeacherService service) : base(service)
        {
            _Service = service;
        }
        
    }
}
