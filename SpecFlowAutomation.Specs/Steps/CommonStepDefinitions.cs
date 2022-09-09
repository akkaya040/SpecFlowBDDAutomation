using System;
using System.Threading;
using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowAutomation.Specs.Drivers;
using SpecFlowAutomation.Specs.PageObjects;

namespace SpecFlowAutomation.Specs.Steps
{
    [Binding]
    public class CommonStepDefinitions : BrowserDriver
    {
        private readonly IWebDriver _webDriver;
        private readonly CommonPageObject _commonPageObject;

        public CommonStepDefinitions(BrowserDriver browserDriver)
        {
            _webDriver = browserDriver.GetIWebDriver();
            _commonPageObject = new CommonPageObject(_webDriver);
        }

        [Given(@"User should see that page title contains ""(.*)""")]
        public void ThenUserShouldSeeThePageWithContent(string expectedTitle)
        {
            var limit = 10;
            while (!_webDriver.Title.Contains(expectedTitle))
            {
                Thread.Sleep(500);
                if (--limit <= 0)
                    break;
            }

            _webDriver.Title.Should().Contain(expectedTitle);
        }


        [Given("User navigates to env: (.*)")]
        public void GivenUserNavigatesTo(string env)
        {
            var url = env switch
            {
                "QA" => DefaultSettings.ENV_URL_QA,
                "DEV" => DefaultSettings.ENV_URL_DEV,
                "LIVE" => DefaultSettings.ENV_URL_LIVE,
                _ => DefaultSettings.ENV_URL
            };

            url += DefaultSettings.ENV_LANG;

            try
            {
                _webDriver.Url = url;
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [Given(@"Wait")]
        public void GivenWait()
        {
            _commonPageObject.ThreadWaitForSecond(10);
        }

        [Given(@"User should see that confirmation popup message contains ""(.*)""")]
        public void GivenUserShouldSeeThatConfirmationPopupMessage(string message)
        {
            _commonPageObject.ControlPopupMessage(message);
        }

        [Given(@"User clicks (.*) button on confirmation popup")]
        public void GivenUserClicksYesButtonForConfirmPopup(string selection)
        {
            _commonPageObject.ClickAnswerConfirmationPopup(selection);
        }

        [Given(@"User refresh the page")]
        public void GivenUserRefreshThePage()
        {
            _commonPageObject.RefreshCurrentPage();
        }


        [Given(@"User clicks ""(.*)"" button on burger menu")]
        public void GivenUserClicksButtonOnBurgerMenu(string buttonName)
        {
            _commonPageObject.ClickButtonInBurgerMenu(buttonName);
        }

        [Given(@"User clicks (.*) button in page")]
        public void GivenUserClicksBurgerMenuButton(string buttonName)
        {
            _commonPageObject.ClickBurgerMenuButton(buttonName);
        }
    }
}