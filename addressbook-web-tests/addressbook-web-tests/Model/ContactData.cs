using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allEmails;
        private string allPhones;
        public ContactData()
        {
        }
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public bool Equals(ContactData other)
        {
            if (other is null)
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            if (LastName == other.LastName)
            {
                return FirstName == other.FirstName;
            }
            return LastName == other.LastName;
        }
        public override int GetHashCode()
        {
            return LastName.GetHashCode();
        }
        public override string ToString()
        {
            return LastName + " " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            //Если объект null, возвращаем 1 (заведомо больше)
            if (other is null)
            {
                return 1;
            }
            //Если фамилии равны, сравниваем имена
            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }
            //Сравниваем фамилии
            return LastName.CompareTo(other.LastName);
        }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }
        
        [Column(Name = "lastname")]
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string NickName { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones
        {
            get {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }

            set
            {
                allPhones = value;
            }
        }
        public string Email { get; set; }

        public string Email2 { get; set; }

        public string Email3 { get; set; }
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    if (Email != null || Email != "")
                    { allEmails = Email; }
                    if (Email2 != null || Email2 != "")
                    { allEmails = (allEmails + "\r\n" + Email2).Trim(); }
                    if (Email3 != null || Email3 != "")
                    { allEmails = (allEmails + "\r\n" + Email3).Trim(); }

                    return allEmails.Trim().Replace("\r\n\r\n", "\r\n");
                }
            }

            set
            {
                allEmails = value;
            }
        }
        [Column(Name = "deprecated")]
        public string Deprecated { get; set; } 
        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }
        public static List<ContactData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }
        public List<GroupData> GetGroups()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                List<GroupData> groups =
                    (from g in db.Groups
                     from gcr in db.GCR.Where(p => p.ContactId == Id && p.GroupId == g.Id)
                     select g).Distinct().ToList();
                return groups;
            }
        }
    }
}
