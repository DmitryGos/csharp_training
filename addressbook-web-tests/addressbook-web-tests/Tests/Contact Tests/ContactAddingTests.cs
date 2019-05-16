using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactAddingTests : TestBase
    {
        [Test]
        public void ContactAddingTest()
        {
            UserData user = new UserData("Uname1", "Ulastname1");

            app.Users.Create(user);
        }
    }
}
