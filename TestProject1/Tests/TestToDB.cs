using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace AddressbookWebTests
{
    [TestFixture]
    public class TestToDB
    {
        protected ApplicationManager app;
        
        public void TestConnectionDB()
        {
            //берем данные с UI
            DateTime start = DateTime.Now;
            List<GroupData> fromUI = app.Groups.GetGroupCashListOptimize();
            DateTime end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
            
            //берем данные с BD
            start = DateTime.Now;
            AddressBookDB db = new AddressBookDB();
            List<GroupData> fromDB = (from g in db.Groups select g).ToList();
            db.Close();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }  
        
        
      //  или так закрывая соединение с базой через using     
        [Test]
        public void TestConnectionDB_2()
        {
            //берем данные с UI
            var start = DateTime.Now;
            var fromUI = app.Groups.GetGroupCashListOptimize();
            var end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
            
            //берем данные с BD
            start = DateTime.Now;
            using(var db = new AddressBookDB())
            {
                var fromDB = (from g in db.Groups select g).ToList();    
            }
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}