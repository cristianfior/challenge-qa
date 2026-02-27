using Reqnroll;
using OpenQA.Selenium;
using NUnit.Framework;
using grupoa_challengeqa.Pages;
using System;
using System.Threading;

namespace grupoa_challengeqa.StepDefinitions
{
    [Binding]
    public class SharedSteps
    {
        private readonly ScenarioContext _context;
        private readonly GeneralPage _generalPage;
        private readonly SharedPage _sharedPage;

        public SharedSteps(ScenarioContext context)
        {
            _context = context;
            var driver = (IWebDriver)_context["WebDriver"];
            _generalPage = new GeneralPage(driver);
            _sharedPage = new SharedPage((IWebDriver)context["WebDriver"]);
        }

        private IWebDriver Driver => (IWebDriver)_context["WebDriver"];

        [Given(@"I have access to the platform")]
        public void GivenIHaveAccessToThePlatform()
        {
            _sharedPage.GoTo("https://developer.grupoa.education/subscription/");
        }

        [Given(@"I am on the ""(.*)"" page")]
        [When(@"I navigate to the ""(.*)"" page")]
        public void NavigateToThePage(string page)
        {
            GivenIHaveAccessToThePlatform();
            _sharedPage.GoToPage(page);
        }

        [When(@"I click on the ""(.*)"" button")]
        public void WhenIClickOnTheButton(string button)
        {
            _sharedPage.ClickButton(button);
        }

        [Then(@"I should be redirected to the Home page")]
        public void ThenIShouldBeRedirectedToTheHomePage()
        {
            Assert.That(Driver.Url, Does.Contain("/subscription"));
        }

        [Given(@"I fill the fields:")]
        [When(@"I fill the fields:")]
        public void WhenIFillFields(DataTable table)
        {
            foreach (var row in table.Rows)
            {
                string field = row["Field"];
                string value = row["Value"];

                if (value == "[RANDOM]")
                {
                    value = RandomizeData.GetValue(field);
                }
                _sharedPage.Type(field, value);
            }
        }

    }
}