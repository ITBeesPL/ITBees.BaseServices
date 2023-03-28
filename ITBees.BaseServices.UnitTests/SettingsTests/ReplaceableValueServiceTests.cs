using ITBees.BaseServices.Settings.Models;
using ITBees.BaseServices.Settings.Services;
using NUnit.Framework;

namespace ITBees.BaseServices.UnitTests.SettingsTests
{
    public class ReplaceableValueServiceTests
    {
        [Test]
        public void Resolver_shouldReturnStringWithReplacedValues()
        {
            var someTestInputString = @"
Test text with replacable fields...
Value  for first setting should be set here :[[FIRST_SETTING]]
";
            var testSettingImpl = new TestSettingImpl();
            var someExpectedResultString = $@"
Test text with replacable fields...
Value  for first setting should be set here :{testSettingImpl.FIRST_SETTING}
";

            var processedResult = ReplaceableValueService.Process(someTestInputString, testSettingImpl);

            Assert.True(processedResult == someExpectedResultString, $"Expected result was : \n{someExpectedResultString}, but received : \n{processedResult}");
        }

        [Test]
        public void Resolver_shouldReturnStringWithReplacedValuesWhenAdditionalValuesAreAddedInParameter()
        {
            var testToken = "8cb6f18e-6973-4b12-8259-d46421568cfa";
            var someTestInputString = @"
Test text with replacable fields...
Value  for first setting should be set here :[[FIRST_SETTING]] Token : [[TOKEN]]
";
            var testSettingImpl = new TestSettingImpl();
            var someExpectedResultString = $@"
Test text with replacable fields...
Value  for first setting should be set here :{testSettingImpl.FIRST_SETTING} Token : {testToken}
";

            var processedResult = ReplaceableValueService.Process(someTestInputString, testSettingImpl, new ReplaceableField("TOKEN", testToken));

            Assert.True(processedResult == someExpectedResultString, $"Expected result was : \n{someExpectedResultString}, but received : \n{processedResult}");
        }

        [Test]
        public void Resolver_shouldReturnStringWithReplacedValuesWhenOnlyReplaceableFieldsAreGiven()
        {
            var testToken = "8cb6f18e-6973-4b12-8259-d46421568cfa";
            var someTestInputString = @"
Test text with replacable fields...
Token : [[TOKEN]]
";
            var testSettingImpl = new TestSettingImpl();
            var someExpectedResultString = $@"
Test text with replacable fields...
Token : {testToken}
";

            var processedResult = ReplaceableValueService.Process(someTestInputString, new ReplaceableField("TOKEN", testToken));

            Assert.True(processedResult == someExpectedResultString, $"Expected result was : \n{someExpectedResultString}, but received : \n{processedResult}");
        }
    }
}