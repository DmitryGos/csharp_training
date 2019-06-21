using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModiticationTest()
        {
            int index = 0;

            //Выполняем проверку существования хотя бы одной группы (если не существует - создаём)
            //app.Groups.MakeSureAGroupExists();
            if (GroupData.GetAll().Count == 0)
            {
                app.Groups.Create(app.Groups.GenerateGroupData());
            }

            //Генерируем данные для новой группы
            GroupData newData = app.Groups.GenerateGroupData();
            newData.Header = null;
            newData.Footer = null;

            //Считываем текущий список групп
            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[index];

            app.Groups.Modify(oldData.Id, newData);

            //Считываем новый список групп
            List<GroupData> newGroups = GroupData.GetAll();

            Assert.AreEqual(oldGroups.Count, newGroups.Count);

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
