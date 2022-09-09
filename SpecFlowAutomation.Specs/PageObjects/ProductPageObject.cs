using System.Collections.ObjectModel;
using FluentAssertions;
using OpenQA.Selenium;
using SpecFlowAutomation.Specs.Drivers;

namespace SpecFlowAutomation.Specs.PageObjects
{
    public class ProductPageObject : BrowserDriver
    {
        //The Selenium web driver to automate the browser
        private readonly IWebDriver _webDriver;

        //The default wait time in seconds for wait.Until
        public const int DefaultWaitInSeconds = 5;

        public ProductPageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        //Finding elements by ID,Xpath,CssSelector
        private IWebElement TxtProductPageTitle => _webDriver.FindElement(By.CssSelector("span[class='title']"));
        private IWebElement BtnCheckout => _webDriver.FindElement(By.XPath("//*[@id='checkout']"));
        private IWebElement BtnContinue => _webDriver.FindElement(By.XPath("//input[@id='continue']"));
        private IWebElement BtnFinish => _webDriver.FindElement(By.XPath("//button[@id='finish']"));
        private IWebElement TxtCompleteMessage => _webDriver.FindElement(By.XPath("//*[@class='complete-header']"));

        private IWebElement TxtBasketCount =>
            _webDriver.FindElement(By.XPath("//*[@id='shopping_cart_container']//span"));

        private By ByInventoryItem => By.XPath("//div[@class='inventory_item']");
        private ReadOnlyCollection<IWebElement> InventoryItems => _webDriver.FindElements(ByInventoryItem);
        private By ByInventoryItemPrice => By.XPath("//div[@class='inventory_item_price']");
        private By ByInventoryItemName => By.XPath("//div[@class='inventory_item_name']");
        private By ByInventoryItemAddToCard => By.XPath("//button[contains(text(),'Add to cart')]");
        private By ByCartItem => By.XPath("//div[@class='cart_item']");
        private ReadOnlyCollection<IWebElement> CartItems => _webDriver.FindElements(ByCartItem);
        private By ByCardItemRemove => By.XPath("//button[contains(text(),'Remove')]");

        private IWebElement BtnAddToCartByName(string pName) => _webDriver.FindElement(
            By.XPath("//div[@class='inventory_item_name'][contains(text(),'" + pName + "')]/../../..//button"));

        private IWebElement ProdPriceByName(string pName) => _webDriver.FindElement(
            By.XPath("//div[@class='inventory_item_name'][contains(text(),'" + pName +
                     "')]/../../..//div[@class='inventory_item_price']"));

        private IWebElement BtnRemoveByName(string pName) => _webDriver.FindElement(
            By.XPath("//div[@class='inventory_item_name'][contains(text(),'" + pName + "')]/../../..//button"));

        private IWebElement TxtFirstName => _webDriver.FindElement(By.XPath("//input[@id='first-name']"));
        private IWebElement TxtLastName => _webDriver.FindElement(By.XPath("//input[@id='last-name']"));
        private IWebElement TxtPostCode => _webDriver.FindElement(By.XPath("//input[@id='postal-code']"));


        public void ControlOrderConfirm()
        {
            TxtCompleteMessage.Text.Should().Be("THANK YOU FOR YOUR ORDER");
        }

        public void ClickFinishButton()
        {
            BtnFinish.Click();
        }

        public void AddProductByName(string productName)
        {
            string price = ProdPriceByName(productName).Text;
            BtnAddToCartByName(productName).Click();

            // string price = "";
            // IWebElement addToCart = null;
            //
            // foreach (var item in InventoryItems)
            // {
            //     if (item.Text.Contains(productName))
            //     {
            //         price = item.FindElement(ByInventoryItemPrice).Text;
            //         addToCart = item.FindElement(ByInventoryItemAddToCard);
            //         break;
            //     }
            // }
            //
            // if (addToCart == null)
            // {
            //     throw new ElementNotInteractableException();
            // }
            //
            // addToCart.Click();
        }


        public void FillAddressForm()
        {
            TxtFirstName.SendKeys("Kurtulus");
            TxtLastName.SendKeys("Akkaya");
            TxtPostCode.SendKeys(HelperFunctions.GenerateRandomNumberInRange(10000, 99999).ToString());
        }

        public void ClickCheckOut()
        {
            BtnCheckout.Click();
        }

        public void ClickContinueButton()
        {
            BtnContinue.Click();
        }

        public void ControlOrderPrice()
        {
        }

        public void VerifyProductPage()
        {
            TxtProductPageTitle.Text.Should().Be("PRODUCTS");
        }

        public void VerifyBasketPage()
        {
            BtnCheckout.Text.Should().Be("CHECKOUT");
        }

        public void CompareProductCount(int expectedCount)
        {
            var basketCount = TxtBasketCount.Text;
            basketCount.Should().Be(expectedCount.ToString());
        }

        public void DelProductByNameFromBasket(string productName)
        {
            string price = ProdPriceByName(productName).Text;
            BtnRemoveByName(productName).Click();


            // string price = "";
            // IWebElement removeFromCart = null;
            //
            // foreach (var item in CartItems)
            // {
            //     if (item.Text.Contains(productName))
            //     {
            //         price = _webDriver.FindElement(ByInventoryItemPrice).Text;
            //         removeFromCart=item.FindElement(ByCardItemRemove);
            //         break;
            //     }
            // }
            //
            // if (removeFromCart == null)
            // {
            //     throw new ElementNotInteractableException();
            // }
            //
            // removeFromCart.Click();
        }
    }
}