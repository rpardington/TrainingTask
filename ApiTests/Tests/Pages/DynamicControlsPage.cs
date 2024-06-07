using OpenQA.Selenium;
using TestProject.Utils;

namespace TestProject.Tests.Pages
{
    public class DynamicControlsPage
    {
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        private static readonly By input = By.XPath("//input[@type='text']");

        public void ClickOnEnableButton()
        {
            Browser.GetDriver().FindElement(enableBtn).Click();
        }

        public bool IsInputEnabled()
        {
            var inputElement = GetInputElement();
            WaitUtils.WaitForEnabled(inputElement);
            return inputElement.Enabled;
        }

        public void SetInputValue(string value)
        {
            var inputElement = GetInputElement();
            inputElement.SendKeys(value);
        }

        public string GetInputValue()
        {
           return GetInputElement().GetAttribute("value");
        }

        private IWebElement GetInputElement()
        {
            return Browser.GetDriver().FindElement(input);
        }
    }
}
