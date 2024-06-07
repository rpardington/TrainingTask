using ApiTests.Tests.UI;
using TestProject.Tests.Pages;

namespace TestProject.Tests.UI
{
    internal class DynamicControlsTests : BaseTest
    {
        private static readonly string RandomValue = Guid.NewGuid().ToString();

        [Test]
        public void DynamicControlsTest()
        {
            var mainPage = new MainPage();
            mainPage.ClickOnDynamicControl();

            var dynamicControlsPage = new DynamicControlsPage();
            dynamicControlsPage.ClickOnEnableButton();

            //assert input is enabled
            Assert.That(dynamicControlsPage.IsInputEnabled(), Is.True, "Input element is not enabled");

            //input randomly generated text
            dynamicControlsPage.SetInputValue(RandomValue);

            //assert input text
            Assert.That(dynamicControlsPage.GetInputValue(), Is.EqualTo(RandomValue), "Input element value is not correct");
        }
    }
}