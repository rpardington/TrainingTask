using NUnit.Framework;
using TestProject.Tests.Pages;
using TestProject.Utils;

namespace TestProject.Spec.StepDefinitions
{
    [Binding]
    public class DynamicControlsTestStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;

        public DynamicControlsTestStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario("UI")]
        public static void Setup()
        {
            Browser.GetDriver().Navigate().GoToUrl(ConfigReader.GetConfigValue("webUIUrl"));
        }

        [AfterScenario("UI")]
        public static void TearDown()
        {
            Browser.GetDriver().Quit();
        }

        [Given("I have opened the Dynamic Control page")]
        public void GivenIHaveOpenedTheDynamicControlPage()
        {
            var mainPage = new MainPage();
            mainPage.ClickOnDynamicControl();
            _scenarioContext["mainPage"] = mainPage;
        }

        [Given("I click the enable button")]
        public void WhenIClickOnTheEnableButton()
        {
            var dynamicControlsPage = new DynamicControlsPage();
            dynamicControlsPage.ClickOnEnableButton();
            _scenarioContext["dynamicControlsPage"] = dynamicControlsPage;
        }

        [Then(@"the input box is enabled")]
        public void ThenTheEnableButtonIsEnabled()
        {
            var dynamicControlsPage = GetDynamicControlsPage();
            Assert.That(dynamicControlsPage.IsInputEnabled(), Is.True, "Input element is not enabled");
        }

        [When(@"I set '([^']*)' in the input box")]
        public void WhenISetInTheInputBox(string inputText)
        {
            var dynamicControlsPage = GetDynamicControlsPage();
            dynamicControlsPage.SetInputValue(inputText);
        }

        [Then(@"'([^']*)' is displayed")]
        public void ThenIsDisplayed(string inputText)
        {
            var dynamicControlsPage = GetDynamicControlsPage();
            Assert.That(dynamicControlsPage.GetInputValue(), Is.EqualTo(inputText), "Input element value is not correct");
        }

        private DynamicControlsPage GetDynamicControlsPage()
        {
            return (DynamicControlsPage)_scenarioContext["dynamicControlsPage"];
        }
    }
}
