﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModiticationTest()
        {
            int index = 0;

            //Выполняем проверку существования хотя бы одной группы (если не существует - создаём)
            app.Groups.MakeSureAGroupExists();

            //Генерируем данные для новой группы
            GroupData newData = app.Groups.GenerateGroupData();
            newData.Header = null;
            newData.Footer = null;

            //Считываем текущий список групп
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(index, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupsCount());

            //Считываем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //Меняем данные группы в старом списке
            oldGroups[index].Name = newData.Name;

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
