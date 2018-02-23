using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace AddressbookWebTests
{
    [TestFixture]
    public class AddContactTests : AuthTestBase
    {

        [Test]
        public void AddContactTest()
        {
            var contact = new ContactData("Vera", "Long")
            {
                Firstname = "Vera",
                Lastname = "Longii"
            };

            app.Contacts.CreateNewContact(contact);
        }

        [Test]
        public void AddEmptyContactTest()
        {
            var contact = new ContactData("", "")
            {
                Firstname = "",
                Lastname = ""
            };

            app.Contacts.CreateNewContact(contact);
        }

        [Test]
        public void AddContactListTest()
        {
            var contact = new ContactData("Vera", "Long")
            {
                Firstname = "Vera",
                Lastname = "Long"
            };
            var oldContacts = app.Contacts.GetContactsList();
            app.Contacts.CreateNewContact(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            var newContacts = app.Contacts.GetContactsList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void AddEmptyContactListTest()
        {
            var contact = new ContactData("", "")
            {
                Firstname = "",
                Lastname = ""
            };
            var oldContacts = app.Contacts.GetContactCashList();
            app.Contacts.CreateNewContact(contact);
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());
            var newContacts = app.Contacts.GetContactCashList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}