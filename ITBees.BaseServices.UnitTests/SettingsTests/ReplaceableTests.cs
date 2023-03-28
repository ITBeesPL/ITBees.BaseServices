﻿using ITBees.BaseServices.Settings.Services;
using NUnit.Framework;

namespace ITBees.BaseServices.UnitTests.SettingsTests
{
    public class ReplaceableTests
    {
        [Test]
        public void Test()
        {
            var replaceableFields = Replaceable.GetRepacableFieldsWithValues(new TestSettingImpl());
            Assert.True(replaceableFields.Count == 1, $"Expected setting properties count was 1 but received {replaceableFields.Count}");
        }
    }
}