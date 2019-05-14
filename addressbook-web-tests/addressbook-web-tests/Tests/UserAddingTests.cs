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
            app.Navigator.GotoHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GotoUserAddingPage();
            UserData user = new UserData("Uname1", "Ulastname1");
            app.Users.SettingAdditionalUserData(user);
            app.Users.FillUserForm(user);
            app.Users.SubmitUserCreation();
        }
    }
}
