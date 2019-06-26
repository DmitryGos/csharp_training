using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            //Make sure that at least 1 Group & 1 Contact exist
            app.Groups.MakeSureAGroupExists();
            app.Contacts.MakeSureAContactExists(0);

            int i = 0;
            List<ContactData> oldList = null;
            List <GroupData> groups = GroupData.GetAll();
            ContactData contactInGroup = null;
            GroupData groupWithContact = null;

            //Checking that there is at least 1 group with a contact
            for (i = 0; i < groups.Count; i++)
            {
                oldList = groups[i].GetContacts();
                //If the contact list of group is not empty, set 'contactIngroup' & 'groupWithContact' variables
                if (oldList.Count != 0)
                {
                    contactInGroup = oldList[0];
                    groupWithContact = groups[i];
                    break;
                }
            }
            //If the group with a contact has not been found, add 1st contact to the 1st group
            if (contactInGroup == null)
            {
                contactInGroup = ContactData.GetAll()[0];
                groupWithContact = GroupData.GetAll()[0];
                app.Contacts.AddContactToGroup(contactInGroup, groupWithContact);
                oldList = groupWithContact.GetContacts();
            }

            //actions
            app.Contacts.RemoveContactFromGroup(contactInGroup, groupWithContact);

            List<ContactData> newList = groupWithContact.GetContacts();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
