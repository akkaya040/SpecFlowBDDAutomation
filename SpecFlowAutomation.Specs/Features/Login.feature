@Automation
@Login
@retry

Feature: Login

    Background:
        Given User navigates to env: QA

    @Smoke
    Scenario: Landing To Login Page
        * User should see that page title contains "Swag Labs"

    @LoginTestUsingDataSource
    @DataSource:../Data/userdata.xlsx
    @DataSet:Sheet1
    Scenario: Logins With Different User Credentials From File
        * User should see that page title contains "Swag Labs"
        And User fills username as "<username>"
        And User fills password as "<userpass>"
        And User clicks login button in the page
        * User should see "<expectedMessage>" message

    @userLogin
    Scenario Outline: Logins With Different User Credentials Table
        * User should see that page title contains "Swag Labs"
        And User fills username as "<username>"
        And User fills password as "<userpass>"
        And User clicks login button in the page
        * User should see "<expectedMessage>" message

        Examples:
          | username                | userpass     | expectedMessage                                             |
          |                         |              | Username is required                                        |
          | test                    |              | Password is required                                        |
          | test                    | test         | Username and password do not match any user in this service |
          | locked_out_user         | secret_sauce | Sorry, this user has been locked out.                       |
          | standard_user           | secret_sauce |                                                             |
          | problem_user            | secret_sauce |                                                             |
          | performance_glitch_user | secret_sauce |                                                             |

    @Positive
    @LoginWithCorrectUsernameAndPassword
    Scenario: Login With Correct Username And Password
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see "" message

    @Negative
    @LoginWithWrongPassword
    Scenario: Login With Correct Username Wrong Password
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as "secret_sauce_asd"
        And User clicks login button in the page
        * User should see "Username and password do not match any user in this service" message

    @Negative
    @LoginWithoutPassword
    Scenario: Login Without Password
        * User should see that page title contains "Swag Labs"
        And User fills username as "standard_user"
        And User fills password as ""
        And User clicks login button in the page
        * User should see "Password is required" message

    @Negative
    @LoginWithoutUsername
    Scenario: Login Without Username
        * User should see that page title contains "Swag Labs"
        And User fills username as ""
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see "Username is required" message

    @Negative
    @LoginWithLockedOutUser
    Scenario: Login With Locked Out User
        * User should see that page title contains "Swag Labs"
        And User fills username as "locked_out_user"
        And User fills password as "secret_sauce"
        And User clicks login button in the page
        * User should see "Sorry, this user has been locked out." message