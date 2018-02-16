using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]

    public class GroupRemovalTests : AuthTestBase
    {

        [Test]

        public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();

            if (!app.Groups.IsGroupCreated())
            {
                GroupData group = new GroupData("vera");
                group.Header = "my";
                group.Footer = "group";


                app.Groups.Create(group);
            }

            app.Groups.Remove(1);
        }
    }
}