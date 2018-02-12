using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class ContactHelper
    {
        private IWebDriver driver;

        public ContactHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void FillNewContact(ContactData account)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(account.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(account.Lastname);
        }

        public void SubmitNewContact()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}