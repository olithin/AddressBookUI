using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {

        [Test]
        public void GroupCreationTest()
        {
            var group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            var newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            var group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            var newGroups = app.Groups.GetGroupList();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
        
        [Test]
        public void GroupCreationSortTest()
        {
            var group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            var newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationSortCountTest()
        {
            var group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            var newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        
        [Test]
        public void GroupCreationSortCashCountTest()
        {
            var group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            var oldGroups = app.Groups.GetGroupCashList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());      
            var newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        
        [Test] //5.2
        public void GroupCreationSortCashCountOptimizTest()
        {
            var group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";          
            var oldGroups = app.Groups.GetGroupCashListOptimize();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());      
            var newGroups = app.Groups.GetGroupCashListOptimize();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        
        
        [Test, TestCaseSource("RandomgroupDataProvider")]
        public void GroupCreationParametrizeTest(GroupData groupData)
        {
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());
            var newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        
        
           //TODo not working     
        //для запуска теста с данными из csv файла ->клик на файле groups.csv ->properties -> select ->copy always
        [Test, TestCaseSource(nameof(GroupDataFromCsvFile))]
        public void GroupProviderCSVTest(GroupData groupData)
        {
            var oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(groupData);
            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            var newGroups = app.Groups.GetGroupList();
            oldGroups.Add(groupData);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        
 private static IEnumerable<GroupData> RandomgroupDataProvider()
        {
            var listGroups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                listGroups.Add(new GroupData(GeneraterandomString(30))
                {
                    Header=GeneraterandomString(40),
                    Footer = GeneraterandomString(100)                      
                });
            }
                return listGroups;       
        }     
        
        private static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            var lines =File.ReadAllLines(@"groups.csv");
            return lines.Select(element => element.Split(','))
                .Select(parts => new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                })
                .ToList();
        }
        
        

    }
}
