﻿using NUnit.Framework;

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
                GroupData group = new GroupData("vera");
                group.Header = "my";
                group.Footer = "group";


                app.Groups.Create(group);

            }

            GroupData newData = new GroupData("leo");
            newData.Header = "new";
            newData.Footer = "long";

            app.Groups.Modify(1, newData);
        }
    }
}