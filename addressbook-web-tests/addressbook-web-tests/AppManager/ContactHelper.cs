﻿using System;
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

        public ContactHelper Modify(UserData newData)
        {
            manager.Navigator.GotoHomePage();

            InitContactModification(newData);
            FillContactForm(newData);
            ConfirmContactModification();

            return this;
        }

        public ContactHelper Remove(UserData user)
        {
            manager.Navigator.GotoHomePage();

            SelectContact(user);
            DeleteSelectedAccount();
            ConfirmContactRemoval();

            return this;
        }

        public ContactHelper SelectContact(UserData user)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + user.Id + "]/td/input")).Click();
            //driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='import'])[1]/following::td[1]")).Click();

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

        public ContactHelper InitContactModification(UserData newData)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + newData.Id + "]")).Click();
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
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(user.Midname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(user.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(user.Nickname);
            return this;
        }
        public ContactHelper ConfirmContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
        public ContactHelper ConfirmContactModification()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
