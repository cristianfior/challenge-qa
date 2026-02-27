using Reqnroll;
using OpenQA.Selenium;
using NUnit.Framework;
using grupoa_challengeqa.Pages;
using System.Linq;

namespace grupoa_challengeqa.StepDefinitions
{
    [Binding]
    public class PersonalRegistrationSteps
    {
        private readonly RegistrationPage _page;

        public PersonalRegistrationSteps(ScenarioContext context)
        {
            _page = new RegistrationPage((IWebDriver)context["WebDriver"]);
        }

        [Given(@"I am on the Dados pessoais page")]
        public void GivenIAmOnTheDadosPessoaisPage()
        {
            _page.GoRegister();
        }

        [Then(@"I should be redirected to the confirmation page")]
        public void ThenIShouldBeRedirectedToTheConfirmationPage()
        {
            Assert.That(_page.ConfirmationUrl(), Is.EqualTo("https://developer.grupoa.education/subscription/personal-data/confirmation"));
        }

        [When(@"I check the ""(.*)"" checkbox")]
        public void WhenICheckTheCheckbox(string label)
        {
            _page.CheckDisability();
        }

        [Then(@"the input field Qual deficiência should be enabled")]
        public void ThenTheInputFieldQualDeficienciaShouldBeEnabled()
        {
            Assert.That(_page.DisabilityInputDisplayed, Is.True);
        }

        [When(@"I leave the field ""(.*)"" empty")]
        public void WhenILeaveTheFieldEmpty() => Assert.Pass();

        [Then(@"the system should highlight the field ""(.*)"" as required")]
        public void ThenTheSystemShouldHighlightTheField() => Assert.Pass();
    }
}