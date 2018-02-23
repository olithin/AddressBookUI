using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using NUnit.Framework.Constraints;
using OpenQA.Selenium;

namespace AddressbookWebTests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            SelectGroup(p);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }


        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (1 + index) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public void GroupCreated()
        {
            if (IsGroupCreated())
            {
                return;
            }
            GroupData group = new GroupData("aaa");
            group.Header = "ddd";
            group.Footer = "fff";
            Create(group);
        }

        public bool IsGroupCreated()
        {
            return IsElementPresent(By.CssSelector("span.group"));
        }

        public List<GroupData> GetGroupList()
        {
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            return elements.Select(element => new GroupData(element.Text)).ToList();
        }

        private List<GroupData> groupCache = null;


        public List<GroupData> GetGroupCashList()
        {
            if (groupCache != null) return new List<GroupData>(groupCache);
            groupCache = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (var element in elements)
            {
                groupCache.Add(new GroupData(element.Text)
                {
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
            return new List<GroupData>(groupCache);
        }

       // into video 5_2 
        public List<GroupData> GetGroupCashListOptimize()
        {
            if (groupCache != null) return new List<GroupData>(groupCache);
            groupCache = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (var element in elements)
            {
                groupCache.Add(new GroupData(null){
                    Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                });
            }
            var allGroupsNames = driver.FindElement(By.CssSelector("div#content form")).Text;
            var parts = allGroupsNames.Split('\n');
            var shift = groupCache.Count - parts.Length;
            for (var i= 0; i < groupCache.Count; i++)
            {
                groupCache[i].Name = i < shift ? "" : parts[i-shift].Trim();
            }
            return new List<GroupData>(groupCache);
        }

        
        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
       }
 }
}