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
            int i;
            List<ContactData> oldList = null;

            List <GroupData> groups = GroupData.GetAll();
            for (i = 0; i < groups.Count; i++)
            {
                oldList = groups[i].GetContacts();
                if (oldList.Count != 0)
                {
                    break;
                }
                if (i == groups.Count - 1)
                {
                    System.Console.Out.WriteLine("There is no groups with contacts found!");
                }
            }
            ContactData contactInGroup = oldList[0];

            //actions
            app.Contacts.RemoveContactFromGroup(contactInGroup, groups[i]);

            List<ContactData> newList = groups[i].GetContacts();
            oldList.RemoveAt(0);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
