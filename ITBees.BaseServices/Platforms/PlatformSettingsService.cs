using System;
using System.Collections.Generic;
using System.Linq;
using ITBees.Interfaces.Platforms;
using ITBees.Models.EmailAccounts;
using Microsoft.Extensions.Configuration;
using Environment = ITBees.Interfaces.Platforms.Environment;

namespace ITBees.BaseServices.Platforms
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
            return GetSetting("DebugEmails").Split(";").ToList();
        }

        public Environment GetCurrentEnvironment()
        {
            var currentEnv = GetSetting("Environemnt");
            return (Environment) Enum.Parse(typeof(Environment), currentEnv);
        }

        public EmailAccount GetPlatformDefaultEmailAccount()
        {
            var emailAccount = new EmailAccount()
            {
                EmailFromTitle = GetSetting("CompanyEmailDisplayName"),
                Email = GetSetting("CompanyEmail"),
                SmtpPort = GetSetting("SmtpPort"),
                ImapServer = GetSetting("ImapServer"),
                Login = GetSetting("CompanyEmailLogin"),
                Pass = GetSetting("CompanyEmailPassword"),
                SmtpServer = GetSetting("SmtpHost"),
                UseSSL = Convert.ToBoolean(GetSetting("SmtpUseSSL")),
                UseAdditionalAuthWhenSendingEmail = Convert.ToBoolean(GetSetting("UseAdditionalAuthWhenSendingEmail")),
                ImapPort = GetSetting("ImapPort"),
            };
            return emailAccount;
        }
    }
}