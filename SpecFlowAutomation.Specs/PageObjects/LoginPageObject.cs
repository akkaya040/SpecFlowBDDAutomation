using System;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowAutomation.Specs.Drivers;

namespace SpecFlowAutomation.Specs.PageObjects
{
    public class LoginPageObject : BrowserDriver
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public LoginPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        //Finding elements by ID,Xpath,CssSelector
        private IWebElement TxtUsername => _webDriver.FindElement(By.Id("user-name"));
        private IWebElement TxtPassword => _webDriver.FindElement(By.Id("password"));
        private By ByBtnLogin => By.XPath("//input[contains(@value,'Login')]");
        private IWebElement BtnLogin => _webDriver.FindElement(ByBtnLogin);
        private By ByTxtErrorMessage => By.XPath("//h3[contains(@data-test,'error')]");
        private IWebElement TxtErrorMessage => _webDriver.FindElement(ByTxtErrorMessage);


        public void FillUserName(string un)
        {
            TxtUsername.SendKeys(un);
            User.Username = un;
        }

        public void FillPassword(string pw)
        {
            TxtPassword.SendKeys(pw);
        }

        public void ClickLoginButtonInPage()
        {
            WaitUntilElementClickable(ByBtnLogin, _webDriver, 10);
            BtnLogin.Click();
        }


        private T WaitUntil<T>(Func<T> getResult, Func<T, bool> isResultAccepted) where T : class
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(60));
            return wait.Until(driver =>
            {
                var result = getResult();
                if (!isResultAccepted(result))
                    return default;

                return result;
            }) ?? throw new NotFoundException();
        }

        public void ControlLoginMessage(string expectedMessage)
        {
            WaitUntilElementVisible(ByTxtErrorMessage, _webDriver, 5);

            string message = TxtErrorMessage.Text;
            message.Should().Contain(expectedMessage);
        }
    }
}