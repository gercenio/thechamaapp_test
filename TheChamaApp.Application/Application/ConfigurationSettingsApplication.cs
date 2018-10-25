using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Application.IApplication;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Application.Application
{
    public class ConfigurationSettingsApplication : Base.AppServiceBase<Domain.Entities.ConfigurationSettings>, IConfigurationSettingsApplication
    {
        private readonly IConfigurationSettingsService _Service;

        public ConfigurationSettingsApplication(IConfigurationSettingsService service) :base(service)
        {
            _Service = service;
        }

    }
}
