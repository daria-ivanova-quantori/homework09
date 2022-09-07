Feature: Saucedemo

    Scenario: Purchase
        Given application URL is opened
        And user entered "standard_user" into "Username"
        And user entered "secret_sauce" into "Password"
        When user clicks on "Login button"
        And user clicks on "Add Backpack to Cart"
        And user clicks on "Cart Button"
        And user clicks on "Checkout Button"
        And user enters "firstName" into "First Name"
        And user enters "lastName" into "Last Name"
        And user enters "0160" into "Postal Code"
        And user clicks on "Continue Button"
        And user clicks on "Finish Button"
        Then the "Page Header" text should be "Checkout: Complete!"

    Scenario: Check amount of elements on page
        Given application URL is opened
        And user entered "standard_user" into "Username"
        And user entered "secret_sauce" into "Password"
        And user clicked on "Login button"
        Then there should be 6 of "Inventory Item" items