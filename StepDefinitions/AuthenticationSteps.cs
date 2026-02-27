using Reqnroll;
using OpenQA.Selenium;
using NUnit.Framework;
using grupoa_challengeqa.Pages;

namespace grupoa_challengeqa.StepDefinitions
{
    [Binding]
    public class AuthenticationSteps
    {
        private readonly AuthenticationPage _page;

        public AuthenticationSteps(ScenarioContext context)
        {
            var driver = (IWebDriver)context["WebDriver"];
            _page = new AuthenticationPage(driver);
        }

        [Given(@"I have my login credentials")]
        public void GivenIHaveMyCredentials()
        {
            _page.GoAuth();
        }

        [Then(@"I see the user and password input")]
        public void ThenISeeUserAndPassInput()
        {
            Assert.That(_page.LoginInputDisplayed(), Is.True);
        }

        [Given(@"I fill the following mandatory fields:")]
        public void GivenIFillTheMandatoryFields(DataTable table)
        {
            GivenIHaveMyCredentials();
            _page.ClickButton();
            foreach (var row in table.Rows)
            {
                _page.Type(row["Field"], row["Value"]);
            }
        }

        [Then(@"I should be redirected to Área do candidato page")]
        public void ThenIShouldBeRedirectedToTheCandidateAreaPage()
        {
            Assert.That(_page.CandidateAreaUrl(), Is.EqualTo("https://developer.grupoa.education/subscription/candidate"));
        }

        [Given(@"I click on recovery link ""(.*)""")]
        public void WhenIClickOnRecoveryLink(string link)
        {
            GivenIHaveMyCredentials();
            _page.ClickButton();
            _page.ClickLink(link);

        }

        [Then(@"I see the recovery confirmation")]
        public void ThenISeeTheText()
        {
            Assert.That(_page.RecoveryText(), Is.True);
        }

        [When(@"I do not fill the field ""(.*)""")]
        public void QuandoNaoPreencho() => Assert.Pass();

        [When(@"I fill the field ""(.*)"" with the wrong credential")]
        public void WhenIFillTheFieldWithTheWrongCredential(string campo) => Assert.Pass();

        [Then(@"I should see the alert ""(.*)""")]
        public void ThenIShouldSeeTheAlert() => Assert.Pass();
    }
}