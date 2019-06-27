using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_white
{
    [TestFixture]
    public class GroupRemovingTests : TestBase
    {
        [Test]
        public void TestGroupRemoving()
        {
            int index = 0;
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            if (oldGroups.Count == 1)
            {
                GroupData auxGroup = new GroupData()
                {Name = "New Group In Delete Group Test"};

                app.Groups.Add(auxGroup);
                oldGroups.Add(auxGroup);
            }

            app.Groups.Remove(index);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(oldGroups[index]);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
