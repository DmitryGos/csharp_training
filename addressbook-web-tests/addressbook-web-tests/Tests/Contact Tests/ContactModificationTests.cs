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
            UserData newData = new UserData("UnameNew", "UlastnameNew");

            app.Users.MakeSureAContactExists(index);

            app.Users.Modify(index, newData);
        }
    }

}
