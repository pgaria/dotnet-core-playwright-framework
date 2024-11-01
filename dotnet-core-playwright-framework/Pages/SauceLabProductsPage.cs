using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Tests.Pages
{
    public class SauceLabProductsPage(IPage page) : PageBase(page)
    {
        /// <summary>
        /// VerifyProduct Page is displayed.
        /// </summary>
        /// <returns></returns>
        public async Task<SauceLabProductsPage> VerifyProductsPageDisplayed()
        {
            await Expect(Page.GetByText("Products")).ToBeVisibleAsync();
            return this;
        }

        /// <summary>
        /// Click Product with name 'Sauce Labs Backpack'.
        /// </summary>
        /// <returns></returns>
        public async Task<SauceLabProductsPage> ClickUploadButton()
        {
            await Page.GetByText("Sauce Labs Backpack").ClickAsync();
            return this;
        }
    }
}