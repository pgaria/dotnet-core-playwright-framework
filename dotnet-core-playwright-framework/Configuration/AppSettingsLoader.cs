using Microsoft.Extensions.Configuration;
using System.Runtime.CompilerServices;

namespace Tests.Configuration
{
    public static class AppSettingsLoader
    {
        private const string AppSettingsNameDefault = "appsettings";
        private const string TestEnvironmentVariable = "TEST_ENVIRONMENT";
        private static IConfiguration _configuration;

        public static T GetTestConfiguration<T>() where T : new()
        {
            T result = new T();
            GetConfiguration().GetSection("TestConfiguration").Bind(result);
            return result;
        }

        public static T GetTestData<T>() where T : new()
        {
            T result = new T();
            GetConfiguration().GetSection("TestData").Bind(result);
            return result;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static IConfiguration GetConfiguration()
        {
            if (_configuration != null)
                return _configuration;

            var targetEnv = Environment.GetEnvironmentVariable(TestEnvironmentVariable) ?? "UNKNOWN";

            var appSettingConfigFileName = $"{AppSettingsNameDefault}.{targetEnv.ToLower()}.json";

            //Check if the Appsettings File Present first
            if (!File.Exists(appSettingConfigFileName))
                throw new EntryPointNotFoundException("Test environment Variable is not Set, So unable to find AppSettings file with valid Test environment name: " + appSettingConfigFileName);

            // Load Configuration
            _configuration = new ConfigurationBuilder()
                .AddJsonFile($"{AppSettingsNameDefault}.json", false, false)
                .AddJsonFile(appSettingConfigFileName, false, false)
                .AddJsonFile($"{AppSettingsNameDefault}.local.json", true, false) // Inject secrets locally
                .AddEnvironmentVariables() // GitLab injects secrets via env variables
                .Build();

            return _configuration;
        }
    }
}