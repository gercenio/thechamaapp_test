﻿using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;

namespace TheChamaApp.Infra.Data.Repository
{
    public class CompanyContactRepository : Base.Repository<CompanyContact>, ICompanyContactRepository
    {
    }
}
