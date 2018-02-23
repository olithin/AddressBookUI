using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class SearchTest : AuthTestBase
    {
        [Test]
        public void TestSerch()
        {
            System.Console.Out.Write(app.Contacts.GetNumberOfSearch());
        }
    }
}