namespace Behavioral.Automation.Playwright.ElementSelectors;

public class ItemSelector : ElementSelector
{
    public ElementSelector BaseElementSelector { get; set; }
    public ElementSelector ItemNameSelector { get; set; }
    public ElementSelector addToCartButtonSelector { get; set; }
    public ElementSelector removeFromCartButtonSelector { get; set; }
}