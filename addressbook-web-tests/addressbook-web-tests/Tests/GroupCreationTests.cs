using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GotoHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GotoGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("GroupName1");
            group.Header = "GroupHeader1";
            group.Footer = "GroupFooter1";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Groups.ReturnToGroupsPage();
        }
    }
}
