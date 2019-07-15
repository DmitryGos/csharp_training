using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace MantisAdministrationTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {

            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }
                Logout();
            }

            Type(By.Id("username"), account.Username);
            driver.FindElement(By.TagName("input[type='submit']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.Id("hidden_username")).Count > 0);

            Type(By.Id("password"), account.Password);
            driver.FindElement(By.TagName("input[type='submit']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.LinkText(account.Username)).Count > 0);
        }

        private bool IsLoggedIn()
        {
            return IsElementPresent(By.TagName("a[href='/mantisbt-2.21.1/logout_page.php']"));
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggedUsername() == account.Username;
        }
        private string GetLoggedUsername()
        {
            return driver.FindElement(By.ClassName("user-info")).Text;
        }
        private void Logout()
        {
            manager.Navigator.Logout();
        }
    }
}
