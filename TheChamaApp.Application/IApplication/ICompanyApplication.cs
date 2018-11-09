using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.ViewModel;

namespace TheChamaApp.Application.IApplication
{
    public interface ICompanyApplication : Base.IAppServiceBase<Company>
    {
        IEnumerable<CompanyQuizResultViewModel> GetAllQuizResult(int CompanyId);
    }
}
