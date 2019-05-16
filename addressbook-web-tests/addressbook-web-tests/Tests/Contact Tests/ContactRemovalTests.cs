using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            UserData user = new UserData("Uname1", "Ulastname1");
            user.Id = "2";

            app.Users.Remove(user);
        }
    }
}
