using ApiTests.Tests.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly By enableBtn = By.XPath(string.Format(XpathPatterns.preciseTextXpath, "Enable"));
        private static readonly By input = By.XPath("//input[@type='text']");
        private static readonly string randomValue = Guid.NewGuid().ToString();

        [Test]
        public void DynamicControlsTest()
        {
            MainPage mainPage = new MainPage();
            mainPage.ClickOnDynamicControl();
            var driver = Browser.GetDriver();
            driver.FindElement(enableBtn).Click();

            var inputElement = Browser.GetDriver().FindElement(input);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(d => inputElement.Enabled);

            //assert input is enabled
            Assert.That(inputElement.Enabled, Is.True, "Input element is not enabled");

            //input randomly generated text
            inputElement.SendKeys(randomValue);

            //assert input text
            Assert.That(inputElement.GetAttribute("value"),
                Is.EqualTo(randomValue));
        }
    }
    
}
