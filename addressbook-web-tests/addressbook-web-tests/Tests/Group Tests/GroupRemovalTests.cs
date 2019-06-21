using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int index = 0;

            //Выполняем проверку существования хотя бы одной группы (если не существует - создаём)
            //app.Groups.MakeSureAGroupExists();
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(app.Groups.GenerateGroupData());
            }

            //Считываем текущий список групп
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData toBeRemoved = oldGroups[index];

            app.Groups.Remove(toBeRemoved);

            //Считываем новый список групп
            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups.Count - 1, newGroups.Count);

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
