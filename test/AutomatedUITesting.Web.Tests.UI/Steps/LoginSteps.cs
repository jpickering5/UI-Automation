using System.Threading.Tasks;
using AutomatedUITesting.Web.Tests.UI.PageObjects;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace AutomatedUITesting.Web.Tests.UI.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly LoginPageObject _pageObject;

        public LoginSteps(LoginPageObject pageObject)
        {
            _pageObject = pageObject;
        }

        [Given(@"a logged out user")]
        public async Task GivenALoggedOutUser()
        {
            await _pageObject.NavigateAsync();
        }

        [When(@"the user attempts to log in with valid credentials")]
        public async Task WhenTheUserAttemptsToLogInWithValidCredentials()
        {
            await _pageObject.SetUsername("nick.chapsas@gmail.com");
            await _pageObject.SetPassword("1111");
            await _pageObject.ClickLoginButton();
        }

        [Then(@"they log in successfully")]
        public void ThenTheyLogInSuccessfully()
        {
            _pageObject.Page.Url.Should().EndWith("/logged-in");
        }

        [When(@"the user attempts to log in with invalid credentials")]
        public async Task WhenTheUserAttemptsToLogInWithInvalidCredentials()
        {
            await _pageObject.SetUsername("nick");
            await _pageObject.SetPassword("420");
            await _pageObject.ClickLoginButton();
        }

        [Then(@"the user is not logged in")]
        public void ThenTheUserIsNotLoggedIn()
        {
            _pageObject.Page.Url.Should().NotEndWith("/logged-in");
        }

        [Then(@"they see an error message")]
        public async Task ThenTheySeeAnErrorMessage()
        {
            var errorMessage = await _pageObject.GetErrorMessage();
            errorMessage.Should().Be("Wrong username or password");
        }
    }
}
