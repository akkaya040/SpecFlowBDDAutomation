using SpecFlowAutomation.Specs.Drivers;
using SpecFlowAutomation.Specs.PageObjects;

namespace SpecFlowAutomation.Specs.Steps
{
    [Binding]
    public class ProductStepDefinitions
    {
        private readonly ProductPageObject _productPageObject;

        public ProductStepDefinitions(BrowserDriver browserDriver)
        {
            _productPageObject = new ProductPageObject(browserDriver.GetIWebDriver());
        }


        [Given(@"User should see that page is product page")]
        public void GivenUserShouldSeeThatPageIsProductPage()
        {
            _productPageObject.VerifyProductPage();
        }

        [Given(@"User should see that page is basket page")]
        public void GivenUserShouldSeeThatPageIsBasketPage()
        {
            _productPageObject.VerifyBasketPage();
        }

        [Given(@"User add ""(.*)"" in basket")]
        public void GivenTheUserAddInBasket(string prodName)
        {
            _productPageObject.AddProductByName(prodName);
        }

        [Given(@"User should see that basket product count is (.*)")]
        public void GivenUserShouldSeeThatBasketProductCountIs(int p0)
        {
            _productPageObject.CompareProductCount(p0);
        }

        [Given(@"User removes ""(.*)"" in basket")]
        public void GivenUserRemovesInBasket(string prodName)
        {
            _productPageObject.DelProductByNameFromBasket(prodName);
        }

        [Given(@"User clicks checkout button in basket")]
        public void GivenUserClicksCheckoutButtonInBasket()
        {
            _productPageObject.ClickCheckOut();
        }

        [Given(@"User fills address form")]
        public void GivenUserFillsAddressForm()
        {
            _productPageObject.FillAddressForm();
        }

        [Given(@"User click continue button in basket")]
        public void GivenUserClickContinueButtonInBasket()
        {
            _productPageObject.ClickContinueButton();
        }

        [Given(@"User should see that order total price is correct")]
        public void GivenUserShouldSeeThatOrderTotalPriceIsCorrect()
        {
            _productPageObject.ControlOrderPrice();
        }

        [Given(@"User click finish button in basket")]
        public void GivenUserClickFinishButtonInBasket()
        {
            _productPageObject.ClickFinishButton();
        }

        [Given(@"User should see that order confirmed")]
        public void GivenUserShouldSeeThatOrderConfirmed()
        {
            _productPageObject.ControlOrderConfirm();
        }
    }
}