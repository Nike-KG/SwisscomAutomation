using System.Collections.ObjectModel;

namespace SwisscomAutomation.Utilities;

public sealed class WaitHelper
{
    /// <summary>
    /// Web element find after exists.
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="elementLocator"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public static IWebElement WaitUntilElementExists(WebDriver driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until((driver) => driver.FindElement(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine($"Element with Locator {elementLocator} is not found in current context page.");
            throw; 
        }
    }

    /// <summary>
    ///  Web element find after exists.
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="element"></param>
    /// <param name="elementLocator"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public static IWebElement WaitUntilElementExists(WebDriver driver, ISearchContext element, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until((driver) => element.FindElement(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine($"Element with Locator {elementLocator} is not found in current context page.");
            throw;
        }
    }

    /// <summary>
    ///  Web element find after exists.
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="element"></param>
    /// <param name="elementLocator"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public static IWebElement WaitUntilElementExists(WebDriver driver, IWebElement element, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until((driver) => element.FindElement(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine($"Element with Locator {elementLocator} is not found in current context page.");
            throw;
        }
    }

    /// <summary>
    ///  Multiple web elements find after exists.
    /// </summary>
    /// <param name="driver"></param>
    /// <param name="elementLocator"></param>
    /// <param name="timeout"></param>
    /// <returns></returns>
    public static ReadOnlyCollection<IWebElement> WaitUntilAllElementExists(WebDriver driver, By elementLocator, int timeout = 10)
    {
        try
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            return wait.Until((driver) => driver.FindElements(elementLocator));
        }
        catch (NoSuchElementException)
        {
            Console.WriteLine($"Element with Locator {elementLocator} is not found in current context page.");
            throw;
        }
    }
}
