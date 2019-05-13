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
            navigator.GotoHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GotoGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("GroupName1");
            group.Header = "GroupHeader1";
            group.Footer = "GroupFooter1";
            groupHelper.FillGroupForm(group);
            groupHelper.SubmitGroupCreation();
            groupHelper.ReturnToGroupsPage();
        }
    }
}
