using System;
using BoDi;
using OpenQA.Selenium;
using SpecFlowAutomation.Specs.Drivers;

namespace SpecFlowAutomation.Specs.Hooks
{
    [Binding]
    public sealed class ScenarioHook : BrowserDriver
    {
        private readonly IObjectContainer _container;
        private readonly ScenarioContext _scenario;
        private readonly FeatureContext _feature;
        private readonly BrowserDriver _browserDriver;


        private bool IsFailingScenario => _scenario.TestError != null;

        public ScenarioHook(IObjectContainer container, ScenarioContext scenario, FeatureContext feature,
            BrowserDriver browserDriver)
        {
            _container = container;
            _scenario = scenario;
            _feature = feature;
            _browserDriver = browserDriver;
        }

        [AfterStep("@Automation")]
        public void AfterStepTasks()
        {
            var featureName = _feature.FeatureInfo.Title;
            var scenarioName = _scenario.ScenarioInfo.Title;
            var stepName = _scenario.StepContext.StepInfo.Text;


            Console.Out.WriteLine("| {0} | {1} | {2} |", featureName, scenarioName, stepName);
            System.Diagnostics.Debug.WriteLine("| {0} | {1} | {2} |", featureName, scenarioName, stepName);

            if (IsFailingScenario)
            {
                TakeScreenshot(_browserDriver.GetIWebDriver(), _scenario, _feature);
            }

            WaitForPageLoad();
        }

        private void WaitForPageLoad()
        {
            var wait = CreateWait(_browserDriver.GetIWebDriver());
            wait.Until(driver =>
                ((IJavaScriptExecutor) driver).ExecuteScript("return document.readyState").Equals("complete"));
            //wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("nav img[alt='Felixo']")));
        }
    }
}