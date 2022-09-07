using Behavioral.Automation.Configs;
using Behavioral.Automation.Playwright.Configs;
using Behavioral.Automation.Playwright.ElementSelectors;

namespace Behavioral.Automation.Playwright.Pages;

class MainPage : ISelectorStorage
{
    private static readonly string Id = ConfigManager.GetConfig<Config>().SearchAttribute;

    public ElementSelector PageHeader = new() { Selector = "//span[@class='title']" };

    //Login
    public ElementSelector Username = new() { IdSelector = "username" };
    public ElementSelector Password = new() { IdSelector = "password" };
    public ElementSelector LoginButton = new() { IdSelector = "login-button" };

    //Items
    public ElementSelector AddBackpackToCart = new() { IdSelector = "add-to-cart-sauce-labs-backpack" };

    public ItemSelector InventoryList = new()
    {
        Selector = "//*[@class='inventory_item']",
        ItemNameSelector = new ElementSelector() { Selector = "//div[@class='inventory_item_name']" },
        addToCartButtonSelector = new ElementSelector() { Selector = "//*[contains(@id,'add-to-cart-')]" },
        removeFromCartButtonSelector = new ElementSelector() { IdSelector = "contains(remove-)" }
    };

    //ShoppingCart
    public ElementSelector ShoppingCartBadge = new() { Selector = "//span[@class='shopping_cart_badge']" };
    public ElementSelector CartButton = new() { Selector = "//div[@class='shopping_cart_container']" };
    public ElementSelector CheckoutButton = new() { IdSelector = "checkout" };

    //Checkout 
    public ElementSelector FirstName = new() { IdSelector = "firstName" };
    public ElementSelector LastName = new() { IdSelector = "lastName" };
    public ElementSelector PostalCode = new() { IdSelector = "postalCode" };
    public ElementSelector ContinueButton = new() { IdSelector = "continue" };
    public ElementSelector FinishButton = new() { IdSelector = "finish" };
}