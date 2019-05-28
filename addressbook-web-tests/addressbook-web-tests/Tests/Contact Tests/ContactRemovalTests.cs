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

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.MakeSureAContactExists(index)
                .Remove(index);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            if (oldContacts.Count > 0)
            {
                oldContacts.RemoveAt(index);
            }
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
