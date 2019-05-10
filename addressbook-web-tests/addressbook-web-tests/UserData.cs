using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class UserData
    {
        private string firstname;
        private string lastname;
        private string email;
        private string midname = "";
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string phone_home = "";
        private string phone_mobile = "";
        private string phone_work = "";
        private string phone_fax = "";
        private string photo = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage= "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone_home2 = "";
        private string notes = "";

    public UserData(string firstname, string lastname, string email)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Midname
        {
            get
            {
                return midname;
            }
            set
            {
                midname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return Lastname;
            }
            set
            {
                Lastname = value;
            }
        }
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
    public string Company
        {
            get
            {
                return company;
            }
            set
            {
                company = value;
            }
        }
    public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }
    public string Phone_home
        {
            get
            {
                return phone_home;
            }
            set
            {
                phone_home = value;
            }
        }
    public string Phone_mobile
        {
            get
            {
                return phone_mobile;
            }
            set
            {
                phone_mobile = value;
            }
        }
    public string Phone_work
        {
            get
            {
                return phone_work;
            }
            set
            {
                phone_work = value;
            }
        }
        public string Phone_fax
        {
            get
            {
                return phone_fax;
            }
            set
            {
                phone_fax = value;
            }
        }
        public string Photo
        {
            get
            {
                return photo;
            }
            set
            {
                photo = value;
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }
        public string Email2
        {
            get
            {
                return email2;
            }
            set
            {
                email2 = value;
            }
        }
        public string Email3
        {
            get
            {
                return email3;
            }
            set
            {
                email3 = value;
            }
        }
        public string Homepage
        {
            get
            {
                return homepage;
            }
            set
            {
                homepage = value;
            }
        }
        public string Bday
        {
            get
            {
                return bday;
            }
            set 
            {
                bday = value;
            }
        }
        public string Bmonth
        {
            get
            {
                return bmonth;
            }
            set
            {
                bmonth = value;
            }
        }
        public string Byear
        {
            get
            {
                return byear;
            }
            set
            {
                byear = value;
            }
        }

        public string Aday
        {
            get
            {
                return aday;
            }
            set
            {
                aday = value;
            }
        }
        public string Amonth
        {
            get
            {
                return amonth;
            }
            set
            {
                amonth = value;
            }
        }
        public string Ayear
        {
            get
            {
                return ayear;
            }
            set
            {
                ayear = value;
            }
        }
        public string Address2
        {
            get
            {
                return address2;
            }
            set
            {
                address2 = value;
            }
        }
        public string Phone_home2
        {
            get
            {
                return phone_home2;
            }
            set
            {
                phone_home2 = value;
            }
        }
        public string Notes
        {
            get
            {
                return notes;
            }
            set
            {
                notes = value;
            }
        }
    }
}
