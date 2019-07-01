using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper(ApplicationManager manager) : base(manager) { }

        public void Register(AccountData account)
        {
            OpenMainPage();
            OpenRegistrationForm();
            FillRegistrationForm(account);
            SubmitResgistration();
            string url = GetConfirmationURL(account);
            FillPasswordForm(url);
            SubmitPasswordForm();
        }

        private string GetConfirmationURL(AccountData account)
        {
            string message = manager.Mail.GetLastMail(account);
            if (message == null)
            {
                System.Console.Out.WriteLine("The mail is not received");
                return "The mail is not received";
            }
            else
            {
                Match match = Regex.Match(message, @"http://\S*");
                return match.Value;
            }
        }

        private void FillPasswordForm(string url)
        {
            throw new NotImplementedException();
        }
        private void SubmitPasswordForm()
        {
            throw new NotImplementedException();
        }
        private void OpenRegistrationForm()
        {
            driver.FindElement(By.CssSelector("a.back-to-login-link.pull-left")).Click();
        }

        private void SubmitResgistration()
        {
            driver.FindElement(By.CssSelector("input[type='submit']")).Click();
        }

        private void FillRegistrationForm(AccountData account)
        {
            driver.FindElement(By.Id("username")).SendKeys(account.Name);
            driver.FindElement(By.Id("email-field")).SendKeys(account.Email);

        }

        private void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.21.1/login_page.php";
        }
    }
}
