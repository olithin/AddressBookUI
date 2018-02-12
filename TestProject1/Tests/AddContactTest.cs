using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AddressbookWebTests
{
    [TestFixture]
    public class AddContactTests : TestBase
    {
        [Test]
        public void AddContactTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.ClickAddNew();
            ContactData group = new ContactData("Vera", "Long");
            group.Firstname = "Vera";
            group.Lastname = "Long";
            app.Contacts.FillNewContact(group);
            app.Contacts.SubmitNewContact();
            app.Auth.Logout();
        }
    }
}