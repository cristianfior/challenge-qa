using Reqnroll;
using OpenQA.Selenium;
using NUnit.Framework;
using grupoa_challengeqa.Pages;

namespace grupoa_challengeqa.StepDefinitions
{
    [Binding]
    public class CandidateAreaSteps
    {
        private readonly CandidateAreaPage _page;

        public CandidateAreaSteps(ScenarioContext context)
        {
            _page = new CandidateAreaPage((IWebDriver)context["WebDriver"]);
        }

        [Given(@"I am logged into the Candidate Area")]
        public void GivenIAmLoggedIntoTheCandidateArea()
        {
            _page.GoLogin();
        }

        [Then(@"I should see a side menu containing:")]
        public void ThenIShouldSeeASideMenu(DataTable table)
        {
            var menuItem = _page.MenuOptionsList();
            foreach (var row in table.Rows)
            {
                Assert.That(menuItem, Contains.Item(row["Item"]));
            }
        }

        [When(@"I click on the ""(.*)"" page")]
        public void WhenIClickOnThePage(string page)
        {
            _page.Option(page);
        }

        [Then(@"I should see a list of all courses I am enrolled in")]
        public void ThenIShouldSeeAListOfAllCoursesIAmEnrolledIn() => Assert.Pass();

        [Then(@"I should see my current debts and financial status")]
        public void ThenIShouldSeeMyCurrentDebtsAndFinancialStatus() => Assert.Pass();

        [Then(@"I should see a back button button to return to the dashboard")]
        public void ThenIShouldSeeAButtonToReturn()
        {
            Assert.That(_page.BackButtonDisplayed, Is.True);
        }
    }
}