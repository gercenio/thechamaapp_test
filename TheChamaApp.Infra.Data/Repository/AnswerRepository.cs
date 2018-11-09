using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Infra.Data.Repository.Base;

namespace TheChamaApp.Infra.Data.Repository
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
    }
}
