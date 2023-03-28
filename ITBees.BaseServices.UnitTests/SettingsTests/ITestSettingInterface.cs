using ITBees.BaseServices.Settings;
using ITBees.BaseServices.Settings.Interfaces;

namespace ITBees.BaseServices.UnitTests.SettingsTests
{
    public interface ITestSettingInterface : IHasReplaceableUpperFields
    {
        public string FIRST_SETTING { get; set; }
        public string OtherSetting { get; }
    }
}