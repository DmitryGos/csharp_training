using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            int index = 0;
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[index]);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
