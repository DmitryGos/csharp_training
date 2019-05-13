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
            navigator.GotoHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GotoUserAddingPage();
            UserData user = new UserData("Uname1", "Ulastname1");
            userHelper.SettingAdditionalUserData(user);
            userHelper.FillUserForm(user);
            userHelper.SubmitUserCreation();
        }
    }
}
