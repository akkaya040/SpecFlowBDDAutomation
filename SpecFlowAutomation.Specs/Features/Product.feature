@Automation
@Product
@retry

Feature: Product

    Background:
        Given User navigates to env: QA
        * User should see that page title contains "Swag Labs"
        And User fills username as "performance_glitch_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page

    @Smoke
    Scenario: Landing To Products Page
        And User clicks burger menu button in page
        And User clicks "LOGOUT" button on burger menu

    @AddAProduct
    Scenario: Add A Product
        And User add "Sauce Labs Backpack" in basket
        And User clicks basket button in page
        And User clicks burger menu button in page
        And User clicks "LOGOUT" button on burger menu

    @AddTwoProducts
    Scenario: Add Two Products
        And User add "Sauce Labs Backpack" in basket
        And User add "Sauce Labs Bolt T-Shirt" in basket
        And User clicks basket button in page
        And User clicks burger menu button in page
        And User clicks "LOGOUT" button on burger menu