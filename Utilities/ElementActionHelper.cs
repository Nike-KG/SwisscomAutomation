namespace SwisscomAutomation.Utilities;

public sealed class ElementActionHelper
{
    /// <summary>
    /// Click web elements with retry.
    /// </summary>
    /// <param name="webElement"></param>
    /// <exception cref="Exception"></exception>
    public static void WebElementClick(IWebElement webElement)
    {
        var currentAttempt = 0;
        while (currentAttempt < 3)
        {
            try
            {
                webElement.Click();
                return;
            }
            catch (ElementClickInterceptedException)
            {
                currentAttempt++;
                if (currentAttempt == 2)
                    throw new Exception(currentAttempt.ToString());
            }
            catch (ElementNotInteractableException)
            {
                currentAttempt++;
            }
            
        }
    }
}
