using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int index = 0;

            //Выполняем проверку существования хотя бы одного контакта (если не существует - создаём)
            app.Contacts.MakeSureAContactExists(index);

            //Считываем текущий список контактов
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(index);

            //Считываем новый список контактов
            List<ContactData> newContacts = app.Contacts.GetContactList();

            //Уаляем контакт из списка
            oldContacts.RemoveAt(index);

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
