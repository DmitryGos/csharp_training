using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace MantisAdministrationTests
{
    public class NavigationHelper : HelperBase
    {
        private readonly string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) 
            : base(manager)
        {
            this.baseURL = baseURL;
        }

        public void GotoLoginPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.21.1/login_page.php");
        }

        public void GotoManageProjectPage()
        {
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.21.1/manage_proj_page.php");
        }

        internal void GotoProjectPage(string index)
        {
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.21.1/manage_proj_edit_page.php?project_id=" + index);
        }

        internal void Logout()
        {
            driver.Navigate().GoToUrl(baseURL + "/mantisbt-2.21.1/logout_page.php");
        }
    }
}
