using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            int index = 0;

            //Выполняем проверку существования хотя бы одного контакта (если не существует - создаём)
            //app.Contacts.MakeSureAContactExists(index);
            if (ContactData.GetAll().Count == 0)
            {
                app.Contacts.Create(app.Contacts.GenerateContactData());
            }

            //Считываем текущий список контактов
            List<ContactData> oldContacts = ContactData.GetAll();

            app.Contacts.Remove(index);

            //Считываем новый список контактов
            List<ContactData> newContacts = app.Contacts.GetContactList();

            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count);

            ContactData toBeRemoved = oldContacts[index];
            //Уаляем контакт из списка
            oldContacts.RemoveAt(index);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(toBeRemoved.Id, contact.Id);
            }

        }
    }
}
