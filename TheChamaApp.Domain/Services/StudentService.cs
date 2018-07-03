using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class StudentService : Base.Service<Student> , IStudentService
    {
        #region # Priedades
        private readonly IStudentRepository _Repository;
        #endregion

        #region # Constructor
        public StudentService(IStudentRepository repository) : base(repository)
        {
            _Repository = repository;
        }
        #endregion
    }
}
