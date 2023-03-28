namespace ITBees.BaseServices.UnitTests.SettingsTests
{
    public class TestSettingImpl : ITestSettingInterface
    {
        public string FIRST_SETTING { get; set; } = "First setting Value";
        public string OtherSetting { get; } = "other";
    }
}