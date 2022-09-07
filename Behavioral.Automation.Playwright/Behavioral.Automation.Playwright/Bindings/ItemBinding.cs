using System.Threading.Tasks;
using Behavioral.Automation.Playwright.ElementTransformations;
using Behavioral.Automation.Playwright.WebElementsWrappers;
using Microsoft.Playwright;
using NUnit.Framework;
using TechTalk.SpecFlow;


[Binding]
public class ItemBinding
{
    [When(@"user adds the ""(.*)"" item from ""(.*)"" to the cart")]
    public async Task AddItemToCart(string element, ItemWrapper collection)
    {
        var count = await collection.Locator.CountAsync();

        for (var i = 0; i < count; i++)
        {
            var divItemText = collection.itemName.Nth(i).InnerTextAsync();
            string itemText = divItemText.Result;

            if (itemText == element)
            {
                await collection.addToCartButton.Nth(i).ClickAsync();
            }
        }
    }

    [When(@"user removes the ""(.*)"" item from ""(.*)"" from the cart")]
    public async Task RemoveItemFromCart(string element, ItemWrapper collection)
    {
        // await Assertions.Expect(element.Locator).ToHaveTextAsync(expectedString);
    }
}