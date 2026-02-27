using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace grupoa_challengeqa.Pages
{
    public class CandidateAreaPage
    {
        private readonly IWebDriver _driver;
        public CandidateAreaPage(IWebDriver driver) => _driver = driver;

        private IReadOnlyCollection<IWebElement> MenuOptions => _driver.FindElements(By.XPath("//a[contains(@href, '/candidate')]"));
        public List<string> MenuOptionsList() => MenuOptions.Select(e => e.Text).ToList();

        public void Option(string page) => _driver.FindElement(By.XPath($"//a[contains(normalize-space(), '{page}')]")).Click();

        public bool BackButtonDisplayed() => _driver.FindElement(By.XPath("//button[@data-testid='back-button']")).Displayed;

        public void GoLogin()
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
            _driver.FindElement(By.XPath($"//button[contains(normalize-space(), 'Acessar')]")).Click();
            _driver.FindElement(By.XPath($"//label[contains(normalize-space(), 'Usuário')]//..//input")).SendKeys("candidato");
            _driver.FindElement(By.XPath($"//label[contains(normalize-space(), 'Senha')]//..//input")).SendKeys("subscription");
            _driver.FindElement(By.XPath($"//button[contains(normalize-space(), 'Login')]")).Click();
        }

    }
}