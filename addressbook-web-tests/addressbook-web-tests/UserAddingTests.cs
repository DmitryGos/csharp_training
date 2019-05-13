using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserAddingTests : TestBase
    {
        [Test]
        public void UserAddingTest()
        {
            GotoHomePage();
            Login(new AccountData("admin", "secret"));
            GotoUserAddingPage();
            UserData user = new UserData("Uname1", "Ulastname1");
            SettingAdditionalUserData(user);
            FillUserForm(user);
            SubmitUserCreation();
        }
    }
}
