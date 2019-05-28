using System;
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
            int index = 1;
            ContactData newData = new ContactData("UnameNew", "UlastnameNew");

            app.Contacts.MakeSureAContactExists(index);

            app.Contacts.Modify(index, newData);
        }
    }

}
