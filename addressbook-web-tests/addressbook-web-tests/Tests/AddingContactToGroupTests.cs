using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contactNotInGroup = ContactData.GetAll().Except(oldList).First();

            //actions
            app.Contacts.AddContactToGroup(contactNotInGroup, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contactNotInGroup);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
