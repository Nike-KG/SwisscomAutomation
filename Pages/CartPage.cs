using OpenQA.Selenium;
using SwisscomAutomation.Utilities;
using System.Collections.ObjectModel;

namespace SwisscomAutomation.Pages;

public class CartPage : BasePage
{
    private WebDriver _driver;

    private IWebElement _summaryCartLabelText => WaitHelper.WaitUntilElementExists(_driver, By.CssSelector("div[class='summary-title']"));
    private ReadOnlyCollection<IWebElement> _productList => WaitHelper.WaitUntilAllElementExists(_driver, By.CssSelector("div[class='product-name']"), 50);
    public CartPage(WebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    /// <summary>
    /// Get all product items in shopping cart
    /// </summary>
    /// <returns></returns>
    public ReadOnlyCollection<IWebElement> GetShoppingCartItems() 
    {
        var productList = _productList;

        if (productList.Count == 0)
        {
            var currentAttempt = 0;
            while (currentAttempt < 3)
            {
                Task.Delay(TimeSpan.FromSeconds(1));
                
                var summary = _summaryCartLabelText;
                productList = _productList;                
                
                currentAttempt++;
            }
        }

        return productList;
    } 
}
