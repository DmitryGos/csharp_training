using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace MantisAdministrationTests
{
    public class ProjectManagementHelper : HelperBase
    {
        private List<ProjectData> projectsCache = null;

        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public ProjectManagementHelper InitNewProjectCreation()
        {
            driver.FindElement(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")).Click();
            return this;
        }

        internal void RemoveProject(string index)
        {
            manager.Navigator.GotoProjectPage(index);
            DeleteProject();
            ConfirmDelition();
        }

        private void DeleteProject()
        {
            driver.FindElement(By.Id("project-delete-form")).FindElement(By.TagName("input[type='submit']")).Click();
        }

        private void ConfirmDelition()
        {
            driver.FindElement(By.TagName("input[type='submit']")).Click();
            IsElementPresent(By.LinkText("/mantisbt-2.21.1/account_page.php"));
        }

        internal void AddProject(ProjectData project)
        {
            manager.Navigator.GotoManageProjectPage();
            InitNewProjectCreation();
            FillNewProjectForm(project);
            ConfirmAddingProject();

            projectsCache = null;
        }

        public ProjectManagementHelper FillNewProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
            return this;
        }

        public ProjectManagementHelper ConfirmAddingProject()
        {
            driver.FindElement(By.TagName("input[type='submit']")).Click();
            IsElementPresent(By.CssSelector("button.btn.btn-primary.btn-white.btn-round")); 
            return this;
        }
        
        public List<ProjectData> GetProjectsList()
        {
            if (projectsCache == null)
            {
                projectsCache = new List<ProjectData>();
                manager.Navigator.GotoManageProjectPage();
                IList<IWebElement> elements = driver.FindElements(By.TagName("table"))[0].FindElement(By.TagName("tbody")).FindElements(By.TagName("tr")).ToList<IWebElement>();
                foreach (IWebElement element in elements)
                {
                    projectsCache.Add(new ProjectData()
                    {
                        Name = element.FindElement(By.TagName("td")).Text,
                        Id = Regex.Match(element.FindElement(By.TagName("td"))
                            .FindElement(By.TagName("a"))
                            .GetAttribute("href")
                            , "(?<=id=).*")
                            .Value
                    });
                }                
            }
        return projectsCache;
        }
        public bool CheckProjectAdded(ProjectData project)
        {
            List<ProjectData> projectsList = GetProjectsList();

            for (int i = 0; i < projectsList.Count; i++)
            {
                if (projectsList[i].Name == project.Name)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
