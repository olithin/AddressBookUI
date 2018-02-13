using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]

    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("zzz");
            newData.Header = "www";
            newData.Footer = "qqq";

            app.Groups.Modify(1, newData);
        }
    }
}



