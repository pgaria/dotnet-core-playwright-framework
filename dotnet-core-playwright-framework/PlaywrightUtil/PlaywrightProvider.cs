using Microsoft.Playwright;
using Tests.Common;

namespace Tests.PlaywrightUtil
{
    public static class PlaywrightProvider
    {
        private static readonly float _defaultMethodTimeout = AppSetting.TestConfig.Browser.TimeOut.DefaultMethodTimeout;
        private static readonly float _navigationTimeout = AppSetting.TestConfig.Browser.TimeOut.NavigationTimeout;
        private static readonly float _connectOptionsTimeout = AppSetting.TestConfig.Browser.TimeOut.ConnectOptionsTimeout;
        private static readonly string _playwrightVersion = AppSetting.TestConfig.Browser.PlaywrightVersion;

        /// <summary>
        /// Create the Playwright Remote Instance like Browser Stack Or LamdaTest to run the tests on the moon cluster.
        /// </summary>
        /// <returns></returns>
        public static async Task<IPage> GetPlaywrightMoonRemoteInstanceAsync()
        {
            var playwright = await Playwright.CreateAsync();
            string selenoid_url = "wss://" + AppSetting.TestConfig.Browser.RemoteHost + "/playwright/chrome/" + _playwrightVersion + "?headless=false&arg=--ignore-certificate-errors";
            IPage page = await (await playwright.Chromium.ConnectAsync(selenoid_url, new BrowserTypeConnectOptions()
            {
                Timeout = _connectOptionsTimeout,
            })).NewPageAsync();
            page.SetDefaultTimeout(_defaultMethodTimeout);
            page.SetDefaultNavigationTimeout(_navigationTimeout);
            return page;
        }

        /// <summary>
        /// Create and get the Playwright Local Instance.
        /// Note: Update the Browser Path in Your Local Machine for Chrome.
        /// </summary>
        /// <returns></returns>
        public static async Task<IPage> GetPlaywrightLocalInstanceAsync()
        {
            var playwright = await Playwright.CreateAsync();
            BrowserTypeLaunchOptions options = new()
            {
                ExecutablePath = Environment.CurrentDirectory + "\\AppData\\Local\\ms-playwright\\chromium-1040\\chrome-win\\chrome.exe",
                Headless = false
            };
            IBrowser browser = await playwright.Chromium.LaunchAsync(options);
            var context = await browser.NewContextAsync();
            IPage page = await context.NewPageAsync();
            return page;
        }
    }
}