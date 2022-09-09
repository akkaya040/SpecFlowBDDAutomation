using SpecFlowAutomation.Specs.Drivers;
using SpecFlowAutomation.Specs.PageObjects;

namespace SpecFlowAutomation.Specs.Steps
{
    [Binding]
    public class LoginStepDefinitions
    {
        private readonly LoginPageObject _loginPageObject;

        public LoginStepDefinitions(BrowserDriver browserDriver)
        {
            _loginPageObject = new LoginPageObject(browserDriver.GetIWebDriver());
        }

        [Given(@"User fills username as ""(.*)""")]
        public void GivenUserFillsUsernameAs(string username)
        {
            _loginPageObject.FillUserName(username);
        }

        [Given(@"User fills password as ""(.*)""")]
        public void GivenUserFillsPasswordAs(string password)
        {
            _loginPageObject.FillPassword(password);
        }


        [Given(@"User clicks login button in the page")]
        public void GivenUserClicksLoginButtonInThePage()
        {
            _loginPageObject.ClickLoginButtonInPage();
        }

        [Given(@"User should see ""(.*)"" message")]
        public void ThenUserShouldSeeMessage(string message)
        {
            if (!message.Equals(""))
            {
                _loginPageObject.ControlLoginMessage(message);
            }
        }
    }
}