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
        var test1 =  collection.Locator.Filter(new LocatorFilterOptions(){HasTextString = "item_4"});
    }

    [When(@"user removes the ""(.*)"" item from ""(.*)"" from the cart")]
    public async Task RemoveItemFromCart(string element, ItemWrapper collection)
    {
        // await Assertions.Expect(element.Locator).ToHaveTextAsync(expectedString);
    }
}