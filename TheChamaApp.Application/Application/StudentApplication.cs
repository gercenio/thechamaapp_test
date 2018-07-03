using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class StudentApplication : Base.AppServiceBase<Student>, IStudentApplication
    {
        private readonly IStudentService _Service;

        public StudentApplication(IStudentService service) : base(service)
        {
            _Service = service;
        }
    }
}
