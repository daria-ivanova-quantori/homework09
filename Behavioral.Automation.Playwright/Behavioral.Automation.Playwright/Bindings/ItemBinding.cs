using System.Threading.Tasks;
using Behavioral.Automation.Playwright.ElementTransformations;
using Behavioral.Automation.Playwright.WebElementsWrappers;
using Microsoft.Playwright;
using TechTalk.SpecFlow;


[Binding]
public class ItemBinding
{
    [When(@"user adds the ""(.*)"" item from ""(.*)"" to the cart")]
    public async Task AddItemToCart(string element, ItemWrapper collection)
    {
        var count = await collection.Locator.CountAsync();
        var count1 = await collection.addToCartButton.CountAsync();
        
        await collection.addToCartButton.ClickAsync();
        // for (var i = 0; i < count; i++)
        // {
        //     if (collection.Locator.TextContentAsync(collection.Locator) == element)
        //     {
        //         
        //     }
        // }
    }

    [When(@"user removes the ""(.*)"" item from ""(.*)"" from the cart")]
    public async Task RemoveItemFromCart(string element, ItemWrapper collection)
    {
        // await Assertions.Expect(element.Locator).ToHaveTextAsync(expectedString);
    }
}