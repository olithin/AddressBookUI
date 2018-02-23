using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void TestContactInformation()
        {
            var fromTable = app.Contacts.GetContactInformationFromTable(0);
            var fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }


        [Test]

        public void TestDetailsContactInformation()
        {
            var fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            var fromDetails = app.Contacts.GetContactInformationFromDetailsForm(0);
            Assert.AreEqual(fromForm.ContactDetails, fromDetails.ContactDetails);
        }
    }
} 
