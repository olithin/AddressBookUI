using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Leo", "Shev");
            newData.Firstname = "Leo";
            newData.Lastname = "Shev";

            app.Contacts.Modify(1, newData);
        }
    }
}