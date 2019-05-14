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
    public class UserHelper : HelperBase
    {
        public UserHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        internal void Create(UserData user)
        {
            manager.Navigator.GotoUserAddingPage();
            SettingAdditionalUserData(user);
            FillUserForm(user);
            SubmitUserCreation();
        }

        public UserHelper SettingAdditionalUserData(UserData user)
        {
            user.Midname = "UMidname1";
            user.Nickname = "UNickName1";
            return this;
        }
        public UserHelper FillUserForm(UserData user)
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
        public UserHelper SubmitUserCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
