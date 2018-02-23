using System.Collections.Generic;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupCreated())
            {
                var group = new GroupData("vera");
                group.Header = "my";
                group.Footer = "group";
                app.Groups.Create(group);
            }
            var newData = new GroupData("leo");
            newData.Header = "new";
            newData.Footer = "long";
            app.Groups.Modify(1, newData);
        }
        
        
        [Test]
        public void GroupModificationWithSortTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupCreated())
            {
                var group = new GroupData("vera");
                group.Header = "my";
                group.Footer = "group";
                app.Groups.Create(group);
            }

            var oldGroups = app.Groups.GetGroupList();
            var oldData = oldGroups[0];
            var newData = new GroupData("leo")
            {
                Header = "new",
                Footer = "long"
            };
            app.Groups.Modify(0, newData);
            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());
            var newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            foreach (var group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}