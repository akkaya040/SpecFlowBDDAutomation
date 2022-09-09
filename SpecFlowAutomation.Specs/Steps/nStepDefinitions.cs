using SpecFlowAutomation.Specs.Drivers;
using SpecFlowAutomation.Specs.PageObjects;

namespace SpecFlowAutomation.Specs.Steps
{
    [Binding]
    public class nStepDefinitions
    {
        private readonly nPageObject _nPageObject;

        public nStepDefinitions(BrowserDriver browserDriver)
        {
            _nPageObject = new nPageObject(browserDriver.GetIWebDriver());
        }
    }
}