using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName;
        private string lastName;

        public ContactData(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
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
            if (lastName == other.LastName)
            {
                return firstName == other.FirstName;
            }
            return lastName == other.LastName;

        }
        public override int GetHashCode()
        {
            return lastName.GetHashCode();
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

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
            }
        }
    }
}
