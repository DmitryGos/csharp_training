using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace MantisAdministrationTests
{
    [TestFixture]
    public class AddingProjectTests : AuthTestBase
    {
        [Test]
        public void AddingProjectTest()
        {
            AccountData admin = new AccountData()
            {
                Name = "Administrator",
                Password = "root"
            };
            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(10)
            };

            app.Navigator.GotoManageProjectPage();
            app.ProjManager.InitNewProjectCreation()
                .FillNewProjectForm(project)
                .ConfirmAddingProject();

            Assert.IsTrue(app.ProjManager.CheckProjectAdded(project));
        }
    }
}
