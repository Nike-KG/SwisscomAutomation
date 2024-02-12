using SwisscomAutomation.Utilities;
using System.Xml.Linq;

namespace SwisscomAutomation.Pages;

public class NavigationBar : BasePage
{
    private WebDriver _driver;

    private ISearchContext _sdxHeaderRoot => WaitHelper.WaitUntilElementExists(_driver, By.TagName("sdx-header")).GetShadowRoot();
    private IWebElement _devicesOption => _sdxHeaderRoot.FindElement(By.CssSelector("a[aria-label='Devices']"));
    private IWebElement _accessoriesOption => _sdxHeaderRoot.FindElement(By.CssSelector("a[aria-label='Accessories']"));
    private IWebElement _headphonesOption => _sdxHeaderRoot.FindElement(By.CssSelector("a[aria-label='Headphones']"));
    private IWebElement _shoppingOption => _sdxHeaderRoot.FindElement(By.CssSelector("a[aria-label='icon-shopping-trolley']"));
    public NavigationBar(WebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    /// <summary>
    /// Click Devices menu in Navigation bar.
    /// </summary>
    /// <returns></returns>
    public string ClickDevicesNavigation()
    {
        ElementActionHelper.WebElementClick(_devicesOption);
        return _devicesOption.Text;      
    }

    /// <summary>
    /// Click Accessories submenu in Devices menu.
    /// </summary>
    /// <returns></returns>
    public string ClickAccessoriesNavigation()
    {
        ElementActionHelper.WebElementClick(_accessoriesOption);
        return _accessoriesOption.Text;
    }

    /// <summary>
    /// Click Headphones submenu in Accessories menu.
    /// </summary>
    /// <returns></returns>
    public string ClickHeadphonesNavigation()
    {
        var head = _headphonesOption.Text;
        ElementActionHelper.WebElementClick(_headphonesOption);
        return head;
    }

    /// <summary>
    /// Click Shopping Basket in Navigation menu.
    /// </summary>
    public void ClickShoppingBasket() => ElementActionHelper.WebElementClick(_shoppingOption);
    
}