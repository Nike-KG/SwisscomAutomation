using SwisscomAutomation.Utilities;

namespace SwisscomAutomation.Pages;

public class HomePage : BasePage
{
    private WebDriver _driver;

    private IWebElement _cookieAcceptButton => WaitHelper.WaitUntilElementExists(_driver, By.Id("onetrust-reject-all-handler"));

    public HomePage(WebDriver driver) : base(driver)
    {
        _driver = driver;
    }

    /// <summary>
    /// Accept Cookies in the pop up
    /// </summary>
    public void ClickToAcceptCookie() => ElementActionHelper.WebElementClick(_cookieAcceptButton);


}
