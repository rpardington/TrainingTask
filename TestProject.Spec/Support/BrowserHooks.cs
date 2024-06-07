using TestProject.Utils;

namespace TestProject.Spec.Support
{
    [Binding]
    internal class BrowserHooks
    {
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
    }
}
