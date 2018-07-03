using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TheChamaApp.Infra.Data.Interfaces
{
    public interface IDapperContexto : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
