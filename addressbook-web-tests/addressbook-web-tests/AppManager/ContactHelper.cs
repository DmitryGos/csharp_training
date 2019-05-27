using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }
        public ContactHelper Create(UserData user)
        {
            manager.Navigator.GotoContactAddingPage();
            SettingAdditionalUserData(user);
            FillContactForm(user);
            ConfirmContactCreation();

            return this;
        }
        public ContactHelper Modify(int id, UserData newData)
        {
            manager.Navigator.GotoHomePage();

            InitContactModification(id);
            FillContactForm(newData);
            ConfirmContactModification();

            return this;
        }
        public ContactHelper Remove(int id)
        {
            manager.Navigator.GotoHomePage();

            SelectContact(id);
            DeleteSelectedAccount();
            ConfirmContactRemoval();

            return this;
        }
        public bool DoesTheContactExist(int id)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + id + "]"));
        }
        internal void MakeSureAContactExists(int index)
        {
            if (!DoesTheContactExist(index))
            {
                UserData user = new UserData("Uname", "Ulastname");

                Create(user);
                manager.Navigator.GotoHomePage();
            }
        }
        public ContactHelper SelectContact(int id)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + id + "]")).Click();

            return this;
        }
        private void DeleteSelectedAccount()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        }
        private void ConfirmContactRemoval()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public ContactHelper InitContactModification(int index)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + index + "]")).Click();
            return this;
        }
        public ContactHelper SettingAdditionalUserData(UserData user)
        {
            user.Midname = "UMidname1";
            user.Nickname = "UNickName1";
            return this;
        }
        public ContactHelper FillContactForm(UserData user)
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 20);

            Type(By.Name("firstname"), user.Firstname + "_" + value);
            Type(By.Name("lastname"), user.Lastname + "_" + value);

            return this;
        }
        public ContactHelper ConfirmContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }
        public ContactHelper ConfirmContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])")).Click();
            return this;
        }
    }
}
