using Microsoft.Playwright;
using NUnit.Framework;
using Tests.Common;
using Tests.PlaywrightUtil;

namespace Tests.TestsUtil
{
    public abstract class TestBase
    {
        protected IPage Page { get; private set; } = null!;

        [OneTimeSetUp]
        public static void OneTimeTestSetUp()
        {
            //Initialize Environment Configurations, Without this the Local Env Value is not set.
            EnvConfiguration.InitEnvConfiguration();
        }

        [SetUp]
        public async Task PageSetup()
        {
            //Initalize the Playwright
            Page = AppSetting.TestConfig.Browser.IsRemote
                ? await PlaywrightProvider.GetPlaywrightMoonRemoteInstanceAsync()
                : await PlaywrightProvider.GetPlaywrightLocalInstanceAsync();
        }

        [TearDown]
        public async Task TearDown()
        {
            //Kill and Close Browser
            await Page.Context.CloseAsync();
            await Page.Context.Browser.DisposeAsync();
        }
    }
}