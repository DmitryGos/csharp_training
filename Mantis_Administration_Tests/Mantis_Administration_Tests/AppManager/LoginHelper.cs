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

        public void LoginToMantis(AccountData account)
        {
            Type(By.Id("username"), account.Name);
            driver.FindElement(By.TagName("input[type='submit']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.Id("hidden_username")).Count > 0);

            Type(By.Id("password"), account.Password);
            driver.FindElement(By.TagName("input[type='submit']")).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => driver.FindElements(By.LinkText(account.Name)).Count > 0);
        }

    }
}
