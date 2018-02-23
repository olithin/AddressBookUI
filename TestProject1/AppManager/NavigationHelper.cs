using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            if (driver.Url == "addressbook/" && IsElementPresent(By.Name("add")))
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "addressbook/");
        }


        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "addressbook/group.php"
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void ClickAddNew()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}