using Microsoft.Playwright;
using static Microsoft.Playwright.Assertions;

namespace Tests.Pages
{
    public class Header(IPage Page)
    {
        /// <summary>
        /// Click in Header the Burger Menu Link.
        /// </summary>
        /// <returns></returns>
        public async Task<Header> ClickBurgerMenu()
        {
            await Page.Locator("#react-burger-menu-btn").ClickAsync();
            return this;
        }

        /// <summary>
        /// Click in Header the Cart Icon Link.
        /// </summary>
        /// <returns></returns>
        public async Task<Header> ClickCartIcon()
        {
            await Page.Locator("#shopping_cart_container").ClickAsync();
            return this;
        }

        /// <summary>
        /// Verify the SwagLab Text after Login at Header.
        /// </summary>
        /// <returns></returns>
        public async Task<Header> VerifySwagLabsTextAfterLoginAsync()
        {
            await Expect(Page.GetByText("Swag Labs")).ToBeVisibleAsync();
            return this;
        }
    }
}