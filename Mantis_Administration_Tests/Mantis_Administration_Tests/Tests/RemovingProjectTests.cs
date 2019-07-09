using System;
using System.Text;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;

namespace MantisAdministrationTests
{
    [TestFixture]
    public class RemovingProjectTests : AuthTestBase
    {
        [Test]
        public void RemovingProjectTest()
        {
            int index = 0;

            List<ProjectData> oldList = app.ProjManager.GetProjectsList();

            app.ProjManager.RemoveProject(oldList[index].Id);

            List<ProjectData> newList = app.ProjManager.GetProjectsList();

            oldList.RemoveAt(index);

            Assert.AreEqual(oldList, newList);
        }
    }
}
