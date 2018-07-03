using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public  class RellationshipStudentCourseService : Base.Service<RellationshipStudentCourse> , IRellationshipStudentCourseService
    {
        #region # Propriedades
        private readonly IRellationshipStudentCourseRepository _Repository;
        #endregion

        #region # Constructor
        public RellationshipStudentCourseService(IRellationshipStudentCourseRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
