using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace SpecFlowAutomation.Specs.Drivers
{
    public class Drivers
    {
        public IWebDriver GetDriver(Browsers browser)
        {
            return browser switch
            {
                Browsers.Chrome => GetChromeDriver(),
                Browsers.Firefox => GetFirefoxDriver(),
                Browsers.Random => GetRandomDriver(),
                // Browsers.Edge => GetEdgeDriver(),
                _ => GetChromeDriver()
            };
        }

        private IWebDriver GetRandomDriver()
        {
            var num = HelperFunctions.GenerateRandomNumberInRange(1, 2);

            if (num == 1)
            {
                return GetFirefoxDriver();
            }
            else
            {
                return GetChromeDriver();
            }
        }


        private IWebDriver GetFirefoxDriver()
        {
            var firefoxDriverService = FirefoxDriverService.CreateDefaultService();
            var firefoxOptions = new FirefoxOptions();
            if (DefaultSettings.IS_BROWSER_HEADLESS)
            {
                firefoxOptions.AddArgument("--headless");
            }

            firefoxOptions.AddArgument("--width=1920");
            firefoxOptions.AddArgument("--height=1080");

            return new FirefoxDriver(firefoxDriverService, firefoxOptions);
        }

        private IWebDriver GetChromeDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--window-size=1920,1080", "start-maximized");
            chromeOptions.AddArgument("no-sandbox");

            // In Order to Run Headless Chrome
            if (DefaultSettings.IS_BROWSER_HEADLESS)
            {
                chromeOptions.AddArguments("--headless", "--window-size=1920,1080");
            }

            return new ChromeDriver(chromeDriverService, chromeOptions);
        }

        // public IWebDriver GetEdgeDriver()
        // {
        //     var edgeDriverService = EdgeDriverService.CreateDefaultService();
        //     var edgeOptions = new EdgeOptions();
        //     edgeOptions.AddArguments("--window-size=1920,1080", "start-maximized");
        //     
        //     if (DefaultSettings.IS_BROWSER_HEADLESS)
        //     {
        //         edgeOptions.AddArguments("--headless", "--window-size=1920,1080");
        //     }
        //     
        //     return new EdgeDriver(edgeDriverService, edgeOptions);
        // }
    }
}