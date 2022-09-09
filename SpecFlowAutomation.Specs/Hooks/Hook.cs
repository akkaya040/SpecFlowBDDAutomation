using OpenQA.Selenium;
using SpecFlowAutomation.Specs.Drivers;

namespace SpecFlowAutomation.Specs.Hooks
{
    //public class Hook : IDisposable
    [Binding]
    public class Hook
    {
        private readonly BrowserDriver _browserDriver;

        //private readonly IObjectContainer _objectContainer;
        private IWebDriver _webdriver = null!;


        //public Hook(IObjectContainer objectContainer, BrowserDriver browserDriver)
        public Hook(BrowserDriver browserDriver)
        {
            //_objectContainer = objectContainer;
            _browserDriver = browserDriver;
        }


        //Orjinal
        [BeforeScenario("@Automation")]
        //public static void BeforeScenario(BrowserDriver browserDriver)
        public void BeforeScenario()
        {
            _webdriver = _browserDriver.GetIWebDriver();
            //_objectContainer.RegisterInstanceAs<IWebDriver>(_webdriver);
        }

        [AfterScenario("@Automation")]
        public void AfterScenario()
        {
            _webdriver.Quit();
            _webdriver.Dispose();
            //_objectContainer.Dispose();
            _browserDriver.Dispose();
        }


        [AfterStep]
        public void AfterEachStep()
        {
        }
    }
}