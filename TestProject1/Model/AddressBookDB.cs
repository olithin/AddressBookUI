using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB;

namespace AddressbookWebTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook")
        {
        }

        public ITable<GroupData> Groups => GetTable<GroupData>();

        public ITable<ContactData> Contacts => GetTable<ContactData>();
    }
}

