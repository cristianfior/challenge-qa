using Reqnroll;
using OpenQA.Selenium;
using NUnit.Framework;
using grupoa_challengeqa.Pages;
using System.Linq;
using System;

namespace grupoa_challengeqa.StepDefinitions
{
    [Binding]
    public class GeneralNavigationSteps
    {
        private readonly GeneralPage _generalPage;

        public GeneralNavigationSteps(ScenarioContext context)
        {
            _generalPage = new GeneralPage((IWebDriver)context["WebDriver"]);
        }

        [Then(@"I should see an informative text about privacy policy")]
        public void ThenIShouldSeeAnInformativeTextAboutPrivacyPolicy()
        {
            Assert.That(_generalPage.TextDisplayed(), Is.True);
        }

        [Then(@"I should see a level selection box with:")]
        public void ThenIShouldSeeALevelSelectionBoxWith(DataTable table)
        {
            _generalPage.EducationSelect();
            var courseLevel = _generalPage.LevelList();
            foreach (var row in table.Rows)
            {
                Assert.That(courseLevel, Contains.Item(row["Level"]));
            }
        }

        [When(@"I click on the theme selection button")]
        public void WhenIClickOnTheThemeSelectionButton()
        {
            _generalPage.OpenTheme();
        }

        [Then(@"I should see the following theme options:")]
        public void ThenIShouldSeeTheFollowingThemeOptions(DataTable table)
        {
            var themeOptions = _generalPage.ThemeList();
            foreach (var row in table.Rows)
            {
                Assert.That(themeOptions, Contains.Item(row["Option"]));
            }
        }
    }
}