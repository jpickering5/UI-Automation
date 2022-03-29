using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomatedUITesting.Web.Tests.UI.PageObjects
{
    public class CounterPageObject : BasePageObject
    {
        public override string PagePath => "https://localhost:5001/counter";

        public CounterPageObject(IBrowser browser)
        {
            Browser = browser;
        }

        public override IPage Page { get; set; }

        public override IBrowser Browser { get; }

        public async Task ClickIncreaseButton() => await Page.ClickAsync("#increase-btn");

        public async Task<int> CounterValue() => int.Parse(await Page.InnerTextAsync("#counter-val"));


    }
}
