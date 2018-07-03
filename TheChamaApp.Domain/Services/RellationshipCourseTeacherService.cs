using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class RellationshipCourseTeacherService : Base.Service<RellationshipCourseTeacher> , IRellationshipCourseTeacherService
    {
        #region # Propriedades
        private readonly IRellationshipCourseTeacherRepository _Repository;
        #endregion

        #region # Constructor
        public RellationshipCourseTeacherService(IRellationshipCourseTeacherRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
