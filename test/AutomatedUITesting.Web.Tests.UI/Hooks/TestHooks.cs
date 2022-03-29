using System.Threading.Tasks;
using AutomatedUITesting.Web.Tests.UI.PageObjects;
using BoDi;
using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace AutomatedUITesting.Web.Tests.UI.Hooks
{
    [Binding]
    public class TestHooks
    {
        [BeforeScenario("Counter")]
        public async Task BeforeCounterScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                //Headless = false,
                //SlowMo = 2000
            });
            var pageObject = new CounterPageObject(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(pageObject);
        }

        [BeforeScenario("Login")]
        public async Task BeforeLoginScenario(IObjectContainer container)
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                //SlowMo = 2000
            });
            var pageObject = new LoginPageObject(browser);
            container.RegisterInstanceAs(playwright);
            container.RegisterInstanceAs(browser);
            container.RegisterInstanceAs(pageObject);
        }

        [AfterScenario]
        public async Task AfterScenario(IObjectContainer container)
        {
            var browser = container.Resolve<IBrowser>();
            await browser.CloseAsync();
            var playwright = container.Resolve<IPlaywright>();
            playwright.Dispose();
        }
    }
}
