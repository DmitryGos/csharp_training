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
            int i = 0;
            //Make sure that at least 1 Group & 1 Contact exist
            app.Groups.MakeSureAGroupExists();
            app.Contacts.MakeSureAContactExists(0);

            List<GroupData> groups = GroupData.GetAll();
            List<ContactData> allContacts = ContactData.GetAll();
            GroupData group = null;
            List<ContactData> oldList = null;
            ContactData contactNotInGroup = null;
            bool groupToAddFound = false;
            for (i = 0; i < groups.Count; i++)
            {
                group = groups[i];
                oldList = group.GetContacts();
                //Group doesn't contain a contact - can be added any
                if (oldList.Count == 0)
                {
                    contactNotInGroup = allContacts[0];
                    groupToAddFound = true;
                    break;
                }
                //Group contains all contacts - skip the group
                else if (oldList.Count == allContacts.Count)
                {
                    continue;
                }
                else
                {
                    contactNotInGroup = ContactData.GetAll().Except(oldList).First();
                    groupToAddFound = true;
                    break;
                }
            }

            if (!groupToAddFound)
            {
                //A proper group is not found - create a new one
                group = app.Groups.GenerateGroupData();
                app.Groups.Create(group);
                group = GroupData.GetAll().Except(groups).First();
                oldList = group.GetContacts();
                contactNotInGroup = allContacts[0];
            }
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
