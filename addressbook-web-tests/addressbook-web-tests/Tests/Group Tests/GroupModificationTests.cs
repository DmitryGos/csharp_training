using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModiticationTest()
        {
            GroupData newData = new GroupData("GroupName3");
            newData.Header = "GroupHeader3";
            newData.Footer = "GroupFooter3";

            app.Groups.Modify(1, newData);
        }
    }
}
