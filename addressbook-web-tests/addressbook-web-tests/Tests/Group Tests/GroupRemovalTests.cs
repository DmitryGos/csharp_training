﻿using System;
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

            //Считываем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //Уаляем заданную группу из списка
            oldGroups.RemoveAt(index);

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
