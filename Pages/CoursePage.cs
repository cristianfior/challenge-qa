using OpenQA.Selenium;

namespace grupoa_challengeqa.Pages
{
    public class CoursePage
    {
        private readonly IWebDriver _driver;
        public CoursePage(IWebDriver driver) => _driver = driver;

        public void SelectLevel(string level) => _driver.FindElement(By.XPath($"//option[contains(text(), '{level}')]")).Click();
        public string CourseUrl() { return _driver.Url; }

        private IWebElement SelectBox => _driver.FindElement(By.XPath("//button[@data-testid='graduation-combo']"));
        public void OpenCourseSelect() => SelectBox.Click();

        private IWebElement CourseList => _driver.FindElement(By.XPath("//div[contains(@id, 'radix-vue-combobox-option')]"));
        public bool CourseListDisplayed() => CourseList.Displayed;

        public void SelectCourse() => _driver.FindElement(By.XPath("(//div[@role='option'])[1]")).Click();

        public void GoToCourses(string level)
        {
            _driver.Navigate().GoToUrl("https://developer.grupoa.education/subscription/");
            _driver.FindElement(By.XPath($"//option[contains(text(), '{level}')]")).Click();
        }
    }
}