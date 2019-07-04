using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace MantisAdministrationTests
{
    public class ApplicationManager
    {
        private readonly IWebDriver driver;
        protected string baseURL;

        private static readonly ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            baseURL = "http://localhost";

            Navigator = new NavigationHelper(this, baseURL);
            Login = new LoginHelper(this);
            ProjManager = new ProjectManagementHelper(this);
        }
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigator.GotoLoginPage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }
        public NavigationHelper Navigator { get; private set; }
        public LoginHelper Login { get; private set; }
        public ProjectManagementHelper ProjManager { get; private set; }
    }
}
