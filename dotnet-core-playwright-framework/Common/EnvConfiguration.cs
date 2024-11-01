namespace Tests.Common
{
    public static class EnvConfiguration
    {
        public static void InitEnvConfiguration()
        {
#if DEBUG
            if (Environment.GetEnvironmentVariable(EnvironmentVariables.TEST_ENVIRONMENT) == null)
            {
                Environment.SetEnvironmentVariable(EnvironmentVariables.TEST_ENVIRONMENT, "Prod");
            }
#endif
        }

        public static string TargetEnvironment => Environment.GetEnvironmentVariable(EnvironmentVariables.TEST_ENVIRONMENT);
        public static string GitlabUserName => Environment.GetEnvironmentVariable(EnvironmentVariables.GITLAB_USER_NAME) ?? "unknown";
        public static string ConfirmLayerVersion => Environment.GetEnvironmentVariable(EnvironmentVariables.APP_VERSION) ?? "unknown";
        public static string TestDescription => Environment.GetEnvironmentVariable(EnvironmentVariables.TEST_DESCRIPTION) ?? "not defined";
        public static string TestCategory => Environment.GetEnvironmentVariable(EnvironmentVariables.TEST_CATEGORY) ?? "";
    }
}