@Automation
@E2E
@retry
Feature: E2E
End To End Test Scenarios In Order To Test Functionalities of Web Site

    Background:
        Given User navigates to env: QA
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see that page is product page

    @AddProductControl
    Scenario: Add Basket And Control 1
        And User add "Sauce Labs Backpack" in basket
        * User should see that basket product count is 1
        And User clicks burger menu button in page
        And User clicks "LOGOUT" button on burger menu

    @AddProductControl
    Scenario: Add Basket And Control 2
        And User add "Sauce Labs Backpack" in basket
        And User add "Sauce Labs Bolt T-Shirt" in basket
        * User should see that basket product count is 2
        And User clicks basket button in page
        And User clicks burger menu button in page
        And User clicks "LOGOUT" button on burger menu

    @AddProductAndResetControl
    Scenario: Add Basket And Reset App Status
        And User add "Sauce Labs Backpack" in basket
        And User add "Sauce Labs Bolt T-Shirt" in basket
        * User should see that basket product count is 2
        And User clicks basket button in page
        And User clicks burger menu button in page
        And User clicks "RESET APP STATE" button on burger menu
        And User clicks "LOGOUT" button on burger menu

    @AddProductAndDelProduct
    Scenario: Add Basket And Delete From Basket
        And User add "Sauce Labs Backpack" in basket
        * User should see that basket product count is 1
        And User clicks basket button in page
        And User removes "Sauce Labs Backpack" in basket

    @BuyProduct
    Scenario: Buy Product
        And User add "Sauce Labs Backpack" in basket
        * User should see that basket product count is 1
        And User clicks basket button in page
        And User clicks checkout button in basket
        And User fills address form
        And User click continue button in basket
        * User should see that order total price is correct
        And User click finish button in basket
        * User should see that order confirmed

    @FilterOrderByPriceDesc
    Scenario: Filter Order By Price Desc

    @FilterOrderByPriceHighToLow
    Scenario: Filter Order By Price High To Low

    @FilterOrderByPriceLowToHigh
    Scenario: Filter Order By Price Low To High