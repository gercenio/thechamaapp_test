using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace TheChamaApp.Domain.Interfaces.Authorization
{
    public interface IUser
    {
        string Name { get; }
        bool IsAuthenticated();
        IEnumerable<Claim> GetClaimsIdentity();
    }
}
