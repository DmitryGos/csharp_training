using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModiticationTest()
        {
            app.Groups.MakeSureAGroupExists();

            GroupData newData = new GroupData("NewGroupName");
            newData.Header = null;
            newData.Footer = null;

            app.Groups.Modify(0, newData);
        }
    }
}
