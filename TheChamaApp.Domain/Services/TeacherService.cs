using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class TeacherService : Base.Service<Teacher> , ITeacherService
    {
        #region # Propriedades
        public readonly ITeacherRepository _Repository;
        #endregion

        #region # Constructor
        public TeacherService(ITeacherRepository repository) : base(repository) {
            _Repository = repository;
        }
        #endregion
    }
}
