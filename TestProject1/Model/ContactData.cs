using System;
using System.Text.RegularExpressions;

namespace AddressbookWebTests
{
  public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private object contactDetails;

        public ContactData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        
        public ContactData(string firstname)
        {
            Firstname = firstname;
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ContactData) obj);
        }


        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        
        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

          public override int GetHashCode()
        {
            return (Firstname != null ? Firstname.GetHashCode() : 0);
        }
        
        
        public override string ToString()
        {
            return "firstname=" + Firstname +  "lastname=" + Lastname;
        }
        
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(WorkPhone) + CleanUp(MobilePhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string ContactDetails
        {
            get
            {
                if (contactDetails != null)
                {
                    return ContactDetails;
                }
                else
                {
                    return (CleanUp(Firstname) + CleanUp(Lastname) 
                        + CleanUp(Address) + CleanUp(Address) + CleanUp(HomePhone) 
                        + CleanUp(WorkPhone) + CleanUp(MobilePhone)).Trim();
                }
            }
            set
            {
                ContactDetails = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n"; 
        }


        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            string fullName = Lastname + Firstname;
            string otherFullName = other.Lastname + other.Firstname;
            return fullName.CompareTo(otherFullName);
        }
        
        
    }
}