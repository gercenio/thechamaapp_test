using System;
using System.Collections.Generic;
using System.Text;

namespace TheChamaApp.Domain.Services
{
    public class CourseService : Base.Service<Entities.Course> , Interfaces.Service.ICourseService
    {
        #region # Propriedades
        private readonly Interfaces.Repository.ICourseRepository _Repository;
        #endregion

        #region # Constructor

        public CourseService(Interfaces.Repository.ICourseRepository repository) : base(repository)
        {
            _Repository = repository;
        }

        #endregion
    }
}
