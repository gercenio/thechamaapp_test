using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using TheChamaApp.Domain.Interfaces.Repository;

namespace TheChamaApp.Infra.Data.Repository
{
    public class ConfigurationSettingsRepository : Base.Repository<Domain.Entities.ConfigurationSettings> , IConfigurationSettingsRepository
    {

    }
}
