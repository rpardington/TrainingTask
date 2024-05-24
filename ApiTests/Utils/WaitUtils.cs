using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace TestProject.Utils
{
    internal static class WaitUtils
    {
        public static void WaitForEnabled(IWebElement element)
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(5));
            wait.Until(d => element.Enabled);
        }
    }
}