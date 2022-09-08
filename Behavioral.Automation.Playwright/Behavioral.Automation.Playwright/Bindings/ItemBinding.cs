using System.Threading.Tasks;
using Behavioral.Automation.Playwright.ElementTransformations;
using Behavioral.Automation.Playwright.WebElementsWrappers;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;


[Binding]
public class ItemBinding
{
    [Given(@"user added the ""(.*)"" item from ""(.*)"" to the cart")]
    [When(@"user adds the ""(.*)"" item from ""(.*)"" to the cart")]
    public async Task AddItemToCart(string element, ItemWrapper collection)
    {
        var count = await collection.Locator.CountAsync();

        for (var i = 0; i < count; i++)
        {
            string itemText = collection.itemName.Nth(i).InnerTextAsync().Result;

            if (itemText == element)
            {
                await collection.addToCartButton.Nth(i).ClickAsync();
                break;
            }
        }
    }

    [When(@"user removes the ""(.*)"" item from ""(.*)"" from the cart")]
    public async Task RemoveItemFromCart(string element, ItemWrapper collection)
    {
        var count = await collection.Locator.CountAsync();

        for (var i = 0; i < count; i++)
        {
            string itemText = collection.itemName.Nth(i).InnerTextAsync().Result;

            if (itemText == element)
            {
                if (i == 0)
                {
                    await collection.removeFromCartButton.Nth(i).ClickAsync();
                }
                else if (i != 0)
                {
                    await collection.removeFromCartButton.Nth(i - 1).ClickAsync();
                }

                break;
            }
        }
    }
}