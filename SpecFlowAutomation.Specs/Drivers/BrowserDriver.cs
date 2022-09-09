using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow.Tracing;


namespace SpecFlowAutomation.Specs.Drivers
{
    public enum Browsers
    {
        Chrome,
        Firefox,
        Edge,
        Random
    }

    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private readonly Drivers _drivers = new Drivers();
        private bool _isDisposed;

        public BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }


        public IWebDriver GetIWebDriver()
        {
            return _currentWebDriverLazy.Value;
        }

        private IWebDriver CreateWebDriver()
        {
            IWebDriver driver = _drivers.GetDriver(DefaultSettings.BROWSER_TYPE);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(DefaultSettings.DEFAULT_WEBDRIVER_WAIT);
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(DefaultSettings.DEFAULT_PAGELOAD_WAIT);
            driver.Manage().Window.Size = new Size(1920, 1080);
            driver.Manage().Window.Maximize();

            return driver;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                GetIWebDriver().Quit();
            }

            _isDisposed = true;
        }

        public static void TakeScreenshot(IWebDriver driver, ScenarioContext scenarioContext,
            FeatureContext featureContext)
        {
            try
            {
                var fileNameBase = string.Format("{0}_{1}_{2}",
                    scenarioContext.ScenarioInfo.Title.ToIdentifier(),
                    scenarioContext.StepContext.StepInfo.Text.Replace("\"", ""),
                    DateTime.Now.ToString("yyyyMMdd_HHmmss"));

                var artifactDirectory = Path.Combine(Directory.GetCurrentDirectory(),
                    "testresults/" + featureContext.FeatureInfo.Title.ToIdentifier());

                if (!Directory.Exists(artifactDirectory))
                    Directory.CreateDirectory(artifactDirectory);

                var pageSource = driver.PageSource;
                var sourceFilePath = Path.Combine(artifactDirectory, fileNameBase + "_source.html");
                File.WriteAllText(sourceFilePath, pageSource, Encoding.UTF8);
                Console.WriteLine("Page source: {0}", new Uri(sourceFilePath));

                ITakesScreenshot? takesScreenshot = driver as ITakesScreenshot;

                if (takesScreenshot != null)
                {
                    var screenshot = takesScreenshot.GetScreenshot();

                    string screenshotFilePath = Path.Combine(artifactDirectory, fileNameBase + "_screenshot.png");

                    screenshot.SaveAsFile(screenshotFilePath, ScreenshotImageFormat.Png);

                    Console.WriteLine("Screenshot: {0}", new Uri(screenshotFilePath));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while taking screenshot: {0}", ex);
            }
        }


        public WebDriverWait CreateWait(IWebDriver webDriver)
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(DefaultSettings.DEFAULT_WEBDRIVER_WAIT));
        }

        public WebDriverWait CreateWait(IWebDriver webDriver, int timeoutInSeconds)
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
        }

        public void WaitUntilElementClickable(By searchElementBy, IWebDriver webDriver, int timeoutInSeconds)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(drv => IsElementClickable(searchElementBy, webDriver));
        }

        public void WaitUntilElementVisible(By searchElementBy, IWebDriver webDriver, int timeoutInSeconds)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(drv => IsElementVisible(searchElementBy, webDriver));
        }

        public void WaitUntilElementNotVisible(By searchElementBy, IWebDriver webDriver, int timeoutInSeconds)
        {
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(drv => !IsElementVisible(searchElementBy, webDriver));
        }

        public bool IsElementVisible(By searchElementBy, IWebDriver webDriver)
        {
            try
            {
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                return webDriver.FindElement(searchElementBy).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                webDriver.Manage().Timeouts().ImplicitWait =
                    TimeSpan.FromSeconds(DefaultSettings.DEFAULT_WEBDRIVER_WAIT);
            }
        }

        public bool IsElementClickable(By searchElementBy, IWebDriver webDriver)
        {
            try
            {
                webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
                return webDriver.FindElement(searchElementBy).Enabled;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            finally
            {
                webDriver.Manage().Timeouts().ImplicitWait =
                    TimeSpan.FromSeconds(DefaultSettings.DEFAULT_WEBDRIVER_WAIT);
            }
        }

        public void ClickEnabledElement(IEnumerable<IWebElement> elements)
        {
            foreach (var element in elements)
            {
                if (element.Displayed)
                {
                    element.Click();
                    break;
                }
            }
        }
    }
}