

namespace AddressbookWebTests
{
    public class ContactData
    {
        private string firstname;
        private string lastname;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = Firstname;
            this.lastname = Lastname;
        }


        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }
    }
}
