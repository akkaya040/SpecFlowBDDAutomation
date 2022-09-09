@Automation
@Smoke
@retry
Feature: Smoke
These test only visit main pages and verify them.

    Background:
        Given User navigates to env: QA

    @Smoke
    @VisitLoginPage
    Scenario: Visit Login Page
        * User should see that page title contains "Swag Labs"

    @Smoke
    @VisitProductPage
    Scenario: Visit Product Page
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see that page is product page
        And User clicks burger menu button in page
        And User clicks "LOGOUT" button on burger menu

    @Smoke
    @VisitAllItemsPage
    Scenario: Visit All Items Page
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see that page is product page
        And User clicks burger menu button in page
        And User clicks "ALL ITEMS" button on burger menu
        And User clicks "LOGOUT" button on burger menu

    @Smoke
    @VisitAboutPage
    Scenario: Visit About Page
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see that page is product page
        And User clicks burger menu button in page
        And User clicks "ALL ITEMS" button on burger menu
        And User clicks "LOGOUT" button on burger menu

    @Smoke
    @VisitResetAppStatePage
    Scenario: Visit Reset App State Page
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see that page is product page
        And User clicks burger menu button in page
        And User clicks "RESET APP STATE" button on burger menu
        And User clicks "LOGOUT" button on burger menu

    @Smoke
    @VisitBasketPage
    Scenario: Visit Basket Page
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see that page is product page
        And User clicks basket button in page
        * User should see that page is basket page
        And User clicks burger menu button in page
        And User clicks "LOGOUT" button on burger menu