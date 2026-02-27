using System;
using OpenQA.Selenium;

namespace grupoa_challengeqa.Pages
{
    public class AuthenticationPage
    {
        private readonly IWebDriver _driver;
        public AuthenticationPage(IWebDriver driver) => _driver = driver;

        public bool LoginInputDisplayed() => _driver.FindElement(By.XPath("//input[contains(@data-testid, '-input')]")).Displayed;

        public void ClickLink(string link) => _driver.FindElement(By.XPath($"//a[contains(normalize-space(), '{link}')]")).Click();

        public void ClickButton() => _driver.FindElement(By.XPath($"//button[contains(normalize-space(), 'Acessar')]")).Click();
        public void Type(string field, string value) => _driver.FindElement(By.XPath($"//label[contains(normalize-space(), '{field}')]//..//input")).SendKeys(value);

        public string CandidateAreaUrl() { return _driver.Url; }

        public bool RecoveryText() => _driver.FindElement(By.XPath($"//h3")).Displayed;

        public void GoAuth()
        {
            _driver.Navigate().GoToUrl("https://developer.grupoa.education/subscription/");
            _driver.FindElement(By.XPath($"//option[contains(text(), 'Graduação')]")).Click();
            _driver.FindElement(By.XPath("//button[@data-testid='graduation-combo']")).Click();
            _driver.FindElement(By.XPath("(//div[@role='option'])[1]")).Click();
            _driver.FindElement(By.XPath($"//button[contains(normalize-space(), 'Avançar')]")).Click();
            string[] fields = { "CPF", "Nome", "Sobrenome", "Email", "Celular", "CEP", "Endereço", "Bairro", "Cidade", "Estado", "País" };
            foreach (string field in fields)
            {
                if (field != "CPF" && field != "CEP")
                {
                    _driver.FindElement(By.XPath($"//label[contains(normalize-space(), '{field}')]//..//input")).SendKeys("BAZINGA@COM.BR");
                }
                else if (field == "CPF")
                {
                    _driver.FindElement(By.XPath($"//label[contains(normalize-space(), '{field}')]//..//input")).SendKeys("067.796.940-61");
                }
                else if (field == "CEP")
                {
                    _driver.FindElement(By.XPath($"//label[contains(normalize-space(), '{field}')]//..//input")).SendKeys("00000000");
                }
            }
            _driver.FindElement(By.XPath($"//button[contains(normalize-space(), 'Avançar')]")).Click();
        }
        
    }
}