using Reqnroll;
using grupoa_challengeqa.Drivers;

namespace grupo_a_challenge_qa.Hooks;

[Binding]
public class Hooks
{
    private readonly ScenarioContext _scenarioContext;

    public Hooks(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void BeforeScenario(BrowserDriver browserDriver)
    {
        _scenarioContext["WebDriver"] = browserDriver.Current;
    }
}