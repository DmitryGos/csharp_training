﻿using System;
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
            GotoHomePage();
            Login(new AccountData("admin", "secret"));
            GotoGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("GroupName1");
            group.Header = "GroupHeader1";
            group.Footer = "GroupFooter1";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }
    }
}
