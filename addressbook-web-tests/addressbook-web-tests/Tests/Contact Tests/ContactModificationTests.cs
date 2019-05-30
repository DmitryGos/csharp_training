﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            int index = 0;

            //Выполняем проверку существования хотя бы одной группы (если не существует - создаём)
            app.Contacts.MakeSureAContactExists(index);

            //Генерируем данные для нового контакта
            ContactData newData = app.Contacts.GenerateContactData();

            //Считываем текущий список контактов
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(index, newData);

            //Считываем новый список контактов
            List<ContactData> newContacts = app.Contacts.GetContactList();

            //Меняем данные контакта в старом списке
            oldContacts[index].FirstName = newData.FirstName;
            oldContacts[index].LastName = newData.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }

}
