using NUnit.Framework;
using Tests.Common;
using Tests.Pages;
using Tests.TestsUtil;

namespace Tests.PlaywrightTest.Tests.Login
{
    public class LoginOnSauceDemoApp : TestBase
    {
        [Test]
        [Category(TestCategory.Smoke)]
        [Property(TestProperty.TestRailId, "999999")]
        public async Task LoginTestUserOnSaucelabDemoApplication()
        {
            //Go to SauceDemo Application and Login With User.
            SauceLabProductsPage sauceLabProductsPage = new SauceLabLoginPage(Page).GoToSauceLabAndUserLogin(AppSetting.TestData.TestUser.StandardUser.UserEmail, AppSetting.TestData.TestUser.StandardUser.Password).Result;
            await sauceLabProductsPage.Header.VerifySwagLabsTextAfterLoginAsync();
        }
    }
}