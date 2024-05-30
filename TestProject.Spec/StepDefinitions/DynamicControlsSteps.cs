using NUnit.Framework;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Spec.StepDefinitions
{
    [Binding]
    public class DynamicControlsSteps
    {
        private readonly DynamicControlsPage _dynamicControlsPage;

        public DynamicControlsSteps()
        {
            _dynamicControlsPage = new DynamicControlsPage();
        }

        [Given("I click the enable button")]
        public void WhenIClickOnTheEnableButton()
        {
            _dynamicControlsPage.ClickOnEnableButton();
        }

        [Then(@"the input box is enabled")]
        public void ThenTheEnableButtonIsEnabled()
        {
            Assert.That(_dynamicControlsPage.IsInputEnabled(), Is.True, "Input element is not enabled");
        }

        [When(@"I set '([^']*)' in the input box")]
        public void WhenISetInTheInputBox(string inputText)
        {
            _dynamicControlsPage.SetInputValue(inputText);
        }

        [Then(@"'([^']*)' is displayed")]
        public void ThenIsDisplayed(string inputText)
        {
            Assert.That(_dynamicControlsPage.GetInputValue(), Is.EqualTo(inputText), "Input element value is not correct");
        }
    }
}
