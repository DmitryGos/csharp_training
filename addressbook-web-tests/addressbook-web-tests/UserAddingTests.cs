using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserAddingTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void UserAddingTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GotoUserAddingPage();
            UserData user = new UserData("Uname1", "Ulastname1", "Uemail1");
            SettingAdditionalUserData(user);
            FillUserForm(user);
            CreateNewUser();
        }

        private void CreateNewUser()
        {
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Notes:'])[1]/following::input[1]")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        private static void SettingAdditionalUserData(UserData user)
        {
            user.Midname = "UMidname1";
            user.Nickname = "UNickName1";
            user.Title = "UTitle1";
            user.Company = "UCompany1";
            user.Address = "UAddress1";
            user.Phone_home = "UHome1";
            user.Phone_mobile = "UMobile1";
            user.Phone_work = "UWork1";
            user.Phone_fax = "UFax1";
            user.Photo = "c:\\users\\User\\source\\repos\\csharp_training\\avatar.png";
            user.Email2 = "UEmail21";
            user.Email3 = "UEmail31";
            user.Homepage = "UHomepage1";
            user.Bday = "1";
            user.Bmonth = "April";
            user.Byear = "1980";
            user.Aday = "1";
            user.Amonth = "April";
            user.Ayear = "2030";
            user.Address2 = "UAddressSec1";
            user.Phone_home2 = "UPhomeHome21";
            user.Notes = "Notes1";
        }

        private void FillUserForm(UserData user)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(user.Midname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(user.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(user.Nickname);
            driver.FindElement(By.Name("photo")).Click();
            driver.FindElement(By.Name("photo")).Clear();
            driver.FindElement(By.Name("photo")).SendKeys(user.Photo);
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(user.Title);
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(user.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(user.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(user.Phone_home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(user.Phone_mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(user.Phone_work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(user.Phone_fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(user.Email);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(user.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(user.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(user.Homepage);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(user.Bday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[3]")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(user.Bmonth);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::option[38]")).Click();
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(user.Byear);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::label[1]")).Click();
            // ERROR: Caught exception [ERROR: Unsupported command [doubleClick | xpath=(.//*[normalize-space(text()) and normalize-space(.)='Birthday:'])[1]/following::label[1] | ]]
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(user.Aday);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[3]")).Click();
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(user.Amonth);
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Anniversary:'])[1]/following::option[38]")).Click();
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(user.Ayear);
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(user.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(user.Phone_home2);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(user.Notes);
        }

        private void GotoUserAddingPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        private void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");
        }

        private void Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
