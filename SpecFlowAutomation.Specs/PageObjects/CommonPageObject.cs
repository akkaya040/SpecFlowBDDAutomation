using System.Threading;
using FluentAssertions;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using SpecFlowAutomation.Specs.Drivers;

namespace SpecFlowAutomation.Specs.PageObjects
{
    public class CommonPageObject : BrowserDriver
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        public CommonPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        //Finding elements by ID,Xpath,CssSelector

        private By ByBtnBurger => By.Id("react-burger-menu-btn");
        private IWebElement BtnBurger => _webDriver.FindElement(ByBtnBurger);

        private By ByBtnBasket => By.Id("shopping_cart_container");
        private IWebElement BtnBasket => _webDriver.FindElement(ByBtnBasket);

        private By ByBtnFilter => By.CssSelector("select[class='product_sort_container']");
        private IWebElement BtnFilter => _webDriver.FindElement(ByBtnFilter);
        private IWebElement BtnAllItems => _webDriver.FindElement(By.Id("inventory_sidebar_link"));

        private IWebElement BtnAbout => _webDriver.FindElement(By.Id("about_sidebar_link"));

        private IWebElement BtnLogout => _webDriver.FindElement(By.Id("logout_sidebar_link"));

        private IWebElement BtnReset => _webDriver.FindElement(By.Id("reset_sidebar_link"));


        private IWebElement TxtPopupMessage =>
            _webDriver.FindElement(By.XPath("//div[@role='alert']//div[@id='swal2-content']"));

        private By ByBtnYes => By.XPath("//button[contains(text(),'Yes')]");
        private IWebElement BtnYes => _webDriver.FindElement(By.XPath("//button[contains(text(),'Yes')]"));
        private By ByBtnNo => By.XPath("//button[contains(text(),'No')]");
        private IWebElement BtnNo => _webDriver.FindElement(By.XPath("//button[contains(text(),'No')]"));


        public void ClickButtonInBurgerMenu(string buttonName)
        {
            switch (buttonName)
            {
                case "LOGOUT":
                    BtnLogout.Click();
                    break;
                case "ALL ITEMS":
                    BtnAllItems.Click();
                    break;
                case "ABOUT":
                    BtnAbout.Click();
                    break;
                case "RESET APP STATE":
                    BtnReset.Click();
                    break;
            }
        }

        public void ClickBurgerMenuButton(string buttonName)
        {
            switch (buttonName)
            {
                case "burger menu":
                    BtnBurger.Click();
                    break;
                case "filter":
                    BtnFilter.Click();
                    break;
                case "basket":
                    BtnBasket.Click();
                    break;
            }
        }


        public void RefreshCurrentPage()
        {
            _webDriver.Navigate().Refresh();
        }

        public void ClickAnswerConfirmationPopup(string selection)
        {
            if (selection.Equals("yes"))
            {
                WaitUntilElementClickable(ByBtnYes, _webDriver, 10);
                BtnYes.Click();
            }
            else
            {
                WaitUntilElementClickable(ByBtnNo, _webDriver, 10);
                BtnNo.Click();
            }
        }

        public void ControlPopupMessage(string expectedMessage)
        {
            CreateWait(_webDriver)
                .Until(ExpectedConditions.ElementToBeClickable(TxtPopupMessage))
                .Text
                .Should()
                .Contain(expectedMessage);
        }

        public void ThreadWaitForSecond(int i)
        {
            Thread.Sleep(i * 1000);
        }
    }
}