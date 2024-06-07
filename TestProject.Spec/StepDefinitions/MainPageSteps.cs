using TestProject.Tests.Pages;

namespace TestProject.Spec.StepDefinitions
{
    [Binding]
    internal class MainPageSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public MainPageSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given("I have opened the Dynamic Control page")]
        public void GivenIHaveOpenedTheDynamicControlPage()
        {
            if (!_scenarioContext.ContainsKey("mainPage"))
            {
                var mainPage = new MainPage();
                _scenarioContext["mainPage"] = mainPage;
            }
            ((MainPage)_scenarioContext["mainPage"]).ClickOnDynamicControl();
        }
    }
}
