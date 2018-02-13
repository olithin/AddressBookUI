using NUnit.Framework;

namespace AddressbookWebTests
{
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(1);
        }
    }
}