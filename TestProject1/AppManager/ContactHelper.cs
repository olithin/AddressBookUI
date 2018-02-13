using OpenQA.Selenium;

namespace AddressbookWebTests
{
 public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }

        public ContactHelper CreateNewContact(ContactData contact)
        {
            manager.Navigator.OpenHomePage();

            InitNewContact();
            FillNewContact(contact);
            SubmitNewContact();
            return this;
        }


        public ContactHelper Modify(int v, ContactData newData)
        {
            manager.Navigator.OpenHomePage();

            //SelectContact(v);
            EditContact(v);
            FillNewContact(newData);
            SubmitContactModification();
            return this;
        }

        public ContactHelper Remove(int v)
        {
            manager.Navigator.OpenHomePage();

            //SelectContact(v);
            EditContact(v);
            RemoveContact();
            return this;
        }


        public ContactHelper InitNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillNewContact(ContactData account)
        {

            Type(By.Name("firstname"), account.Firstname);
            Type(By.Name("lastname"), account.Lastname);
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            return this;
        }

        public ContactHelper Type(By locator, string text)
        {
            driver.FindElement(locator).Clear();
            driver.FindElement(locator).SendKeys(text);
            return this;
        }

        public ContactHelper SubmitNewContact()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }


        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index+ "]")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//input[@name='update']")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[3]")).Click();
            //driver.SwitchTo().Alert().Accept();
            return this;
        }
    }
}