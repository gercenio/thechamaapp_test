using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Domain.Interfaces.Service
{
    public interface ICompanyService : Base.IService<Company>
    {
        IEnumerable<CompanyQuizResultViewModel> GetAllQuizResult(int CompanyId);
    }
}
