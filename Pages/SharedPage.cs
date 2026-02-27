using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace grupoa_challengeqa.Pages
{
    public class SharedPage
    {
        private readonly IWebDriver _driver;
        public SharedPage(IWebDriver driver) => _driver = driver;

        public void GoTo(string url) => _driver.Navigate().GoToUrl(url);

        public void GoToPage(string page) => _driver.FindElement(By.XPath($"//a[contains(normalize-space(), '{page}')]")).Click();

        public void ClickButton(string button) => _driver.FindElement(By.XPath($"//button[contains(normalize-space(), '{button}')]")).Click();

        public void Type(string field, string value) => _driver.FindElement(By.XPath($"//label[contains(normalize-space(), '{field}')]//..//input")).SendKeys(value);
    }
}