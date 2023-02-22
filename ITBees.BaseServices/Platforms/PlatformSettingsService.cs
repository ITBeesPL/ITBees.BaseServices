using System.Collections.Generic;
using ITBees.Interfaces.Platforms;
using Microsoft.Extensions.Configuration;

namespace ITBees.Models.Platforms
{
    public class PlatformSettingsService : IPlatformSettingsService
    {
        private readonly IConfigurationRoot _configurationRoot;

        public PlatformSettingsService(IConfigurationRoot configurationRoot)
        {
            _configurationRoot = configurationRoot;
        }

        public string GetSetting(string key)
        {
            var settingValue = _configurationRoot.GetSection(key).Value;

            return settingValue;
        }

        public List<string> GetPlatformDebugEmails()
        {
            throw new System.NotImplementedException();
        }

        public Environment GetCurrentEnvironment()
        {
            throw new System.NotImplementedException();
        }
    }
}