using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowAutomation.Specs.Drivers;

namespace SpecFlowAutomation.Specs.PageObjects
{
    public class nPageObject : BrowserDriver
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public nPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        //Finding elements by ID,Xpath,CssSelector
        private IWebElement SampleElement => _webDriver.FindElement(By.XPath("//"));


        public void IsArrivedToThePage(string expectedHeader)
        {
            //PageHeader.Text.Should().Contain(expectedHeader);
            _webDriver.Title.Should().Contain(expectedHeader);
        }
    }
}