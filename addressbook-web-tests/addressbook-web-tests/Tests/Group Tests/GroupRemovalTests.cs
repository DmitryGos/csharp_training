using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;

            //Выполняем проверку существования хотя бы одной группы (если не существует - создаём)
            app.Groups.MakeSureAGroupExists();

            //Считываем текущий список групп
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Remove(index);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupsCount());

            //Считываем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[index];
            //Уаляем заданную группу из списка
            oldGroups.RemoveAt(index);

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                Assert.AreNotEqual(toBeRemoved.Id, group.Id);
            }
        }
    }
}
