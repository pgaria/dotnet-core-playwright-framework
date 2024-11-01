using Microsoft.Playwright;

namespace Tests.Pages
{
    public abstract class PageBase
    {
        public readonly IPage Page;

        public Header Header { get; private set; }

        protected PageBase(IPage page)
        {
            Page = page;
            Header = new(page);
        }
    }
}