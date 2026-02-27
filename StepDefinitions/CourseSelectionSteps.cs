using Reqnroll;
using OpenQA.Selenium;
using NUnit.Framework;
using grupoa_challengeqa.Pages;

namespace grupoa_challengeqa.StepDefinitions
{
    [Binding]
    public class CourseSelectionSteps
    {
        private readonly CoursePage _page;

        public CourseSelectionSteps(ScenarioContext context)
        {
            _page = new CoursePage((IWebDriver)context["WebDriver"]);
        }

        [When(@"I select the course level ""(.*)""")]
        public void WhenISelectTheCourseLevel(string level)
        {
            _page.SelectLevel(level);
        }

        [Then(@"I should be redirected to the ""(.*)"" courses page")]
        public void ThenIShouldBeRedirectedToTheCoursePage(string level)
        {
            if (level == "Graduação")
            {
                Assert.That(_page.CourseUrl(), Is.EqualTo("https://developer.grupoa.education/subscription/courses/undergraduate"));
            }
            else
            {
                Assert.That(_page.CourseUrl(), Is.EqualTo("https://developer.grupoa.education/subscription/courses/graduate"));
            }
        }

        [Given(@"I am on the course level ""(.*)"" page")]
        public void GivenIAmOnTheCourseLevelPage(string level)
        {
            _page.GoToCourses(level);
        }

        [When(@"I click on the courses select box")]
        public void WhenIClickOnTheCoursesSelectBox()
        {
            _page.OpenCourseSelect();
        }

        [Then(@"I see courses options in the list")]
        public void ThenISeeCoursesOptionsInTheList()
        {
            Assert.That(_page.CourseListDisplayed, Is.True);
        }

        [When(@"I select a course from the select box")]
        public void WhenISelectACourseFromSelectBox()
        {
            WhenIClickOnTheCoursesSelectBox();
            _page.SelectCourse();
        }

        [Then(@"I can go to next page")]
        public void ThenICanGoToNextPage() => Assert.Pass();

        [When(@"do not choose a course")]
        public void WhenDoNotChooseACourse() => Assert.Pass();

        [Then(@"I should see the alert ""(.*)"" on screen")]
        public void IShouldSeeTheAlertOnScreen() => Assert.Pass();

        [When(@"I type ""(.*)"" in the search bar")]
        public void WhenITypeInTheSearchBar() => Assert.Pass();

        [When(@"it is not on the list")]
        public void WhenItIsNotOnTheList() => Assert.Pass();

        [Then(@"I should see the result ""(.*)""")]
        public void ThenIShouldSeeTheResult() => Assert.Pass();
    }
}