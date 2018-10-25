using System;
using System.Collections.Generic;
using System.Text;
using TheChamaApp.Domain.Entities;
using TheChamaApp.Domain.Interfaces.Repository;
using TheChamaApp.Domain.Interfaces.Service;

namespace TheChamaApp.Domain.Services
{
    public class ConfigurationSettingsService : Base.Service<ConfigurationSettings>, IConfigurationSettingsService
    {
        private readonly IConfigurationSettingsRepository _IConfigurationSettingsRepository;

        public ConfigurationSettingsService(IConfigurationSettingsRepository repository):base(repository)
        {
            _IConfigurationSettingsRepository = repository;
        }
    }
}
