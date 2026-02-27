using OpenQA.Selenium;

namespace grupoa_challengeqa.Pages
{
    public class RegistrationPage
    {
        private readonly IWebDriver _driver;
        public RegistrationPage(IWebDriver driver) => _driver = driver;

        public string ConfirmationUrl() { return _driver.Url; }

        public void CheckDisability() => _driver.FindElement(By.Id("has-disability")).Click();
        private IWebElement DisabilityInput => _driver.FindElement(By.XPath($"//label[contains(normalize-space(), 'Qual deficiência?')]//..//input"));
        public bool DisabilityInputDisplayed() => DisabilityInput.Displayed;

        public void GoRegister()
        {
            _driver.Navigate().GoToUrl("https://developer.grupoa.education/subscription/");
            _driver.FindElement(By.XPath($"//option[contains(text(), 'Graduação')]")).Click();
            _driver.FindElement(By.XPath("//button[@data-testid='graduation-combo']")).Click();
            _driver.FindElement(By.XPath("(//div[@role='option'])[1]")).Click();
            _driver.FindElement(By.XPath($"//button[contains(normalize-space(), 'Avançar')]")).Click();
        }
    }
}