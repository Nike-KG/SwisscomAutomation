using SwisscomAutomation.Utilities;

namespace SwisscomAutomation.Pages;

public class DetailsPage : BasePage
{
    private WebDriver _driver;

    private IWebElement _addToCartButton => WaitHelper.WaitUntilElementExists(_driver,By.CssSelector("sdx-button[aria-label='To cart']"));
    private IWebElement _continueShoppingButton => WaitHelper.WaitUntilElementExists(_driver,By.CssSelector("sdx-button[aria-label='Continue shopping']"));
    public DetailsPage(WebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    /// <summary>
    /// Add selected product to cart.
    /// </summary>
    public void AddProductToCart() => ElementActionHelper.WebElementClick(_addToCartButton); 
    
    /// <summary>
    /// Click Continue Shopping button in Add to Cart pop up.
    /// </summary>
    public void ContinueShopping() => ElementActionHelper.WebElementClick(_continueShoppingButton);  
   
}
