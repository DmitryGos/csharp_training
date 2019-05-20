using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            UserData newData = new UserData("UnameNew", "UlastnameNew");

            app.Users.Modify(1, newData);
        }
    }

}
