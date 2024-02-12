using SwisscomAutomation.Utilities;
using System;
using System.Collections.ObjectModel;
using System.Runtime.ConstrainedExecution;

namespace SwisscomAutomation.Pages;

public class HeadphonesPage : BasePage
{
    private WebDriver _driver;

    private ISearchContext selectRoot => WaitHelper.WaitUntilElementExists(_driver, By.TagName("sdx-select"), 20).GetShadowRoot();
    private IWebElement _brandFilter => WaitHelper.WaitUntilElementExists(_driver, selectRoot, By.CssSelector("div[class='wrapper']"), 50);
    private IWebElement _firstBrandOption => WaitHelper.WaitUntilElementExists(_driver, By.XPath("/html/body/sdx-select-list/sdx-select-option[1]"), 50);
    private IWebElement _loadMoreButton => WaitHelper.WaitUntilElementExists(_driver, By.CssSelector("sdx-button[aria-label='Load More']"));
 
    public HeadphonesPage(WebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    /// <summary>
    /// Select Brand filter in Headphone page.
    /// </summary>
    /// <returns></returns>
    public string SelectBrandMenuOption()
    {
        ElementActionHelper.WebElementClick(_brandFilter);
        return _brandFilter.Text;
    }

    /// <summary>
    /// Select first item in Brand list.
    /// </summary>
    /// <returns></returns>
    public string SelectFirstBrandName()
    {
        var brandText = _firstBrandOption.Text;
        ElementActionHelper.WebElementClick(_firstBrandOption);
        return brandText;
    }

    /// <summary>
    /// Select last Headphone item.
    /// </summary>
    /// <returns></returns>
    public string SelectLastHeadphone()
    {
        ClickLoadmoreButtonUntilLasts();
        var allFilteredProducts = _driver.FindElements(By.CssSelector("sdx-teaser[label-aria-level='3']"));
        var lastProduct = allFilteredProducts.Last().GetShadowRoot().FindElement(By.CssSelector("div[role='heading']"));
        var lastProductTitle = lastProduct.Text;
        ElementActionHelper.WebElementClick(allFilteredProducts.Last());
        return lastProductTitle;
    }

    //Click Load More button until disappear.
    private void ClickLoadmoreButtonUntilLasts()
    {
        
        ElementActionHelper.WebElementClick(_loadMoreButton);
        Thread.Sleep(1000);
        bool isContinue = _driver.FindElements(By.CssSelector("sdx-button[aria-label='Load More']")).Count() > 0;
        while (isContinue)
        {
            ElementActionHelper.WebElementClick(_loadMoreButton);
            isContinue = _driver.FindElements(By.CssSelector("sdx-button[aria-label='Load More']")).Count() > 0;
        }
    }
}

