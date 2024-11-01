using AutoTestLibrary.Configuration;
using Tests.Model;

namespace Tests.Common
{
    public static class AppSetting
    {
        public static TestConfiguration TestConfig { get; private set; }
        public static TestData TestData { get; private set; }

        // Static constructor is called at most one time, before any
        // instance constructor is invoked or member is accessed.
        static AppSetting()
        {
            TestConfig = AppSettingsLoader.GetTestConfiguration<TestConfiguration>();
            TestData = AppSettingsLoader.GetTestData<TestData>();
        }
    }
}