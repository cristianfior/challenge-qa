using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace grupoa_challengeqa.Pages
{
    public class GeneralPage
    {
        private readonly IWebDriver _driver;
        public GeneralPage(IWebDriver driver) => _driver = driver;

        private IWebElement PrivacyContent => _driver.FindElement(By.XPath("//h1[contains(text(), 'Política de Privacidade')]"));
        public bool TextDisplayed() => PrivacyContent.Displayed;

        public void EducationSelect() => _driver.FindElement(By.XPath("//button[@data-testid='education-level-select']")).Click();
        private IReadOnlyCollection<IWebElement> LevelOptions => _driver.FindElements(By.XPath("//select[@data-testid='education-level-select']//option[not(@value='empty')]"));
        public List<string> LevelList() => LevelOptions.Select(e => e.Text).ToList();

        private IWebElement ThemeButton => _driver.FindElement(By.Id("radix-vue-dropdown-menu-trigger-2"));
        public void OpenTheme() => ThemeButton.Click();
        private IReadOnlyCollection<IWebElement> ThemeOptions => _driver.FindElements(By.XPath("//div[@role='menuitem']"));
        public List<string> ThemeList() => ThemeOptions.Select(e => e.Text).ToList();
    }
}