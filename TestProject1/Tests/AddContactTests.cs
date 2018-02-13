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
            ContactData contact = new ContactData("Vera", "Long");
            contact.Firstname = "Vera";
            contact.Lastname = "Long";

            app.Contacts.CreateNewContact(contact);
        }

        [Test]
        public void AddEmptyContactTest()
        {
            ContactData contact = new ContactData("", "");
            contact.Firstname = "";
            contact.Lastname = "";

            app.Contacts.CreateNewContact(contact);
        }
    }
}