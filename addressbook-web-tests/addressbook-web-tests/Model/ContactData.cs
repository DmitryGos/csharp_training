using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public bool Equals(ContactData other)
        {
            if (object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, other))
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
            return "Full Name = " + LastName + " " + FirstName;
        }
        public int CompareTo(ContactData other)
        {
            //Если объект null, возвращаем 1 (заведомо больше)
            if (object.ReferenceEquals(other, null))
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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
    }
}
