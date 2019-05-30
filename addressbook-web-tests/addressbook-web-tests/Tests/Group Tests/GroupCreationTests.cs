using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            //Генерируем данные для новой группы
            GroupData group = app.Groups.GenerateGroupData();

            //Считываем текущий список групп
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());
            //Считываем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();
            
            //Добавляем данные новой группы в старый список
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
        [Test]
        public void EmptyGroupCreationTest()
        {
            //Генерируем данные для новой группы
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            //Считываем текущий список групп
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());

            //Считываем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //Добавляем данные новой группы в старый список
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
        //[Test]
        public void BadNameGroupCreationTest()
        {
            //Генерируем данные для новой группы
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            //Считываем текущий список групп
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupsCount());
            
            //Считываем новый список групп
            List<GroupData> newGroups = app.Groups.GetGroupList();

            //Добавляем данные новой группы в старый список
            oldGroups.Add(group);

            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
