using Microsoft.Playwright;
using Tests.Common;
using static Microsoft.Playwright.Assertions;

namespace Tests.Pages
{
    public class SauceLabLoginPage(IPage page) : PageBase(page)
    {
        /// <summary>
        /// Go to Confirm Layer Url and Login the User with Email.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public async Task<SauceLabProductsPage> GoToSauceLabAndUserLogin(string userName, string password)
        {
            return await GoToApplicationLoginPage().Result
                 .EnterUserName(userName).Result
                 .EnterPassword(password).Result
                 .ClickLogInButton();
        }

        /// <summary>
        /// Go to Login Page.
        /// </summary>
        /// <returns></returns>
        public async Task<SauceLabLoginPage> GoToApplicationLoginPage()
        {
            await Page.GotoAsync(AppSetting.TestConfig.Application.ApplicationUrl);
            return this;
        }

        /// <summary>
        /// Enter UserName
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<SauceLabLoginPage> EnterUserName(string username)
        {
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "user-name" }).FillAsync(username);
            return this;
        }

        /// <summary>
        /// Enter Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<SauceLabLoginPage> EnterPassword(string password)
        {
            await Page.GetByRole(AriaRole.Textbox, new() { Name = "password" }).FillAsync(password);
            return this;
        }

        /// <summary>
        /// Click Sign In Button
        /// </summary>
        /// <returns></returns>
        public async Task<SauceLabProductsPage> ClickLogInButton()
        {
            await Page.GetByText("Sign in").ClickAsync();
            return new SauceLabProductsPage(page);
        }

        /// <summary>
        /// Verify Login Page is displayed.
        /// </summary.
        /// <returns></returns>
        public async Task<SauceLabLoginPage> VerifySwagLabsLoginPageDisplayed()
        {
            await Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Swag Labs" })).ToBeVisibleAsync();
            return this;
        }
    }
}