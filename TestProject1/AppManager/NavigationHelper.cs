using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class NavigationHelper  : HelperBase
    {
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ClickAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}