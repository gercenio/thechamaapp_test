using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class GroupAskApplication : Base.AppServiceBase<GroupAsk>, IGroupAskApplication
    {
        private readonly IGroupAskService _Service;

        public GroupAskApplication(IGroupAskService service) :base(service)
        {
            _Service = service;
        }
    }
}
