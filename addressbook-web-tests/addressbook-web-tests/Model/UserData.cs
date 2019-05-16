using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class UserData
    {
        private string firstname;
        private string lastname;
        private string midname = "";
        private string nickname = "";
        private string id = "";

    public UserData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
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
                return lastname;
            }
            set
            {
                lastname = value;
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
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
    }
}
