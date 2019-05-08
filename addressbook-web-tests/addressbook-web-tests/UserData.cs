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
        private string midname;
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address = "";
        private string phone_home = "";
        private string phone_mobile = "";
        private string phone_work = "";
        private string phone_fax = "";
        private string email = "";
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

        public UserData(string firstname, string midname, string lastname)
        {
            this.firstname = firstname;
            this.midname = midname;
            this.lastname = lastname;
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
            get {
                return title;
            }
            set {
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
    }
}
