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
            ProjectData project = new ProjectData();
            bool result = true;
            int i = 0;

            do
            {
                project.Name = GenerateRandomString(10);
                result = app.ProjManager.CheckProjectAdded(project);
                i++;

                if (i == 100)
                {
                    System.Console.Out.WriteLine("Project cannot be added because not free name is found.");
                    return;
                }
            } while (result == true);

            app.ProjManager.AddProject(project);

            Assert.IsTrue(app.ProjManager.CheckProjectAdded(project));
        }
    }
}
