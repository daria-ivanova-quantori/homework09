using System.Threading.Tasks;
using Behavioral.Automation.Playwright.Context;
using Behavioral.Automation.Playwright.ElementSelectors;
using Microsoft.Playwright;

namespace Behavioral.Automation.Playwright.WebElementsWrappers;

public class ItemWrapper : WebElementWrapper
{
    public readonly ItemSelector ItemSelector;

    public ItemWrapper(WebContext webContext, ItemSelector itemSelector, string caption) : base(webContext,
        itemSelector, caption)
    {
        ItemSelector = itemSelector;
    }
    
    public ILocator itemName => GetChildLocator(ItemSelector.ItemNameSelector);
    public ILocator addToCartButton => GetChildLocator(ItemSelector.addToCartButtonSelector);
    public ILocator removeFromCartButton => GetChildLocator(ItemSelector.removeFromCartButtonSelector);
}