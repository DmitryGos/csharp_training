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
    public class NavigationHelper : HelperBase
    {
        private string baseURL;

        public NavigationHelper (IWebDriver driver, string baseURL) 
            : base(driver)
        {
            this.baseURL = baseURL;
        }

        public void GotoHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }
        public void GotoGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void GotoUserAddingPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

    }
}
