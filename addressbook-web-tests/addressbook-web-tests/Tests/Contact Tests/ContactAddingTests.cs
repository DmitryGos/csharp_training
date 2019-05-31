using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAddingTests : AuthTestBase
    {
        [Test]
        public void ContactAddingTest()
        {
            //Генерируем данные для нового контакта
            ContactData contact = app.Contacts.GenerateContactData();

            //Считываем текущий список контактов
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GeContactsCount());

            //Считываем новый список контактов
            List<ContactData> newContacts = app.Contacts.GetContactList();

            //Добавляем данные нового контакта в старый список
            oldContacts.Add(contact);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
