using System.Threading.Tasks;
using Microsoft.Playwright;

namespace AutomatedUITesting.Web.Tests.UI.PageObjects
{
    public class LoginPageObject : BasePageObject
    {
        public override string PagePath => "https://localhost:5001/login";

        public LoginPageObject(IBrowser browser)
        {
            Browser = browser;
        }

        public override IPage Page { get; set; }

        public override IBrowser Browser { get; }

        public Task SetUsername(string username) => Page.FillAsync("#username-input", username);

        public Task SetPassword(string password) => Page.FillAsync("#password-input", password);

        public Task<string> GetErrorMessage() => Page.InnerTextAsync("#error-message");

        public Task ClickLoginButton() => Page.ClickAsync("form button");
    }
}
