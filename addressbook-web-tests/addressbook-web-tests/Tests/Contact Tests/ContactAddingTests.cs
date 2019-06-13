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
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(30))
                {
                    MiddleName = GenerateRandomString(30),
                    NickName = GenerateRandomString(30),
                    Address = GenerateRandomString(70),
                    HomePhone = GenerateRandomNumber(11),
                    MobilePhone = GenerateRandomNumber(11),
                    WorkPhone = GenerateRandomNumber(11),
                    Email = GenerateRandomString(20),
                    Email2 = GenerateRandomString(20),
                    Email3 = GenerateRandomString(20)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void ContactAddingTest(ContactData contact)
        {
            //Генерируем данные для нового контакта
            //ContactData contact = app.Contacts.GenerateContactData();

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
