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

        public ContactHelper InitContactModification(int num)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + num + "]")).Click();
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
            Type(By.Name("firstname"), user.Firstname);
            Type(By.Name("middlename"), user.Midname);
            Type(By.Name("lastname"), user.Lastname);
            Type(By.Name("nickname"), user.Nickname);

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
