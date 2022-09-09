using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SpecFlowAutomation.Specs.Drivers
{
    public static class HelperFunctions
    {
        private static Random random = new();

        public static void HoverToElement(IWebElement webElement, IWebDriver webDriver)
        {
            Actions action = new Actions(webDriver);
            action.MoveToElement(webElement).Perform();
            Thread.Sleep(500);
        }

        public static int GenerateRandomNumberInRange(int min, int max)
        {
            return random.Next(min, max + 1);
        }

        public static string GetDate(string format, int dayCount)
        {
            DateTime date = DateTime.Now.AddDays(dayCount);
            return date.ToString(format);
        }

        public static void SlowSendKeys(this IWebElement element, string text)
        {
            foreach (char ch in text)
            {
                element.SendKeys(ch.ToString());
                Thread.Sleep(200);
            }
        }

        public static bool ContainsAny(this string controlString, params string[] strings)
        {
            return strings.Any(str => controlString.Contains(str));
        }

        public static void JsClick(this IWebElement element, IWebDriver driver)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor) driver;
            executor.ExecuteScript("arguments[0].click();", element);
        }

        public static void ClickEnabled(this IList<IWebElement> elements)
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

        public static IWebElement GetDisplayed(this ReadOnlyCollection<IWebElement> elements)
        {
            IWebElement enabled = null!;
            foreach (var element in elements)
            {
                if (element.Displayed)
                {
                    enabled = element;
                    break;
                }
            }

            if (enabled == null)
                throw new ElementNotVisibleException(); //Exception("Element Not Visible Exception");

            return enabled;
        }

        public static string GenerateRandomGuid()
        {
            return Guid.NewGuid().ToString();
        }

        public static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}