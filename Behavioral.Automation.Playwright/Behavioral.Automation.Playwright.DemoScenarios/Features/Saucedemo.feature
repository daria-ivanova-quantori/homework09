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

    Scenario: Add item to cart via wrapper
        Given application URL is opened
        And user entered "standard_user" into "Username"
        And user entered "secret_sauce" into "Password"
        And user clicked on "Login button"
        When user adds the "Sauce Labs Backpack" item from "Inventory List" to the cart
        When user adds the "Sauce Labs Bike Light" item from "Inventory List" to the cart
        Then the "Shopping Cart Badge" text should be "2"

    Scenario: Remove item from cart via wrapper
        Given application URL is opened
        And user entered "standard_user" into "Username"
        And user entered "secret_sauce" into "Password"
        And user clicked on "Login button"
        And user added the "Sauce Labs Backpack" item from "Inventory List" to the cart
        When user removes the "Sauce Labs Backpack" item from "Inventory List" from the cart
        Then the "Shopping Cart Badge" should be not visible